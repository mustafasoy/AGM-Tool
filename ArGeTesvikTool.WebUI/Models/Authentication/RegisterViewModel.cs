using ArGeTesvikTool.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models.Authentication
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
