using AMS.Models;
using AMS.Repository;
using AMS.web.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repo
{
    public class MandalKaryakarService : IMandalKaryakarService
    {
        protected readonly DbConnection _db;
        public MandalKaryakarService(DbConnection db)
        {
            _db = db;
        }
        public async Task<int> AddMandalKaryakar(MandalKaryakar mandalKaryakar)
        {
            var sql = ("INSERT INTO MandalKaryakar (Id,MandalId,KaryakarId) VALUES (NULL,@MandalId,@KaryakarId)");
            return await _db.ExecuteAsync(sql, new { @MandalId = mandalKaryakar.MandalId, @KaryakarId = mandalKaryakar.KaryakarId });
        }

        public async Task<int> DeleteMandalKaryakar(int id)
        {
          return await _db.ExecuteAsync("DELETE FROM MandalKaryakar WHERE KaryakarId = @Id", new { @Id = id});
        }

        public Task<IEnumerable<MandalKaryakar>> GetAllMandalKaryakar()
        {
            return _db.QueryAsync<MandalKaryakar>("select * from MandalKaryakar");
        }

        public Task<IEnumerable<int>> getMandalId(int id)
        {
            return _db.QueryAsync<int>("select MandalId from MandalKaryakar where KaryakarId = @id", new { @id = id });
        }

        public async Task<int> UpdateMandalKaryakar(MandalKaryakar mandalKaryakar)
        {
            return  await _db.ExecuteAsync("UPDATE MandalKaryakar SET MandalId = @MandalId, KaryakarId = @KaryakarId WHERE Id = @Id", new { @MandalId = mandalKaryakar.MandalId, @KaryakarId = mandalKaryakar.KaryakarId, @Id = mandalKaryakar.Id });
        }
    }
}
