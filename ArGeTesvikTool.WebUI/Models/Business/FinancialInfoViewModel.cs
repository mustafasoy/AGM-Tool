using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Business
{
    public class FinancialInfoViewModel
    {
        public BusinessFinancialInfoDto NewFinancialInfo { get; set; }
        public List<BusinessFinancialInfoDto> FinancialInfoList { get; set; }
    }
}
