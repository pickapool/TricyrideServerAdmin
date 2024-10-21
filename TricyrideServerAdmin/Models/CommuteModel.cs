using System.Text.Json.Serialization;
using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class CommuteModel
    {
        public string Key { get; set; }
        public string PassengerUid { get; set; }
        public string DriverUid { get; set; }
        public double PassengerLatitude { get; set; }
        public double PassengerLongitude { get; set; }
        public double PassengerDestinationLatitude { get; set; }
        public double PassengerDestinationLongitude { get; set; }
        //public PassengerRoute PassengerRoute { get; set; }
        public bool IsOccupied { get; set; }
        public CommuteStatus CommuteStatus { get; set; }
        public CommuteDateModel CommuteDate { get; set; }
        public string Distance { get; set; }
        public string Fare { get; set; }
        public string Time { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public float Rating { get; set; }

        [JsonIgnore] // or use Newtonsoft.Json.JsonIgnore if applicable
        public UserAccountModel? DriverAccount { get; set; }

        [JsonIgnore] // or use Newtonsoft.Json.JsonIgnore if applicable
        public UserAccountModel? PassengerAccount { get; set; }
    }
}
