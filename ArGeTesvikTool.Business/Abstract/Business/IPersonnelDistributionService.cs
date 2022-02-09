using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IPersonnelDistributionService
    {
        void Add(PersonnelDistributionDto personnelDistribution);
        void Update(PersonnelDistributionDto personnelDistribution);
        void Delete(int id);
        PersonnelDistributionDto GetById(int id);
        List<PersonnelDistributionDto> GetAll();
    }
}
