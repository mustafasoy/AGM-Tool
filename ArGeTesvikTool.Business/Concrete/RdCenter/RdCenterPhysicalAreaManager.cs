using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterPhysicalAreaManager : IRdCenterPhysicalAreaService
    {
        private readonly IRdCenterPhysicalAreaDal _rdPhysicalAreaDal;

        public RdCenterPhysicalAreaManager(IRdCenterPhysicalAreaDal rdPhysicalAreaDal)
        {
            _rdPhysicalAreaDal = rdPhysicalAreaDal;
        }

        public void Add(RdCenterPhysicalAreaDto rdPhysicalArea)
        {
            _rdPhysicalAreaDal.Add(rdPhysicalArea);
        }

        public void Update(RdCenterPhysicalAreaDto rdPhysicalArea)
        {
            _rdPhysicalAreaDal.Update(rdPhysicalArea);
        }

        public void Delete(int id)
        {
            _rdPhysicalAreaDal.Delete(new RdCenterPhysicalAreaDto { Id = id });
        }

        public RdCenterPhysicalAreaDto GetById(int id)
        {
            return _rdPhysicalAreaDal.Get(x => x.Id == id);
        }

        public List<RdCenterPhysicalAreaDto> GetAllByYear(int year)
        {
            return _rdPhysicalAreaDal.GetList(x => x.Year == year);
        }
    }
}
