using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWTtokenExample.Api.OptionsSetup
{
	public class JwtBearerOptionSetup : IConfigureOptions<JwtBearerOptions>
	{
		public readonly JWToptions _jwtOptions;

		public JwtBearerOptionSetup(IOptions<JWToptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}
		public void Configure(JwtBearerOptions options)
		{
			options.SaveToken = true;
			options.RequireHttpsMetadata = false;
			options.TokenValidationParameters = new()
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = _jwtOptions.Issuer,
				ValidAudience = _jwtOptions.Audience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key))
			};
		}
	}
}
