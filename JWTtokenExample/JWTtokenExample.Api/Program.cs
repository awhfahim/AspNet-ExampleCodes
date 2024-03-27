using JWTtokenExample.Api.JWToptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer();

builder.Services.ConfigureOptions<JwtBeareroptionSetup>();
builder.Services.ConfigureOptions<JwtBeareroptionSetup>();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "true"));
	options.AddPolicy("User", policy =>
	{
		policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("User", "true");
		//policy.Requirements.Add(new UserRequirement());
	});

	options.AddPolicy("UserOrAdmin", policy =>
	{
		policy.RequireAuthenticatedUser();
		//policy.AddRequirements(new UserRequirement());
		//policy.AddRequirements(new AdminRequirement());
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
