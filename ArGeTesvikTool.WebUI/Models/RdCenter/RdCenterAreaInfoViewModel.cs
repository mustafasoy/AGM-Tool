using ArGeTesvikTool.Entities.Concrete.RdCenter;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenter
{
    public class RdCenterAreaInfoViewModel
    {
        public List<RdCenterAreaInfoDto> AreaInfoList { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
