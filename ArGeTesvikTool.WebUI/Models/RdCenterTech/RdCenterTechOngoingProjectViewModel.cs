using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechOngoingProjectViewModel
    {
        public int RowNo { get; set; }
        public List<RdCenterTechCompletedProjectDto> ProjectList { get; set; }
    }
}
