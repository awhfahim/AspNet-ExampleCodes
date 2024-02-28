using Autofac;
using Autofac.Extensions.DependencyInjection;
using JWTConfiguration.Api;
using JWTConfiguration.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        //containerBuilder.RegisterModule(new ApplicationModule());
        //containerBuilder.RegisterModule(new InfrastructureModule(connectionString,
        //    migrationAssembly));
        containerBuilder.RegisterModule(new ApiModule());
    });


    //builder.Services.AddIdentity();
    builder.Services.AddJwtAuthentication(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"]);

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("CourseViewRequirementPolicy", policy =>
        {
            policy.AuthenticationSchemes.Clear();
            policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new CourseViewRequirement());
        });
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSites",
            builder =>
            {
                builder.WithOrigins("https://localhost:7159")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            });
    });

    builder.Services.AddSingleton<IAuthorizationHandler, CourseViewRequirementHandler>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    Log.Information("Application Starting...");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
