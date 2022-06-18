namespace ArGeTesvikTool.Entities.Concrete.Report
{
    public class TeleworkingDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string PersonnelFullName { get; set; }
        public decimal ProjectTimeSpend { get; set; }
        public decimal OutsideTimeSpend { get; set; }
        public decimal TeleworkingTimeSpend { get; set; }
        public decimal EditedTeleworkingTimeSpend { get; set; }
    }
}
