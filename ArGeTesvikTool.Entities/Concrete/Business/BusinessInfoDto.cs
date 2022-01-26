using ArGeTesvikTool.Entities.Abstract;
using System;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessInfoDto : IEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string ActivityCode { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
        public string Partner { get; set; }
        public DateTime Date { get; set; }
        public DateTime PublishDate { get; set; }
        public string TradeNumber { get; set; }
        public string ChamberCommerce { get; set; }
        public int TaxOffice { get; set; }
        public int RegistrationNo { get; set; }
        public decimal FoundingCapital { get; set; }
        public decimal AvaibleCapital { get; set; }
        public bool IsSME { get; set; }
        public int CRSNumber { get; set; }
    }
}
