using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using PegassusBooking.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using PegassusBooking.Utilities;
using PegassusBooking.Repositories.Interfaces;
using PegassusBooking.Repositories.Implementations;
using Microsoft.AspNetCore.Identity.UI.Services;
using PegassusBooking.Models;
using PegassusBooking.Services;
using PegassusBooking.Web.Areas.Identity.Pages.Account;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//var connectionString = "server=localhost;user=root;password=Qw@rty8457;database=peggassus";
//var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

/*
builder.Services.AddDbContext<ApplicationDBContext>(dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));*/
builder.Services.AddCloudscribePagination();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserService>();
builder.Services.AddScoped<HospitalService>();
builder.Services.AddScoped<LoginModel>();
builder.Services.AddScoped<IAppointment, AppointmentService>();
builder.Services.AddTransient<IHospital, HospitalService>();
builder.Services.AddTransient<IRoom, RoomService>();
builder.Services.AddTransient<IContact, ContactService>();
builder.Services.AddRazorPages();

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
DataSedding();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}"
    );
});

app.Run();
void DataSedding()
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.
        GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}
