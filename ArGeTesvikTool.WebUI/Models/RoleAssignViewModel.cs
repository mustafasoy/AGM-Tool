using ArGeTesvikTool.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models
{
    public class RoleAssignViewModel : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
    }
}