using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersAssingManager : IRdCenterCalPersAssingService
    {
        private readonly IRdCenterCalPersAssingDal _persAssing;

        public RdCenterCalPersAssingManager(IRdCenterCalPersAssingDal persAssing)
        {
            _persAssing = persAssing;
        }

        public void AddList(List<RdCenterCalPersAssingDto> rdCenterCalPersAssingList)
        {
            _persAssing.AddList(rdCenterCalPersAssingList);
        }

        public void UpdateList(List<RdCenterCalPersAssingDto> rdCenterCalPersAssingList)
        {
            _persAssing.UpdateList(rdCenterCalPersAssingList);
        }

        public List<RdCenterCalPersAssingDto> GetByYearProjectCode(int year, string projectCode)
        {
            return _persAssing.GetList(x=>x.Year == year && x.ProjectCode == projectCode);
        }
    }
}
