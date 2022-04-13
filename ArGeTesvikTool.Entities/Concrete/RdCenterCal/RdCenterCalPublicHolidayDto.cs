using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPublicHolidayDto: AuditableEntity
    {
        public int Month { get; set; }
        public string HolidayName { get; set; }
        public bool IsHalfDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
