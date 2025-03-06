using System.Text.Json.Serialization;
using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class FareModel
    {
        public double studentFare { get; set; }
        public double regularFare { get; set; }
        public double studentKM { get; set; }
        public double regularKM { get; set; }
    }
}