using System;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class FiscalYearDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }
    }
}
