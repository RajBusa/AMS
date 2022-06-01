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
            var sql = "DELETE FROM Karyakar WHERE id = @id";
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

        public async Task<int> InsertKaryakar(Karyakar karyakar)
        {
            var sql = "insert into Karyakar (Id, Name, DOB, Address, MobileNo, Education, RoleId ,Email, Password, isActivated, KshetraId, KarayakarNo) values (NULL, @Name, @DOB, @Address, @MobileNo, @Education, @RoleId ,@Email, @Password, @isActivated, @KshetraId, @KarayakarNo);";
            return await _db.ExecuteAsync(sql, new 
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
