using AMS.Models;

namespace AMS.Repository
{
    public interface IYuvakService
    {
        Task<IEnumerable<Yuvak>> GetAllYuvak();

        Task<IEnumerable<Yuvak>> GetYuvak(int id);

        Task<int> DeleteYuvak(int id);
        
        Task<int> UpdateYuvak(Yuvak yuvak);

        Task<int> InsertYuvak(Yuvak yuvak);
    }
}
