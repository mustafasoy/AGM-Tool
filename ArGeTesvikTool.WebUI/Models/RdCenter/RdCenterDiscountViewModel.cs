using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenter
{
    public class RdCenterDiscountViewModel
    {
        public RdCenterDiscountDto NewDiscountInfo { get; set; }
        public List<RdCenterDiscountDto> DiscountList { get; set; }
    }
}
