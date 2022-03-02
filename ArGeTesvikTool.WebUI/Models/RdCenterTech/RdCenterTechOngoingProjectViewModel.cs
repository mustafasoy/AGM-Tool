using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechOngoingProjectViewModel
    {
        public int RowNo { get; set; }
        public RdCenterTechOngoingProjectDto NewProject { get; set; }
        public List<RdCenterTechOngoingProjectDto> ProjectList { get; set; }
    }
}
