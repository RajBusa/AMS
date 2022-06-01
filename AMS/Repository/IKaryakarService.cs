using AMS.web.Models;

namespace AMS.Repository
{
    public interface IKaryakarService
    {
        Task<IEnumerable<Karyakar>> GetAllKaryakar();

        Task<IEnumerable<Karyakar>> GetKaryakar(int id);

        Task<int> DeleteKaryakar(int id);

        Task<int> UpdateKaryakar(Karyakar karyakar);

        Task<int> InsertKaryakar(Karyakar karyakar);
    }
}
