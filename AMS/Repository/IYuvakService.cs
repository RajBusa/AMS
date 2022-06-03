using AMS.Models;

namespace AMS.Repository
{
    public interface IYuvakService
    {
        Task<IEnumerable<Yuvak>> GetAllYuvak();

        Task<IEnumerable<Yuvak>> GetYuvak(int id);
        Task<IEnumerable<LastMonthSabha>> GetYuvakById(int id, bool isMandal);

        Task<int> DeleteYuvak(int id);

        Task<int> UpdateYuvak(Yuvak yuvak);

        Task<int> InsertYuvak(Yuvak yuvak);
    }
}
