using AMS.Models;
using AMS.web.Models;

namespace AMS.Repository
{
    public interface IKaryakarService
    {
        Task<IEnumerable<Karyakar>> GetAllKaryakar();

        Task<IEnumerable<Karyakar>> GetKaryakar(int id);

        Task<IEnumerable<SamparKaryakar>> GetSamparKaryakars(int mId);

        Task<int> DeleteKaryakar(int id);

        Task<int> UpdateKaryakar(Karyakar karyakar);

        Task<IEnumerable<int>> InsertKaryakar(Karyakar karyakar);
        Task<IEnumerable<Extra>> GetAllYuvaks(int id);
    }
}
