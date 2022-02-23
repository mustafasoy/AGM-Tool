using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechIntellectualPropertyViewModel
    {
        public RdCenterTechIntellectualPropertyDto NewProperty { get; set; }
        public List<RdCenterTechIntellectualPropertyDto> PropertyList { get; set; }
    }
}
