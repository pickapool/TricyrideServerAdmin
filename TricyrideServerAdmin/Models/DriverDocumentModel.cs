using System.Text.Json.Serialization;
using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class DriverDocumentModel
    {
        public DriverDocumentModel() {
            key = string.Empty;
            isValidID = false;
            isORCR = false;
            isDriverLicense = false;
            isInsurance = false;
            ValidID = string.Empty;
            ORCR = string.Empty;
            DriverLicenseExpiry = DateTime.Now;
            InsuranceExpiry = DateTime.Now;
            LicenseNo = string.Empty;
            Owner = string.Empty;
        }
        public string key { get; set; }
        public bool isValidID { get; set; }
        public bool isORCR { get; set; }
        public bool isDriverLicense { get; set; }
        public bool isInsurance { get; set; }
        public string ValidID { get; set; }
        public string ORCR { get; set; }
        public DateTime? DriverLicenseExpiry { get; set; }
        public DateTime? InsuranceExpiry { get; set; }
        public string LicenseNo { get; set; }
        public string Owner { get; set; }

    }
}