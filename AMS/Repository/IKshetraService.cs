using AMS.web.Models;

namespace AMS.Repository
{
    public interface IKshetraService
    {
        Task<IEnumerable<Kshetra>> GetAllKshetra();
    }
}
