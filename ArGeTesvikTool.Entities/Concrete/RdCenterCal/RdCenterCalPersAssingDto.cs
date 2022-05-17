using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterCal
{
    public class RdCenterCalPersAssingDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string RegistrationNo { get; set; }
        public string NameSurname { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
    }
}
