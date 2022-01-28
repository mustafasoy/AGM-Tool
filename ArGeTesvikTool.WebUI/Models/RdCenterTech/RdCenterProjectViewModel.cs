using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterProjectViewModel
    {
        public int RowNo { get; set; }
        public List<RdCenterProjectDto> ProjectList { get; set; }
    }
}
