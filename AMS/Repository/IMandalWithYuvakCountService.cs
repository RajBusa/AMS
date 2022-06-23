using AMS.Models;

namespace AMS.Repository
{
    public interface IMandalWithYuvakCountService
    {
        Task<IEnumerable<MandalWithYuvakCount>> GetMandal(int id, bool isNirikshak);
    }
}
