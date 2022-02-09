using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Business
{
    public class PersonnelDistributionViewModel
    {
        public PersonnelDistributionDto NewPersonnel { get; set; }
        public List<PersonnelDistributionDto> PersonnelDistributionList { get; set; }
    }
}
