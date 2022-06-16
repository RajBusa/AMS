using AMS.Models;
using AMS.web.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class KaryakarService : IKaryakarService
    {
        protected readonly DbConnection _db;
        public KaryakarService(DbConnection db)
        {
            _db = db;
        }

        public async Task<int> DeleteKaryakar(int id)
        {
            var sql = "DELETE FROM Karyakar WHERE Id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = id,
            });
        }

        public async Task<IEnumerable<Karyakar>> GetAllKaryakar()
        {
            return await _db.QueryAsync<Karyakar>("select * from Karyakar");

        }

        public async Task<IEnumerable<Karyakar>> GetKaryakar(int id)
        {
            return await _db.QueryAsync<Karyakar>("select * from Karyakar where Id = @Id", new { @Id = id });
        }

        public async Task<IEnumerable<SamparKaryakar>> GetSamparKaryakars(int mId)
        {
            return await _db.QueryAsync<SamparKaryakar>("SELECT Id, Name from Karyakar where RoleId = 1 AND Id in (SELECT KaryakarId FROM MandalKaryakar where MandalId = @mId);", new { @mId = mId });
        }

        public async Task<IEnumerable<Karyakar>> GetSanchalak(int mId)
        {
            return await _db.QueryAsync<Karyakar>("SELECT * from Karyakar where RoleId = 2 AND Id in (SELECT KaryakarId from MandalKaryakar WHERE MandalId = @mId)", new { @mId = mId });
        }

        public async Task<IEnumerable<int>> InsertKaryakar(Karyakar karyakar)
        {
            Console.WriteLine("INserted call");
            var sql = "insert into Karyakar (Id, Name, DOB, Address, MobileNo, Education, RoleId ,Email, Password, isActivated, KshetraId, KarayakarNo) values (NULL, @Name, @DOB, @Address, @MobileNo, @Education, @RoleId ,@Email, @Password, @isActivated, @KshetraId, @KarayakarNo); select last_insert_rowid();";
            return await _db.QueryAsync<int>(sql, new
            {
                @Name = karyakar.Name,
                @DOB = karyakar.DOB,
                @Address = karyakar.Address,
                @MobileNo = karyakar.MobileNo,
                @Education = karyakar.Education,
                @RoleId = karyakar.RoleId,
                @Email = karyakar.Email,
                @Password = karyakar.Password,
                @isActivated = karyakar.isActivated,
                @KshetraId = karyakar.KshetraId,
                @KarayakarNo = karyakar.KarayakarNo
            });
        }

        public async Task<int> UpdateKaryakar(Karyakar karyakar)
        {
            var sql = "Update Karyakar set Name = @Name, DOB = @DOB, Address = @Address, MobileNo = @MobileNo, Education = @Education, RoleId = @RoleId, Email = @Email, Password = @Password, isActivated = @isActivated, KshetraId = @KshetraId,KarayakarNo = @KarayakarNo where id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = karyakar.Id,
                @Name = karyakar.Name,
                @DOB = karyakar.DOB,
                @Address = karyakar.Address,
                @MobileNo = karyakar.MobileNo,
                @Education = karyakar.Education,
                @RoleId = karyakar.RoleId,
                @Email = karyakar.Email,
                @Password = karyakar.Password,
                @isActivated = karyakar.isActivated,
                @KshetraId = karyakar.KshetraId,
                @KarayakarNo = karyakar.KarayakarNo
            });
        }
    }
}
