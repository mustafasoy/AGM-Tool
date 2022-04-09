using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersonnelEntryManager : IRdCenterCalPersonnelEntryService
    {
        private readonly IRdCenterCalPersonnelEntryDal _personnelEntry;

        public RdCenterCalPersonnelEntryManager(IRdCenterCalPersonnelEntryDal personnelEntry)
        {
            _personnelEntry = personnelEntry;
        }

        public void Add(RdCenterCalPersonnelEntryDto rdCenterCalManagerEntry)
        {
            _personnelEntry.Add(rdCenterCalManagerEntry);
        }

        public void Update(RdCenterCalPersonnelEntryDto rdCenterCalManagerEntry)
        {
            _personnelEntry.Update(rdCenterCalManagerEntry);
        }

        public void Delete(int id)
        {
            _personnelEntry.Delete(new RdCenterCalPersonnelEntryDto { Id = id });
        }

        public RdCenterCalPersonnelEntryDto GetById(int id)
        {
            return _personnelEntry.Get(x => x.Id == id);
        }

        public List<RdCenterCalPersonnelEntryDto> GetAll(int year)
        {
            return _personnelEntry.GetList(x=>x.Year == year);
        }
    }
}
