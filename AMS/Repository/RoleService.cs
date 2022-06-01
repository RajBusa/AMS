using AMS.web.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class RoleService : IRoleService
    {
       

        protected readonly DbConnection _db;
        public RoleService(DbConnection db)
        {
            _db = db;
        }

        public Task<IEnumerable<KaryakarRole>> GetAllRoles()
        {
            return _db.QueryAsync<KaryakarRole>("select * from KarayakarRole");
            
        }

        public async Task<int>  InsertKaryakarRole(KaryakarRole role)
        {
            var sql = "insert into KarayakarRole values (NULL, @role);";
            return await _db.ExecuteAsync(sql, new
            {
                @role = role.RoleName
            });
        }

        public async Task<int> DeleteYuvak(int id)
        {
            var sql = "DELETE FROM KarayakarRole WHERE id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = id,
            });
        }

        public async Task<int> UpdateKaryakar(KaryakarRole role)
        {
            var sql = "Update KarayakarRole set RoleName = @roleName where id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = role.Id,
                @roleName = role.RoleName,
            });

        }

    }
}
