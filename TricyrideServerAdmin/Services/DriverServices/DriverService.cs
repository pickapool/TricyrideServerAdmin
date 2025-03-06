using System.Net;
using Blazored.LocalStorage;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.DriverServices
{
    public class DriverService : IDriverService
    {
        private readonly FirebaseClient _firebaseClient;
        private readonly HttpClient _httpClient;
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;
        public DriverService()
        {
            _firebaseClient = new FirebaseClient("https://traysikol-f873d-default-rtdb.firebaseio.com");
            _httpClient = new HttpClient();
            var credential = GoogleCredential.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "firebaseConfig.json"));
            _storageClient = StorageClient.Create(credential);
            _bucketName = "traysikol-f873d.appspot.com";
        }
        public async Task<FileModel> UploadFiles(IBrowserFile file, string driverUid)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(209715200).CopyToAsync(memoryStream);

                var fileName = file.Name;
                var key = Guid.NewGuid().ToString();
                var storageObjectName = $"uploads/{key}/{fileName}";

                var objectUpload = new Google.Apis.Storage.v1.Data.Object()
                {
                    Bucket = _bucketName,
                    Name = storageObjectName,
                    ContentType = file.ContentType
                };

                memoryStream.Seek(0, SeekOrigin.Begin);  // Reset stream position before uploading

                // Upload the file to Firebase Storage
                var uploadedFile = await _storageClient.UploadObjectAsync(objectUpload, memoryStream);

                // Prepare the file model to save metadata to Realtime Database (optional)
                var fileModel = new FileModel
                {
                    key = key,
                    driverUid = driverUid,
                    file = uploadedFile.MediaLink,
                    fileName = fileName
                };

                // Save file metadata to Firebase Realtime Database (optional)
                await SaveFileMetadataToDatabase(fileModel);
                return fileModel;
            }

        }

        private async Task SaveFileMetadataToDatabase(FileModel fileModel)
        {
            var json = JsonConvert.SerializeObject(fileModel);

            await _firebaseClient
                .Child("Files")
                .PostAsync(json);
        }
    public async Task<List<FileModel>> GetFiles(string driverUid)
    {
        var data = await _firebaseClient
            .Child("Files")
            .OnceAsync<FileModel>();

        return data.Select(d => new FileModel
        {
            key = d.Object.key,
            driverUid = d.Object.driverUid,
            file = d.Object.file,
            fileName = d.Object.fileName,
        }).Where( e => e.driverUid == driverUid).ToList();
    }
        public async Task DownloadFileAsync(FileModel file, ILocalStorageService _localStorage)
        {
            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Uri fileUri = new Uri(file.file);
            var fileName = Uri.UnescapeDataString(fileUri.AbsolutePath.Split(new[] { "/o/" }, StringSplitOptions.None)[1]);
            string localFilePath = Path.Combine(downloadFolder, Path.GetFileName(fileName));
            Directory.CreateDirectory(Path.GetDirectoryName(localFilePath));

            using (var fileStream = File.OpenWrite(localFilePath))
            {
                // Download the file from Firebase Storage to the local file system
                await _storageClient.DownloadObjectAsync(_bucketName, fileName, fileStream);
            }
        }
        public async Task SaveFare(FareModel fare)
        {
            var json = JsonConvert.SerializeObject(fare);

            await _firebaseClient
                .Child("Fare")
                .PatchAsync(json);
        }
        public async Task<FareModel> GetFare()
        {
            var data = await _firebaseClient
            .Child("Fare")
            .OnceSingleAsync<FareModel>();
            if (data != null)
            {
                return new FareModel
                {
                    studentFare = data.studentFare,
                    regularFare = data.regularFare,
                    studentKM = data.studentKM,
                    regularKM = data.regularKM,
                };
            }
            return new();
        }
    }
}
