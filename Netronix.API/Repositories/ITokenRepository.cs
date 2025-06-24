using Microsoft.AspNetCore.Identity;

namespace Netronix.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, IList<string> roles);
    }
}
