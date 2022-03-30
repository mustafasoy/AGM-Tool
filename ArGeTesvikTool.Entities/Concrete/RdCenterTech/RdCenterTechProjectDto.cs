using ArGeTesvikTool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechProjectDto : AuditableEntity
    {
        public ProjectStatu ProjectStatu { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public int PersonNumber { get; set; }
        public string ProjectDuration { get; set; }
        public string ProjectFileName { get; set; }
        public byte[] ProjectContent { get; set; }
        public string ProjectContentType { get; set; }
        public string NatSupportProgram { get; set; }
        public string IntSupportProgram { get; set; }
        public string TotalProjectIncome { get; set; }
        public string EquityAmount { get; set; }
        public string SupportAmount { get; set; }
        public string OrderBase { get; set; }
        public string ServiceProcurementSubject { get; set; }
        public ServiceProcurement ServiceProcurement { get; set; }
        public string ServiceProcurementAmount { get; set; }
        public string NatServiceProcurementAmount { get; set; }
        public string IntServiceProcurementAmount { get; set; }
        public string IncomeFileName { get; set; }
        public byte[] IncomeContent { get; set; }
        public string IncomeContentType { get; set; }
        public string ProjectSubject { get; set; }
        public string ProjectSummary { get; set; }
        public string ProjectRequirement { get; set; }
        public string ProjectActivity { get; set; }
        public string ProjectInnovative { get; set; }
        public string ProjectOutput { get; set; }
        public string DocumentFileName { get; set; }
        public byte[] DocumentContent { get; set; }
        public string DocumentContentType { get; set; }
    }

    public enum ProjectStatu
    {
        [Display(Name = "Devam Eden")]
        Devam = 1,
        [Display(Name = "Tamamlanan")]
        Tamam = 2,
        [Display(Name = "İptal Edilen")]
        Iptal = 3,
    }
    public enum ServiceProcurement
    {
        [Display(Name = "Yurt içi")]
        Devam = 1,
        [Display(Name = "Yurt dışı")]
        Tamam = 2,
        [Display(Name = "Her ikisi")]
        Iptal = 3,
    }
}
