namespace TricyrideServerAdmin.Models
{
    public class PassengerRoute
    {
        public List<List<double>> PassengerRouteList { get; set; }

        public PassengerRoute()
        {
            PassengerRouteList = new List<List<double>>();
        }

        public PassengerRoute(List<List<double>> passengerRoute)
        {
            PassengerRouteList = passengerRoute;
        }
    }
}
