using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalManagerEntryDto : AuditableEntity
    {
        public string Mail { get; set; }
        public string ProjectCode { get; set; }
        public string TimeAwayCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime Date_Time { get; set; }
    }
}
