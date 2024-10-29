namespace TricyrideServerAdmin.Models
{
    public class ReportModel
    {
        public DateTime? Date { get; set; }
        public int TotalBookings { get; set; }
        public int ActiveDrivers { get; set; }
        public int ActiveCommuters { get; set; }
        public int CompletedRides { get; set; }
        public int CanceledBookings { get; set; }
        public decimal Revenue { get; set; }
        public float Ratings { get; set; }
    }
}