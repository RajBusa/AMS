using AMS.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace AMS.Repository
{
    public class SabhaService : ISabhaService
    {
        protected readonly DbConnection _db;
        public SabhaService(DbConnection db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Sabha>> GetAllSabha()
        {
            return await _db.QueryAsync<Sabha>("select * from Sabha");
        }
        public async Task<IEnumerable<Sabha>> GetSabhaById(int id)
        {
            return await _db.QueryAsync<Sabha>("select * from Sabha Where Id = @Id", new { @Id = id });
        }

        public async Task<int> GetSabhaByMandalId(int id)
        {
            return await _db.ExecuteScalarAsync<int>("SELECT count(*) FROM Sabha where MandalId = @id AND SabhaDate BETWEEN datetime('now','-1 month') AND datetime('now');", new { @id = id });
        }

        public async Task<int> InsertSabha(Sabha sabha)
        {
            var sql = ("INSERT INTO Sabha (Id,MandalId,Date) VALUES (NULL,@MandalId,@Date)");
            return await _db.ExecuteAsync(sql, new { @MandalId = sabha.MandalId, @Date = sabha.SabhaDate});
        }
        public async Task<int> UpdateSabha(Sabha sabha)
        {
            var sql = ("UPDATE Sabha SET MandalId = @MandalId,Date = @Date WHERE Id = @id");
            return await _db.ExecuteAsync(sql, new { @MandalId = sabha.MandalId, @Date = sabha.SabhaDate, @id = sabha.Id});
        }
    }
}
