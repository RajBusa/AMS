using AMS.web.Models;

namespace AMS.Repository
{
    public interface IRoleService
    {
        Task<IEnumerable<KaryakarRole>> GetAllRoles();

        Task<int> InsertKaryakarRole(KaryakarRole role);
        Task<int> DeleteYuvak(int id);

        Task<int> UpdateKaryakar(KaryakarRole role);

    }
}
