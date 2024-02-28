
using System.Security.Claims;

namespace JWTConfiguration.Api
{
    public interface ITokenService
    {
        Task<string> GetJwtToken(IList<Claim> claims, string key, string issuer, string audience);
    }
}