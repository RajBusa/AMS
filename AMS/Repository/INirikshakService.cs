using AMS.Models;

namespace AMS.Repository
{
    public interface INirikshakService
    {
        Task<IEnumerable<Nirikshak>> GetAllMandal(int id);
    }
}
