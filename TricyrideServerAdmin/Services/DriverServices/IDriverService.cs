using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.DriverServices
{
    public interface IDriverService
    {
        Task<FileModel> UploadFiles(IBrowserFile file, string driverUid);
        Task<List<FileModel>> GetFiles(string driverUid);
        Task DownloadFileAsync(FileModel file, ILocalStorageService _localStorage);
    }
}
