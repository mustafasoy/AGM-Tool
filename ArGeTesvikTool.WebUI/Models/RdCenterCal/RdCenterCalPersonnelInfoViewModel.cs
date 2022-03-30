using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalPersonnelInfoViewModel
    {
        public RdCenterCalPersonnelInfoDto NewPersonnelInfo { get; set; }
        public List<RdCenterCalPersonnelInfoDto> PersonnelList { get; set; }
    }
}
