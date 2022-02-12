using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenter
{
    public class RdCenterSchemaViewModel
    {
        public List<RdCenterSchemaDto> SchemaList { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
