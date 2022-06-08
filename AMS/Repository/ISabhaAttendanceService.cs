using AMS.Models;

namespace AMS.Repository
{
    public interface ISabhaAttendanceService
    {
        Task<IEnumerable<SabhaAttendance>> GetAllSabhaAttendance();

        Task<IEnumerable<SabhaAttendance>> GetSabhaAttendance(int id);

        Task<int> DeleteSabhaAttendance(int yid, int sid);

        Task<int> InsertSabhaAttendance(SabhaAttendance sabhaAttendance);

        Task<int> LastMonthSabha(int id);
        Task<int> ExistAttendance(int yid,int sid);

    }
}
