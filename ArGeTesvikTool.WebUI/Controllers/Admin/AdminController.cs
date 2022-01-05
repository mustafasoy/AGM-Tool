using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Admin;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class AdminController : Controller
    {
        private UserManager<AppIdentityUser> _userManager { get; }

        public AdminController(UserManager<AppIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var userList = _userManager.Users.ToList();
            List<User> newUser = new();

            foreach (var item in userList)
            {
                User userLine = item.Adapt<User>();
                newUser.Add(userLine);
            }

            UserListViewModel userListViewModel = new()
            {
                UserList = newUser
            };

            return View(userListViewModel);
        }
    }
}
