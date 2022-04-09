using System;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalPersonnelAddViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Year { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string TimeAwayCode { get; set; }
        public string TimeAwayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifedUserName { get; set; }
    }
}
