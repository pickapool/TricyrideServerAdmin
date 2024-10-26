using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class UserAccountModel
    {
        public string Uid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public AccountType AccountType { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool? IsApproved { get; set; }

        // Method to get the full name
        public string GetFullName()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
