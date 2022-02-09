using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class PersonnelDistributionManager : IPersonnelDistributionService
    {
        private readonly IPersonnelDistributionDal _personnelDistribution;

        public PersonnelDistributionManager(IPersonnelDistributionDal personnelDistribution)
        {
            _personnelDistribution = personnelDistribution;
        }
        public void Add(PersonnelDistributionDto personnelDistribution)
        {
            _personnelDistribution.Add(personnelDistribution);
        }

        public void Update(PersonnelDistributionDto personnelDistribution)
        {
            _personnelDistribution.Update(personnelDistribution);
        }

        public void Delete(int id)
        {
            _personnelDistribution.Delete(new PersonnelDistributionDto { Id = id });
        }

        public PersonnelDistributionDto GetById(int id)
        {
            return _personnelDistribution.Get(x => x.Id == id);
        }

        public List<PersonnelDistributionDto> GetAll()
        {
            return _personnelDistribution.GetList();
        }

    }
}
