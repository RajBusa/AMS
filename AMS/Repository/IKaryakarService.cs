using AMS.Models;
using AMS.web.Models;

namespace AMS.Repository
{
    public interface IKaryakarService
    {
        Task<IEnumerable<Karyakar>> GetAllKaryakar();

        Task<IEnumerable<Karyakar>> GetKaryakar(int id);
        Task<IEnumerable<Karyakar>> GetSanchalak(int mId);

        Task<IEnumerable<SamparKaryakar>> GetSamparKaryakars(int Id);

        Task<int> DeleteKaryakar(int id);

        Task<int> UpdateKaryakar(Karyakar karyakar);

        Task<IEnumerable<int>> InsertKaryakar(Karyakar karyakar);
        Task<IEnumerable<Extra>> GetAllYuvaks(int id);

        Task<int> InsertKaryakarFromYuvakId(int yId);
    }
}
