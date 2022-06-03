﻿using AMS.Models;
using Dapper;
using System.Data.Common;

namespace AMS.Repository
{
    public class YuvakService : IYuvakService
    {
        protected readonly DbConnection _db;
        public YuvakService(DbConnection db)
        {
            _db = db;
        }

        public async Task<int> DeleteYuvak(int id)
        {
            return await _db.ExecuteAsync("DELETE FROM Yuvak WHERE id = @id", new
            {
                @id = id,
            });
        }

        public async Task<IEnumerable<Yuvak>> GetAllYuvak()
        {
            return await _db.QueryAsync<Yuvak>("select * from Yuvak");
        }

        public async Task<IEnumerable<Yuvak>> GetYuvak(int id)
        {
            return await _db.QueryAsync<Yuvak>("select * from Yuvak where Id = @Id", new { @Id = id });
        }

        //public async Task<IEnumerable<Yuvak>> GetYuvakById(int id)
        //{
        //    return await _db.QueryAsync<Yuvak>("select * from Yuvak where SamparkId = @Id", new { @Id = id });
        //}

        public async Task<IEnumerable<LastMonthSabha>> GetYuvakById(int id)
        {
            
            List<LastMonthSabha> data = new List<LastMonthSabha>();
            List<Yuvak> yuvaks = (List<Yuvak>) await _db.QueryAsync<Yuvak>("select * from Yuvak where SamparkId = @Id", new { @Id = id });
            foreach (Yuvak item in yuvaks)
            {
            LastMonthSabha lastMonthSabha = new LastMonthSabha();
                int count = await _db.ExecuteScalarAsync<int>("select count(*) from sabhaattendance where yuvakid = @id", new
                {
                    @id = item.Id,
                });
                lastMonthSabha.Name = item.Name;
                lastMonthSabha.Address = item.Address;
                lastMonthSabha.Email = item.Email;
                lastMonthSabha.Education = item.Education;
                lastMonthSabha.DOB = item.DOB;
                lastMonthSabha.Mobile = item.Mobile;
                lastMonthSabha.MandalId = item.MandalId;
                lastMonthSabha.SamparkId = item.SamparkId;
                lastMonthSabha.count = count;
                data.Add(lastMonthSabha);
                lastMonthSabha = null;
            }
            return data;
        }

        public async Task<int> InsertYuvak(Yuvak yuvak)
        {
            var sql = "insert into Yuvak values (NULL, @Name, @DOB, @Address, @Mobile, @Education, @Email ,@MandalId, @SamparkId);";
            return await _db.ExecuteAsync(sql, new
            {
                @Name = yuvak.Name,
                @DOB = yuvak.DOB,
                @Address = yuvak.Address,
                @Mobile = yuvak.Mobile,
                @Education = yuvak.Education,
                @Email = yuvak.Email,
                @MandalId = yuvak.MandalId,
                @SamparkId = yuvak.SamparkId
            });
        }

        public async Task<int> UpdateYuvak(Yuvak yuvak)
        {
            var sql = "Update Yuvak set Name = @Name, DOB = @DOB, Address = @Address, Mobile = @Mobile, Education = @Education, Email = @Email, MandalId = @MandalId, SamparkId = @SamparkId where id = @id";
            return await _db.ExecuteAsync(sql, new
            {
                @id = yuvak.Id,
                @Name = yuvak.Name,
                @DOB = yuvak.DOB,
                @Address = yuvak.Address,
                @Mobile = yuvak.Mobile,
                @Education = yuvak.Education,
                @Email = yuvak.Email,
                @MandalId = yuvak.MandalId,
                @SamparkId = yuvak.SamparkId
            });
        }
    }
    
}