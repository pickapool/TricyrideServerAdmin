using Microsoft.AspNetCore.Routing.Internal;

namespace TricyrideServerAdmin.Models
{
    public class CommuteDateModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public long time { get ; set; }
        public int TimezoneOffset { get; set; } // Offset in minutes

        // Returns the DateTime based on the properties
        public DateTime? ToDateTime()
        {
            try {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(time);
            } catch(Exception ee) {
                return null;
            }
        }
    }
}
