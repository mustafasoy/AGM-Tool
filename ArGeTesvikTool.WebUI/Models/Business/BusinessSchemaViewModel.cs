using ArGeTesvikTool.Entities.Concrete.Business;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Business
{
    public class BusinessSchemaViewModel
    {
        public List<BusinessSchemaDto> SchemaList { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
