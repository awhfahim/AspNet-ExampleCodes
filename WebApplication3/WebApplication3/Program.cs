using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Email(new EmailConnectionInfo
    {
        FromEmail = "mhdmi****a24@gmail.com",
        ToEmail = "fahimhasan314@gmail.com",
        MailServer = "smtp.gmail.com",
        NetworkCredentials = new NetworkCredential
        {
            UserName = "mhdmia24@gmail.com",
            Password = "************"
        },
        EnableSsl = true,
        Port = 465,
        EmailSubject = "LogError"
    },
    restrictedToMinimumLevel: LogEventLevel.Debug,
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
));

try
{
    

    // Add services to the container.
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

    Log.Information("application Started");
    //int a = int.Parse("dfdf");
    app.Run();
    
}
catch(Exception ex)
{
    Log.Fatal(ex, "Error Occured");
}
finally
{
    Log.CloseAndFlush();
}
