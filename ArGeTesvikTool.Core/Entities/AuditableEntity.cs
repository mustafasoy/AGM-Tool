using System;

namespace ArGeTesvikTool.Core.Entities
{
    public abstract class AuditableEntity : BaseEntity
    {
        protected AuditableEntity()
        {
            Year = DateTime.Now.Year;
            ModifiedDate = DateTime.Now;
        }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifedUserName { get; set; }
    }
}
