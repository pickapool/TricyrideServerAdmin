namespace TricyrideServerAdmin.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string LocalId { get; set; }
    }
}