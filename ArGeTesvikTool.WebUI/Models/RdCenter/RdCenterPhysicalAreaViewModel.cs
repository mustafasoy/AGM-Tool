using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenter
{
    public class RdCenterPhysicalAreaViewModel
    {
        public List<RdCenterPhysicalAreaDto> PhysicalAreaList { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
