using AMS.Models;

namespace AMS.Repository
{
    public interface ISabhaService
    {
        Task<IEnumerable<Sabha>> GetAllSabha();
        Task<IEnumerable<Sabha>> GetSabhaById(int id);
        Task<int> InsertSabha(Sabha sabha);
        Task<int> UpdateSabha(Sabha sabha);


    }
}
