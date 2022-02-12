namespace ArGeTesvikTool.Core.Entities
{
    public interface IFileEntity
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
