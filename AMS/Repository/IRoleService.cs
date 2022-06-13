using AMS.web.Models;

namespace AMS.Repository
{
    public interface IRoleService
    {
        Task<IEnumerable<KaryakarRole>> GetAllRoles();

        Task<IEnumerable<int>> InsertKaryakarRole(KaryakarRole role);
        Task<int> DeleteYuvak(int id);

        Task<int> UpdateKaryakar(KaryakarRole role);

    }
}
