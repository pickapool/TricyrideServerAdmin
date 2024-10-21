using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.CommuteServices
{
    public interface ICommuteService
    {
        Task<List<CommuteModel>> GetCommutes();
    }
}
