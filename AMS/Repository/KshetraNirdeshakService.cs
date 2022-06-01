using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class KshetraNirdeshakService : IKshetraNirdeshakService
    {

        protected readonly DbConnection _db;
        public KshetraNirdeshakService(DbConnection db)
        {
            _db = db;
        }

        public async Task<int> DeleteKshetraNirdeshak(int id)
        {
            var sql = "DELETE FROM KshetraNirdeshak WHERE id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = id,
            });
        }

        public async Task<IEnumerable<KshetraNirdeshak>> GetAllKshetraNirdeshak()
        {
            return await _db.QueryAsync<KshetraNirdeshak>("select * from KshetraNirdeshak");
        }

        public async Task<IEnumerable<KshetraNirdeshak>> GetKshetraNirdeshak(int id)
        {
            return await _db.QueryAsync<KshetraNirdeshak>("select * from KshetraNirdeshak where Id = @Id", new { @Id = id });
        }

        public async Task<int> InsertKshetraNirdeshak(KshetraNirdeshak kshetraNirdeshak)
        {
            var sql = "insert into KshetraNirdeshak (Id, KshetraId, NirdeshakId) values (NULL, @KshetraId, @NirdeshakId);";
            return await _db.ExecuteAsync(sql, new
            {
                @KshetraId = kshetraNirdeshak.KshetraId,
                @NirdeshakId = kshetraNirdeshak.NirdeshakId
            });
        }

        public async Task<int> UpdateKshetraNirdeshak(KshetraNirdeshak kshetraNirdeshak)
        {
            var sql = "Update KshetraNirdeshak set KshetraId = @KshetraId, NirdeshakId = @NirdeshakId where id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = kshetraNirdeshak.Id,
                @KshetraId = kshetraNirdeshak.KshetraId,
                @NirdeshakId = kshetraNirdeshak.NirdeshakId
            });

        }
    }
}
