using AMS.Models;

namespace AMS.Repository
{
    public interface IMandalService
    {
        Task<IEnumerable<Mandal>> GetAllMandal();
        Task<IEnumerable<Mandal>> GetMandalById(int id);

        Task<IEnumerable<string>> GetMandalName(int id);

        Task<int> InsertMandal(Mandal mandal);
        Task<int> DeleteMandal(int id);

        Task<int> UpdateMandal(Mandal mandal);
    }
}
