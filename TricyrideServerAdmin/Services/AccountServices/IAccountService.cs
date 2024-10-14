using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.AccountServices
{
    public interface IAccountService
    {
        Task<UserAccountResponse> SignInWithEmailAndPassword(string email, string password);
        Task<List<UserAccountModel>> GetUsers();
    }
}
