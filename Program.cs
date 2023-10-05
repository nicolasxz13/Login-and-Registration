using Microsoft.EntityFrameworkCore;
using Login_and_Registration.Data;

var builder = WebApplication.CreateBuilder(args);

// Add our service
builder.Services.AddControllersWithViews();

//session
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<LoginContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
