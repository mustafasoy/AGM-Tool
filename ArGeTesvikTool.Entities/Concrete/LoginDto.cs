using ArGeTesvikTool.Entities.Abstract;
using ArGeTesvikTool.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models.Authentication
{
    public class LoginDto : IEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
