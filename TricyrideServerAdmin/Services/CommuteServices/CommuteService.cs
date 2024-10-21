using Firebase.Database;
using System.Linq;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.CommuteServices
{
    public class CommuteService : ICommuteService
    {
        private readonly FirebaseClient _firebaseClient;
        private readonly HttpClient _httpClient;
        public CommuteService()
        {
            _firebaseClient = new FirebaseClient("https://traysikol-f873d-default-rtdb.firebaseio.com");
            _httpClient = new HttpClient();
        }
        public async Task<List<CommuteModel>> GetCommutes()
        {
            var data = await _firebaseClient
                .Child("Commutes")
                .OnceAsync<CommuteModel>();

            return data.Select(d => new CommuteModel
            {
                Key = d.Object.Key,
                PassengerUid = d.Object.PassengerUid,
                DriverUid = d.Object.DriverUid,
                PassengerLatitude = d.Object.PassengerLatitude,
                PassengerLongitude = d.Object.PassengerLongitude,
                PassengerDestinationLatitude = d.Object.PassengerDestinationLatitude,
                PassengerDestinationLongitude = d.Object.PassengerDestinationLongitude,
                IsOccupied = d.Object.IsOccupied,
                CommuteStatus = d.Object.CommuteStatus,
                //CommuteDate = d.Object.CommuteDate,
                Distance = d.Object.Distance,
                Fare = d.Object.Fare,
                Time = d.Object.Time,
                Address1 = d.Object.Address1,
                Address2 = d.Object.Address2,
                Rating = d.Object.Rating
            }).ToList();
        }
    }
}
