using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechProjectManagementViewModel
    {
        public List<RdCenterTechProjectManagementDto> ProjectManagementList { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
