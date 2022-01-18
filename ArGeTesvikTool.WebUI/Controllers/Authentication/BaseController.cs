using ArGeTesvikTool.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class BaseController : Controller
    {
        protected UserManager<AppIdentityUser> _userManager;
        protected RoleManager<AppIdentityRole> _roleManager;
        protected SignInManager<AppIdentityUser> _signInManager;
        
        protected AppIdentityUser CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        public BaseController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; 
        }
    }
}
