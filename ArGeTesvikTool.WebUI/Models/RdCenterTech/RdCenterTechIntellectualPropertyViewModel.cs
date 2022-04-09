using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechIntellectualPropertyViewModel
    {
        public RdCenterTechIntellectualPropertyDto NewProperty { get; set; }
        public List<RdCenterTechIntellectualPropertyDto> PropertyList { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
    }
}
