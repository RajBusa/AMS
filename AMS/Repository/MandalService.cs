using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class MandalService : IMandalService
    {
        protected readonly DbConnection _db;
        public MandalService(DbConnection db)
        {
            _db = db;
        }
        public async Task<int> DeleteMandal(int id)
        {
            return await _db.ExecuteAsync("DELETE FROM Mandal WHERE Id = @Id", new { @Id = id });
        }

        public async Task<IEnumerable<Mandal>> GetAllMandal()
        {
            return await _db.QueryAsync<Mandal>("select * from Mandal");
        }
        public async Task<IEnumerable<Mandal>> GetMandalById(int id)
        {
            return await _db.QueryAsync<Mandal>("select * from Mandal Where Id = @Id", new {@Id = id});
        }

        public async Task<IEnumerable<string>> GetMandalName(int id)
        {
            return await _db.QueryAsync<string>("select name from Mandal Where Id = @Id", new { @Id = id });
        }

        public async Task<int> InsertMandal(Mandal mandal)
        {
            var sql = ("INSERT INTO Mandal (Id,Name,Address,Area,NirikshakId,KshetraId,Day) VALUES (NULL,@Name,@Address,@Area,@NirikshakId,@KshetraId,@Day)");
            return await _db.ExecuteAsync(sql, new {@Name = mandal.Name, @Address = mandal.Address, @Area = mandal.Area, @NirikshakId = mandal.NirikshakId,@KshetraId = mandal.KshetraId, @Day = mandal.Day});
        }

        public async Task<int> UpdateMandal(Mandal mandal)
        {
            var sql = ("UPDATE Mandal SET Name = @Name, Address = @Address, Area = @Area, NirikshakId = @NirikshakId,KshetraId = @KshetraId,Day = @Day Where Id = @id");
            return await _db.ExecuteAsync(sql, new { @Name = mandal.Name, @Address = mandal.Address, @Area = mandal.Area, @NirikshakId = mandal.NirikshakId, @KshetraId = mandal.KshetraId, @Day = mandal.Day, @id = mandal.Id});
        }
    }
}
