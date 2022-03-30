using ArGeTesvikTool.Core.Entities;
using System;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessInfoDto : AuditableEntity
    {
        public string CompanyName { get; set; }
        public string ActivityCode { get; set; }
        public string Adress { get; set; }
        public string CityCode { get; set; }
        public string CityText { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Partner { get; set; }
        public DateTime Date { get; set; }
        public DateTime PublishDate { get; set; }
        public string TradeNumber { get; set; }
        public string ChamberCommerce { get; set; }
        public string TaxOffice { get; set; }
        public string RegistrationNo { get; set; }
        public string FoundingCapital { get; set; }
        public string AvaibleCapital { get; set; }
        public Sme IsSME { get; set; }
        public string CRSNumber { get; set; }
    }

    public enum Sme
    {
        Hayır, Evet
    }
}
