using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessSchemaDto : AuditableEntity, IFileEntity
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
