using AMS.Models;

namespace AMS.Repository
{
    public interface ISabhaAttendanceService
    {
        Task<IEnumerable<SabhaAttendance>> GetAllSabhaAttendance();

        Task<IEnumerable<SabhaAttendance>> GetSabhaAttendance(int id);

        Task<int> DeleteSabhaAttendance(int id);

        Task<int> UpdateSabhaAttendance(SabhaAttendance sabhaAttendance);

        Task<int> InsertSabhaAttendance(SabhaAttendance sabhaAttendance);
    }
}
