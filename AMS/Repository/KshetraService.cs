using AMS.web.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class KshetraService : IKshetraService
    {
        protected readonly DbConnection _db;
        public KshetraService(DbConnection db)
        {
            _db = db;
        }
        public Task<IEnumerable<Kshetra>> GetAllKshetra()
        {
            return _db.QueryAsync<Kshetra>("select * from Kshetra");
        }
    }
}
