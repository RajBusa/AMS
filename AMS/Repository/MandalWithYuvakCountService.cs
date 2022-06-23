using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class MandalWithYuvakCountService : IMandalWithYuvakCountService
    {
        protected readonly DbConnection _db;
        public MandalWithYuvakCountService(DbConnection db)
        {
            _db = db;
        }
        public async Task<IEnumerable<MandalWithYuvakCount>> GetMandal(int id, bool idNirikshak)
        {
            List<MandalWithYuvakCount> data = new List<MandalWithYuvakCount>();
            List<Mandal> mandals;
            int total;
            if (idNirikshak)
            {
                mandals = (List<Mandal>)await _db.QueryAsync<Mandal>("select * from Mandal where NirikshakId = @Id", new { @Id = id });
            }
            else
            {
                mandals = (List<Mandal>)await _db.QueryAsync<Mandal>("select * from Mandal where kshetraId = @Id", new { @Id = id });
            }
            foreach (Mandal mandal in mandals)
            {
               total = 0;
               total += await _db.ExecuteScalarAsync<int>("SELECT count(*) FROM Yuvak where MandalId = @id;", new{@id = mandal.Id,});
               total += await _db.ExecuteScalarAsync<int>("SELECT count(*) FROM Karyakar Where RoleId = 2  And Id in (SELECT KaryakarId FROM MandalKaryakar where MandalId = @id);", new{@id = mandal.Id,});
               MandalWithYuvakCount n = new MandalWithYuvakCount();
                n.numberYuvak = total;
                n.Name = mandal.Name;
                n.mandalId = mandal.Id;
                data.Add(n);
            }
            return data;
        }
    }
}
