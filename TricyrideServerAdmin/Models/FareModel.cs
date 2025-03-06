using System.Text.Json.Serialization;
using static TricyrideServerAdmin.Enums.Enum;

namespace TricyrideServerAdmin.Models
{
    public class FareModel
    {
        public double StudentFare { get; set; }
        public double RegularFare { get; set; }
        public double StudentKM { get; set; }
        public double RegularKM { get; set; }
    }
}