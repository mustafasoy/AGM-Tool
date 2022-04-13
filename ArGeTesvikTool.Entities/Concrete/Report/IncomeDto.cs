namespace ArGeTesvikTool.Entities.Concrete.Report
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public string PersonnelFullName { get; set; }
        public string RegistrationNo { get; set; }
        public string WorkType { get; set; }
        public decimal RdCenterTimeSpend { get; set; }
        public decimal RemoteTimeSpend { get; set; }
        public decimal ProjectTimeSpend { get; set; }
        public decimal UncentiveTimeSpend { get; set; }
        public decimal NonRdCenterTimeSpend { get; set; }
        public decimal NonRdCenterOtherTimeSpend { get; set; }
        public decimal AnnualLeaveTimeSpend { get; set; }
        public decimal BaseUsedDay { get; set; }
    }
}
