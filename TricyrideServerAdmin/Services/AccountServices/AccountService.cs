using System.Text;
using Firebase.Database;
using Newtonsoft.Json;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly FirebaseClient _firebaseClient;
         private readonly HttpClient _httpClient;
        public AccountService()
        {
            _firebaseClient = new FirebaseClient("https://traysikol-f873d-default-rtdb.firebaseio.com");
            _httpClient = new HttpClient();
        }
        public async Task<UserAccountResponse> SignInWithEmailAndPassword(string email, string password)
        {
            var jsonContent = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsync(
                "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyDSYtNtm37w3ZPxpJtxd2Iig3W7won6FaM",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(jsonContent), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UserAccountResponse>();
            return result;
        }
        public async Task<List<UserAccountModel>> GetUsers()
        {
            var data = await _firebaseClient
                .Child("Accounts")
                .OnceAsync<UserAccountModel>();

            return data.Select(d => new UserAccountModel
            {
                uid = d.Object.uid,
                firstname = d.Object.firstname,
                lastname = d.Object.lastname,
                email = d.Object.email,
                phoneNumber = d.Object.phoneNumber,
                username = d.Object.username,
                password = d.Object.password,
                profilePicture = d.Object.profilePicture,
                accountType = d.Object.accountType,
                dateOfBirth = d.Object.dateOfBirth,
                address = d.Object.address,
                IsApproved = d.Object.IsApproved
            }).ToList();
        }
        public async Task UpdateUser(UserAccountModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            await _firebaseClient
                .Child($"Accounts/{user.uid}/").PutAsync
                (json);
        }
        public async Task<UserAccountResponse> CreateUserWithEmailAndPassword(string email, string password)
        {
            var jsonContent = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            // POST request to Firebase to create a new user
            var response = await _httpClient.PostAsync(
                "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyDSYtNtm37w3ZPxpJtxd2Iig3W7won6FaM",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(jsonContent), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UserAccountResponse>();
            return result;
        }
        public async Task AddDocumentCheckList(DriverDocumentModel document)
        {
            var json = JsonConvert.SerializeObject(document);
            await _firebaseClient
                .Child($"DriverDocuments/{document.key}/").PutAsync
                (json);
        }
        public async Task<DriverDocumentModel> GetDocumentByKey(string key)
        {
            var data = await _firebaseClient
            .Child($"DriverDocuments/{key}")
            .OnceSingleAsync<DriverDocumentModel>();
            if (data != null)
            {
                return new DriverDocumentModel
                {
                    key = data.key,
                    isValidID = data.isValidID,
                    isORCR = data.isORCR,
                    isDriverLicense = data.isDriverLicense,
                    isInsurance = data.isInsurance,
                    ValidID = data.ValidID,
                    ORCR = data.ORCR,
                    DriverLicenseExpiry = data.DriverLicenseExpiry,
                    InsuranceExpiry = data.InsuranceExpiry,
                    LicenseNo = data.LicenseNo,
                    Owner = data.Owner
                };
            }

            return new();
        }
    }
}
