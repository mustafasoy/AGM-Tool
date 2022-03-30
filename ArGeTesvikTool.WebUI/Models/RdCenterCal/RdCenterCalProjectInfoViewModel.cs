using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalProjectInfoViewModel
    {
        public RdCenterCalProjectInfoDto NewProjectInfo { get; set; }
        public List<RdCenterCalProjectInfoDto> ProjectList { get; set; }
    }
}
