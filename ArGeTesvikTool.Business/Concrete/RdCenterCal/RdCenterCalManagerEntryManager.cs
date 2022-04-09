using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalManagerEntryManager : IRdCenterCalManagerEntryService
    {
        private readonly IRdCenterCalManagerEntryDal _managerEntry;

        public RdCenterCalManagerEntryManager(IRdCenterCalManagerEntryDal managerEntry)
        {
            _managerEntry = managerEntry;
        }

        public void Add(RdCenterCalManagerEntryDto rdCenterCalManagerEntity)
        {
            _managerEntry.Add(rdCenterCalManagerEntity);
        }

        public void Update(RdCenterCalManagerEntryDto rdCenterCalManagerEntity)
        {
            _managerEntry.Update(rdCenterCalManagerEntity);
        }

        public void Delete(int id)
        {
            _managerEntry.Delete(new RdCenterCalManagerEntryDto { Id = id });
        }

        public void AddList(List<RdCenterCalManagerEntryDto> rdCenterCalManagerEntity)
        {
            _managerEntry.AddList(rdCenterCalManagerEntity);
        }

        public RdCenterCalManagerEntryDto GetById(int id)
        {
            return _managerEntry.Get(x => x.Id == id);
        }

        public List<RdCenterCalManagerEntryDto> GetAllByYear(int year)
        {
            return _managerEntry.GetList(x => x.Year == year);
        }
    }
}
