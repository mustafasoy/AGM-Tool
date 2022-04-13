using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models
{
    public class AppIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string RegistrationNo { get; set; }

        public List<RdCenterCalPersonnelEntryDto> PersonnelEntries { get; set; }
    }
}
