using AMS.Models;
using AMS.web.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AMS.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Karyakar> Karyakar { get; set; }
        public DbSet<Kshetra> Kshetra { get; set; }
        public DbSet<Mandal> Mandal { get; set; }
        public DbSet<KaryakarRole> KarayakarRole { get; set; }
        public DbSet<Sabha> Sabha { get; set; }
        public DbSet<SabhaAttendance> SabhaAttendance { get; set; }
        public DbSet<KshetraNirdeshak> KshetraNirdeshak { get; set; }
        public DbSet<MandalKaryakar> MandalKaryakar { get; set; }
        public DbSet<Yuvak> Yuvak { get; set; }
    }
}