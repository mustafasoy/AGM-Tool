﻿using ArGeTesvikTool.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class User : IEntity
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        //public string Verified { get; set; }

        //public string Role { get; set; }

        //public string Status { get; set; }
    }
}
