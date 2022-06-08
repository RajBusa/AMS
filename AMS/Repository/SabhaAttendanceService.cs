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

        public async Task<int> DeleteSabhaAttendance(int yid, int sid)
        {
            var sql = "DELETE FROM SabhaAttendance WHERE YuvakId = @yid AND SabhaId = @sid";
            return await _db.ExecuteAsync(sql, new
            {
                @yid = yid,
                sid = sid,
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
            //var sql = "insert into SabhaAttendance values (NULL, @YuvakId, @SabhaId, @Attendance);";
            var sql = "insert into SabhaAttendance values (NULL, @YuvakId, @SabhaId, datetime('now', 'localtime'));";
            return await _db.ExecuteAsync(sql, new
            {
                @YuvakId = sabhaAttendance.YuvakId,
                @SabhaId = sabhaAttendance.SabhaId,
                //@Attendance = sabhaAttendance.Attendance
            });
        }

        //public async Task<int> UpdateSabhaAttendance(SabhaAttendance sabhaAttendance)
        //{
        //    var sql = "Update SabhaAttendance set YuvakId = @YuvakId, SabhaId = @SabhaId, Attendance = @Attendance  where id = @id";
        //    return await _db.ExecuteAsync(sql, new
        //    {
        //        @id = sabhaAttendance.Id,
        //        @YuvakId = sabhaAttendance.YuvakId,
        //        @SabhaId = sabhaAttendance.SabhaId,
        //        @Attendance = sabhaAttendance.Attendance
        //    }); ;
        //}

        public async Task<int> ExistAttendance(int yid, int sid)
        {
            var sql = "SELECT count(*) FROM SabhaAttendance where YuvakId = @yid AND SabhaId = @sid";
            return await _db.ExecuteScalarAsync<int>(sql, new
            {
                @yid = yid,
                @sid = sid,
            }) ;
        }
        public async Task<int> LastMonthSabha(int id)
        {
            //var sql = "SELECT count(*) FROM SabhaAttendance where YuvakId = @id AND Attendance BETWEEN datetime('now', 'localtime', '-1 month') AND datetime('now', 'localtime');";
            //var sql = "SELECT count(YuvakId) FROM SabhaAttendance where (YuvakId = @id) AND (Attendance BETWEEN '2022-05-02  17:00:00' AND '2022-06-02 17:00:00');";
            var sql = "SELECT count(*) FROM SabhaAttendance where YuvakId = @id";
            return await _db.ExecuteScalarAsync<int>(sql, new
            {
                @id = id

            });
        }
    }
}
