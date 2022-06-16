using AMS.Models;

namespace AMS.Repository
{
    public interface IMandalWithYuvakCountService
    {
        Task<IEnumerable<MandalWithYuvakCount>> GetAllMandal(int id);
    }
}
