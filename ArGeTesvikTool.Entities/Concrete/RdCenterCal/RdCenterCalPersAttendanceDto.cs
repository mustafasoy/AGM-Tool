using System;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersAttendanceDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PersonnelNumber { get; set; }
        public DateTime EventTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
    }
}
