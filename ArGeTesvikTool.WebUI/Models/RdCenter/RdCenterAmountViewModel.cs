using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenter
{
    public class RdCenterAmountViewModel
    {
        public RdCenterAmountDto NewAmountInfo { get; set; }
        public List<RdCenterAmountDto> AmountList { get; set; }
    }
}
