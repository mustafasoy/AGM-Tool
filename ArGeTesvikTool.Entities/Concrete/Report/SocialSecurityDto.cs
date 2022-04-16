namespace ArGeTesvikTool.Entities.Concrete.Report
{
    public class SocialSecurityDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string PersonnelFullName { get; set; }
        public string RegistrationNo { get; set; }
        public string WorkType { get; set; }
        public int WeekNumber { get; set; }
        public decimal PreMonthTransfer { get; set; }
        public decimal IncentiveWorkingHour { get; set; }
        public decimal PreMonthAnnuelLeaveHour { get; set; }
        public decimal AnnuelLeaveWorkingHour { get; set; }
        public int WeekendWorkingHour { get; set; }
        public decimal PublicHolidayWorkingHour { get; set; }
        public decimal SsiWorkingHour { get; set; }
    }
}
