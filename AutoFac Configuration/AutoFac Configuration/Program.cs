using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoFac_Configuration;
using AutoFac_Configuration.Data;
using AutoFac_Configuration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

#region Serilog Configurations
//var logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    .ReadFrom.Configuration(builder.Configuration)
//    .CreateLogger();

//builder.Host.UseSerilog((ctx, lc) => lc
//               .MinimumLevel.Error()
//              .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//              .Enrich.FromLogContext()
//              .WriteTo.Email(new EmailConnectionInfo
//              {
//                  FromEmail = "fahimhasan314@gmail.com",
//                  ToEmail = "Papercut@user.com",
//                  MailServer = "localhost",
//                  //NetworkCredentials = new NetworkCredential
//                  //{
//                  //    UserName = "user",
//                  //    Password = "pass"
//                  //},
//                  //EnableSsl = true,
//                  Port = 25,
//                  EmailSubject = "Error in app"
//              }));

//var Emaillogger = new LoggerConfiguration()
//    .WriteTo.Email(new EmailConnectionInfo
//    {
//        FromEmail = "user@papercut.com",
//        ToEmail = "Papercut@user.com",
//        MailServer = "localhost",
//        Port = 25
//    }).CreateLogger();

//builder.Host.UseSerilog(Emaillogger);

#endregion

try
{
    Log.Information("Application Starting...");

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule());
    });


    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    //builder.Services.AddSingleton<IEmailSender, HtmlEmailSender>();

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

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start application.");
}
finally
{
    Log.CloseAndFlush();
}
