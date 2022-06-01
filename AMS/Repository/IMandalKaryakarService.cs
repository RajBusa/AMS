using AMS.Models;
namespace AMS.Repository
{
    public interface IMandalKaryakarService
    {
        Task<IEnumerable<MandalKaryakar>> GetAllMandalKaryakar();
        Task<int> AddMandalKaryakar(MandalKaryakar mandalKaryakar);
        Task<int> UpdateMandalKaryakar(MandalKaryakar mandalKaryakar);
        Task<int> DeleteMandalKaryakar(int id);
    }
}
