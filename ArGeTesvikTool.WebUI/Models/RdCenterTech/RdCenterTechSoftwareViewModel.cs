using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechSoftwareViewModel
    {
        public RdCenterTechSoftwareDto NewSoftware { get; set; }
        public List<RdCenterTechSoftwareDto> SoftwareList { get; set; }
    }
}
