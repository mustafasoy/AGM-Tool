using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalProjectInfoDto : AuditableEntity
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}
