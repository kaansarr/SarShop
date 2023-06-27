using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SarShop.BL.Repositories;
using SarShop.DAL.Contexts;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/admin/login";
    opt.LogoutPath = "/admin/logout";

});


var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseStatusCodePagesWithRedirects("/hata/{0}");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");


app.Run();
