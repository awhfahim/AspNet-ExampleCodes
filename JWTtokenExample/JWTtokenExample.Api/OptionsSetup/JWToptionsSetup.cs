using JWTtokenExample.Api.OptionsSetup;
using Microsoft.Extensions.Options;

namespace JWTtokenExample.Api.JWToptionsSetup
{
	public class JwtBeareroptionSetup : IConfigureOptions<JWToptions>
	{
		private const string SectionName = "Jwt";
		private readonly IConfiguration _configuration;

		public JwtBeareroptionSetup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void Configure(JWToptions options)
		{
			_configuration.GetSection(SectionName).Bind(options);
		}
	}
}
