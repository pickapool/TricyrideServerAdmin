using Newtonsoft.Json;
using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class UserAccountModel
    {
        public UserAccountModel()
    {
        uid = string.Empty;
        firstname = string.Empty;
        lastname = string.Empty;
        email = string.Empty;
        phoneNumber = string.Empty;
        username = string.Empty;
        password = string.Empty;
        profilePicture = string.Empty;
        accountType = string.Empty;
        dateOfBirth = string.Empty;
        address = string.Empty;
        IsApproved = false;  // Default value for nullable boolean
        creationDate = DateTime.Now;  // Default value for nullable DateTime
    }
        public string uid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string profilePicture { get; set; }
        public string accountType { get; set; }
        public string dateOfBirth { get; set; }
        public string address { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? creationDate { get; set; }

        // Method to get the full name
        public string GetFullName()
        {
            return $"{firstname} {lastname}";
        }
        [JsonIgnore]
        public bool isopen {  get; set; }
        [JsonIgnore]
        public List<FileModel> ListFiles { get; set; } = new();
        [JsonIgnore]
        public double AverageRating { get; set; }
    }
}
