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
                Uid = d.Object.Uid,
                Firstname = d.Object.Firstname,
                Lastname = d.Object.Lastname,
                Email = d.Object.Email,
                PhoneNumber = d.Object.PhoneNumber,
                Username = d.Object.Username,
                Password = d.Object.Password,
                ProfilePicture = d.Object.ProfilePicture,
                AccountType = d.Object.AccountType,
                DateOfBirth = d.Object.DateOfBirth,
                Address = d.Object.Address,
                IsApproved = d.Object.IsApproved
            }).ToList();
        }
        public async Task UpdateUser(UserAccountModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            await _firebaseClient
                .Child($"Accounts/{user.Uid}/")
                .PatchAsync(json);
        }
    }
}
