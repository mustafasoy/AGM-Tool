﻿using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Admin;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{

    [Authorize]
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
            List<UserDto> newUser = new();

            foreach (var item in userList)
            {
                UserDto userLine = item.Adapt<UserDto>();
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
