using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class TimerService : ITimerService
    {
        protected readonly DbConnection _db;
        public TimerService(DbConnection db)
        {
            _db = db;
        }
        public  async Task<IEnumerable<int>> AddDate()
        {
            Console.WriteLine("AddDate");
            //await _db.ExecuteScalarAsync<int>("insert into KarayakarRole values (NULL, 'mala');");
            //throw new NotImplementedException();
            // return Task.FromResult(0);
            //await _db.ExecuteScalarAsync<int>("insert into KarayakarRole values (NULL, 'mala');");
            await _db.ExecuteScalarAsync<int>("UPDATE Yuvak set isAttendanceTaken  = False where MandalId in (SELECT MandalId FROM Sabha where SabhaDate = date('now', 'localtime' ,'-1 Day'));");
            IEnumerable<int> lis =  await _db.QueryAsync<int>("SELECT Id FROM Mandal WHERE Day = strftime('%w','now');");
            foreach (int i in lis)
            {
              await _db.ExecuteScalarAsync<int>("INSERT into Sabha values (NULL, @id,date('now', 'localtime' ,'+6 Day'));", new {@id = i});
            }
            
            return await _db.QueryAsync<int>("SELECT Id FROM Mandal WHERE Day = strftime('%w','now');");
        }
    }
}