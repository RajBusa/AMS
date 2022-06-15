using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class NirikshakService : INirikshakService
    {
        protected readonly DbConnection _db;
        public NirikshakService(DbConnection db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Nirikshak>> GetAllMandal(int id)
        {
            List<Nirikshak> data = new List<Nirikshak>();
            List<Mandal> mandals;
            int total;
            mandals = (List<Mandal>)await _db.QueryAsync<Mandal>("select * from Mandal where NirikshakId = @Id", new { @Id = id });
            foreach (Mandal mandal in mandals)
            {
               total = 0;
               total += await _db.ExecuteScalarAsync<int>("SELECT count(*) FROM Yuvak where MandalId = @id;", new{@id = mandal.Id,});
               total += await _db.ExecuteScalarAsync<int>("SELECT count(*) FROM Karyakar Where RoleId = 2  And Id in (SELECT KaryakarId FROM MandalKaryakar where MandalId = @id);", new{@id = mandal.Id,});
               Nirikshak n = new Nirikshak();
                n.numberYuvak = total;
                n.Name = mandal.Name;
                data.Add(n);
            }
            return data;
        }
    }
}
