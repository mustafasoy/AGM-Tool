using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechIntellectualPropertyManager : IRdCenterTechIntellectualPropertyService
    {
        private readonly IRdCenterTechIntellectualPropertyDal _rdCenterTechIntellectualProperty;

        public RdCenterTechIntellectualPropertyManager(IRdCenterTechIntellectualPropertyDal rdCenterTechIntellectualProperty)
        {
            _rdCenterTechIntellectualProperty = rdCenterTechIntellectualProperty;
        }

        public void Add(RdCenterTechIntellectualPropertyDto rdCenterTechIntellectual)
        {
            _rdCenterTechIntellectualProperty.Add(rdCenterTechIntellectual);
        }

        public void Update(RdCenterTechIntellectualPropertyDto rdCenterTechIntellectual)
        {
            _rdCenterTechIntellectualProperty.Update(rdCenterTechIntellectual);
        }

        public void Delete(int id)
        {
            _rdCenterTechIntellectualProperty.Delete(new RdCenterTechIntellectualPropertyDto { Id = id });
        }

        public RdCenterTechIntellectualPropertyDto GetById(int id)
        {
            return _rdCenterTechIntellectualProperty.Get(x => x.Id == id);
        }

        public List<RdCenterTechIntellectualPropertyDto> GetAll()
        {
            return _rdCenterTechIntellectualProperty.GetList();
        }
    }
}
