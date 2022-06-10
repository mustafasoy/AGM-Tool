using ArGeTesvikTool.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Base
{
    public static class UserManagerExtensions
    {
        public static async Task<AppIdentityUser> FindByIdentityNumberAsync(this UserManager<AppIdentityUser> user, string identityNumber)
        {
            return await user.Users.SingleOrDefaultAsync(x => x.IdentityNumber == identityNumber);
        }

        public static async Task<AppIdentityUser> FindByRegistrationNumberAsync(this UserManager<AppIdentityUser> user, string registrationNumber)
        {
            return await user.Users.SingleOrDefaultAsync(x => x.RegistrationNo == registrationNumber);
        }
    }
}
