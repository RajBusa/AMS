using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class SabhaAttendanceService : ISabhaAttendanceService
    {
        protected readonly DbConnection _db;
        public SabhaAttendanceService(DbConnection db)
        {
            _db = db;
        }

        public async Task<int> DeleteSabhaAttendance(int id)
        {
            var sql = "DELETE FROM SabhaAttendance WHERE id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = id,
            });
        }

        public async Task<IEnumerable<SabhaAttendance>> GetAllSabhaAttendance()
        {
            return await _db.QueryAsync<SabhaAttendance>("select * from SabhaAttendance");
        }

        public async Task<IEnumerable<SabhaAttendance>> GetSabhaAttendance(int id)
        {
            return await _db.QueryAsync<SabhaAttendance>("select * from SabhaAttendance where Id = @Id", new { @Id = id });
        }

        public async Task<int> InsertSabhaAttendance(SabhaAttendance sabhaAttendance)
        {
            var sql = "insert into SabhaAttendance values (NULL, @YuvakId, @SabhaId, @Attendance);";
            return await _db.ExecuteAsync(sql, new
            {
                @YuvakId = sabhaAttendance.YuvakId,
                @SabhaId = sabhaAttendance.SabhaId,
                @Attendance = sabhaAttendance.Attendance

            });
        }

        public async Task<int> UpdateSabhaAttendance(SabhaAttendance sabhaAttendance)
        {
            var sql = "Update SabhaAttendance set YuvakId = @YuvakId, SabhaId = @SabhaId, Attendance = @Attendance  where id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = sabhaAttendance.Id,
                @YuvakId = sabhaAttendance.YuvakId,
                @SabhaId = sabhaAttendance.SabhaId,
                @Attendance = sabhaAttendance.Attendance
            }); ;
        }
    }
}
