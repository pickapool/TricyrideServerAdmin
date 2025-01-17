namespace TricyrideServerAdmin.Models
{
    public class UserAccountResponse
    {
        public string IdToken { get; set; }
        public string email { get; set; }
        public string RefreshToken { get; set; }
        public string LocalId { get; set; }
        public string ExpiresIn { get; set; }
    }
}
