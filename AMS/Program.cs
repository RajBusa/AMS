using AMS.Data;
using AMS.Models;
using AMS.Repo;
using AMS.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AMS");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //options.UseSqlServer(connectionString));
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<DbConnection>(sp =>
{
    var conn = new SQLiteConnection(builder.Configuration.GetConnectionString("AMS"));
    conn.Open();

    return conn;
});


//builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IKshetraService, KshetraService>();
builder.Services.AddScoped<IKaryakarService, KaryakarService>();
builder.Services.AddScoped<IMandalKaryakarService, MandalKaryakarService>();
builder.Services.AddScoped<IKshetraNirdeshakService, KshetraNirdeshakService>();
builder.Services.AddScoped<IMandalService, MandalService>();
builder.Services.AddScoped<ISabhaService, SabhaService>();
builder.Services.AddScoped<ISabhaAttendanceService, SabhaAttendanceService>();
builder.Services.AddScoped<IYuvakService, YuvakService>();
builder.Services.AddScoped<ITimerService, TimerService>();
builder.Services.AddScoped<INirikshakService, NirikshakService>();


builder.Services.AddControllers();



builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (option) =>
    {
        option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.UseCors("default");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;

app.Run();
