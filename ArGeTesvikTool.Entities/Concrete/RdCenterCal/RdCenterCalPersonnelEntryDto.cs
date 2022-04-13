using ArGeTesvikTool.Core.Entities;
using ArGeTesvikTool.WebUI.Models;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersonnelEntryDto : AuditableEntity
    {
        public string UserId { get; set; }
        public string PersonnelFullName { get; set; }
        public string RegistrationNo { get; set; }
        public string WorkType { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string TimeAwayCode { get; set; }
        public string TimeAwayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AppIdentityUser User { get; set; }
    }
}
