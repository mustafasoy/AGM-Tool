﻿using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechCompletedProjectDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public decimal EquityAmount { get; set; }
        public decimal SupportAmount { get; set; }
        public string ProgramName { get; set; }
        public string InternationalProgName { get; set; }
        public decimal TotalProjectBudget { get; set; }
    }
}
