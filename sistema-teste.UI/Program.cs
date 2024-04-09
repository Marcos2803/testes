using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sistema_teste.Data.Context;
using sistema_teste.Domain.Entities.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(strConnection);
});

builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    option.SignIn.RequireConfirmedAccount = true;
    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Password.RequiredLength = 6;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
