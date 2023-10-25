using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Diagnostics;
using System.Net;
using WebApplication2;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

//Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

//builder.Host.UseSerilog((ctx, lc) => lc
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    .ReadFrom.Configuration(builder.Configuration));


Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{

    Log.Information("Application Started");

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
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
    app.MapRazorPages();

    int a = 3, b = 0;
    int c = a / b;
    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Failed to start application.");
}
finally
{
    Log.CloseAndFlush();
}