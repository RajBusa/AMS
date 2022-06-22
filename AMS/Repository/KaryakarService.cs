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

        public async Task<IEnumerable<Karyakar>> GetKaryakarByEmailId(string emailId)
        {
            return await _db.QueryAsync<Karyakar>("select * from Karyakar where email = @email", new { @email = emailId });
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

        public async Task<IEnumerable<Extra>> GetAllYuvaks(int id)
        {
            List<Extra> data = new List<Extra>();
            List<SamparKaryakar> sk;
            List<yuvakEdited>? yuvaks = new List<yuvakEdited>();
            sk = (List<SamparKaryakar>)await _db.QueryAsync<SamparKaryakar>("SELECT Id,Name FROM Karyakar Where RoleId = 1  And Id in (SELECT KaryakarId FROM MandalKaryakar where MandalId = @id);", new { @id = id, });
            Console.WriteLine("Hi2");
            Console.WriteLine(sk[0].name);
            Console.WriteLine(sk[1].name);
            yuvaks = (List<yuvakEdited>)await _db.QueryAsync<yuvakEdited>("SELECT Id,Name,SamparkId FROM Yuvak Where SamparkId = @id;", new { @id = 0, });
            if (yuvaks.Count > 0)
            {
                Console.WriteLine(yuvaks.Count);
                Extra n = new Extra();
                n.sId = 0;
                n.sName = "Unassigned";
                n.yuvaks = yuvaks;
                data.Add(n);
            }
            foreach (SamparKaryakar s in sk)
            {
                Extra n = new Extra();
                yuvaks = null;
                yuvaks = (List<yuvakEdited>)await _db.QueryAsync<yuvakEdited>("SELECT Id,Name,SamparkId FROM Yuvak Where SamparkId = @id  And isSamparkKaryakar = 0;", new { @id = s.Id, });
                n.sId = s.Id;
                n.sName = s.name;
                n.yuvaks = yuvaks;
                if (yuvaks.Count > 0)
                {
                data.Add(n);
                }
            }
            return data;
        }

        public async Task<int> InsertKaryakarFromYuvakId(int[] yId)
        {
            List<Yuvak>? yuvaks = new List<Yuvak>();

            for (int i = 0; i < yId.Length; i++)
            {
                yuvaks = (List<Yuvak>)await _db.QueryAsync<Yuvak>("select * from Yuvak where Id = @Id", new { @Id = yId[i] });

                IEnumerable<int> kshetraId = await _db.QueryAsync<int>("select KshetraId from Mandal where Id = @id", new { @id = yuvaks[0].MandalId });

                var sql = "insert into Karyakar (Id, Name, DOB, Address, MobileNo, Education, RoleId ,Email, Password, isActivated, KshetraId, KarayakarNo) values (NULL, @Name, @DOB, @Address, @MobileNo, @Education, @RoleId ,@Email, @Password, @isActivated, @KshetraId, @KarayakarNo); select last_insert_rowid();";


                IEnumerable<int> karyakarId = await _db.QueryAsync<int>(sql, new
                {
                    @Name = yuvaks[0].Name,
                    @DOB = yuvaks[0].DOB,
                    @Address = yuvaks[0].Address,
                    @MobileNo = yuvaks[0].Mobile,
                    @Education = yuvaks[0].Education,
                    @RoleId = 1,
                    @Email = yuvaks[0].Email,
                    @Password = ' ',
                    @isActivated = 0,
                    @KshetraId = kshetraId,
                    @KarayakarNo = 0
                });


                await _db.ExecuteAsync("INSERT INTO MandalKaryakar (Id,MandalId,KaryakarId) VALUES (NULL,@MandalId,@KaryakarId)", new { @MandalId = yuvaks[0].MandalId, @KaryakarId = karyakarId });

                await _db.ExecuteAsync("Update Yuvak set SamparkId = @SamparkId, isSamparkKaryakar = 1 where id = @id", new { @id = yId[i], @SamparkId = karyakarId });
            }
            return yId.Length;
        }

        public async Task<int> SignIn(SignIn signIn)
        {
            List<int> id;
            id = (List<int>)await _db.QueryAsync<int>("select id from karyakar where email = @email", new { @email = signIn.Email });
            //Console.WriteLine(id[0]);
            Console.WriteLine(id.Count());
            if(id.Count() == 1)
            {
                List<int> isActivated = (List<int>)await _db.QueryAsync<int>("select isActivated from karyakar where id = @id", new { @id = id });
                if(isActivated[0] == 1)
                {
                    Console.WriteLine("IsActivated");
                    List<string> pass = (List<string>)await _db.QueryAsync<string>("select password from karyakar where id = @id", new { @id = id });
                    if(BCrypt.Net.BCrypt.Verify(signIn.Password, pass[0]))
                    {
                        return id[0];
                    }
                    else
                    {
                        return (-2);
                    }
                }
                else
                {
                    Console.WriteLine("NotActivated");
                    return (-1);
                }

            }
            return 0;
            //Console.WriteLine(id);
            //return 0; == email id not exist
            //retutn -1; == isActivated == 0
            //return -2; == password incorrect
            //return -3; == Success full signIn
        }

        public async Task<int> changePassword(SignIn signIn)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(signIn.Password);

            Console.WriteLine(passwordHash);
            List<int> isActivated = (List<int>)await _db.QueryAsync<int>("select isActivated from karyakar where email = @email", new { @email = signIn.Email });
            if (isActivated[0] == 0)
            {
                return await _db.ExecuteAsync("Update Karyakar set Password = @Password, isActivated = 1 where email = @email", new { @email = signIn.Email, @Password = passwordHash});
            }
            return -1;
        }
    }
}
