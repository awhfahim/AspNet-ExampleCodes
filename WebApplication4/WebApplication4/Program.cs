using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Net;
using WebApplication4.Data;

var builder = WebApplication.CreateBuilder(args);

Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

builder.Host.UseSerilog((ctx, lc) => lc
.MinimumLevel.Verbose()
.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
.ReadFrom.Configuration(ctx.Configuration)
.WriteTo.Console()
.WriteTo.Email(new EmailConnectionInfo
{
    FromEmail = "mhdmia*****@gmail.com",
    ToEmail = "fahimhasan314@gmail.com",
    MailServer = "smtp.gmail.com",
    NetworkCredentials = new NetworkCredential
    {
        UserName = "mhdmia24@gmail.com",
        Password = "********"
    },
    EnableSsl = true,
    Port = 465,
    EmailSubject = "LogError"
},
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
));

try
{
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

    Log.Information("Application Started");
    int a = int.Parse("dfsdf");
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "There is an Error");
}
finally
{
    Log.CloseAndFlush();
}