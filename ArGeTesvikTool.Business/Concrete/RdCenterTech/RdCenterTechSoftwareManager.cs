using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechSoftwareManager : IRdCenterTechSoftwareService
    {
        private readonly IRdCenterTechSoftwareDal _softwareDal;
        public RdCenterTechSoftwareManager(IRdCenterTechSoftwareDal softwareDal)
        {
            _softwareDal = softwareDal;
        }
        public void Add(RdCenterTechSoftwareDto rdCenterTechSoftware)
        {
            _softwareDal.Add(rdCenterTechSoftware);
        }

        public void Update(RdCenterTechSoftwareDto rdCenterTechSoftware)
        {
            _softwareDal.Update(rdCenterTechSoftware);
        }

        public void Delete(int id)
        {
            _softwareDal.Delete(new RdCenterTechSoftwareDto { Id = id });
        }

        public RdCenterTechSoftwareDto GetById(int id)
        {
            return _softwareDal.Get(x => x.Id == id);
        }

        public List<RdCenterTechSoftwareDto> GetAll()
        {
            return _softwareDal.GetList();
        }
    }
}
