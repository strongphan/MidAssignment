using ManhPT_MidAssignment.Domain.Entity;
using System.Security.Claims;

namespace ManhPT_MidAssignment.Application.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateJWT(IEnumerable<Claim>? additionalClaims = null);
        string GenerateJWT(User user, IEnumerable<Claim>? additionalClaims = null);
    }
}
