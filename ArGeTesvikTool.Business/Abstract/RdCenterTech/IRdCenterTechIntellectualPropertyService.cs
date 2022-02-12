using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechIntellectualPropertyService
    {
        void Add(RdCenterTechIntellectualPropertyDto rdCenterTechIntellectual);
        void Update(RdCenterTechIntellectualPropertyDto rdCenterTechIntellectual);
        void Delete(int id);
        RdCenterTechIntellectualPropertyDto GetById(int id);
        List<RdCenterTechIntellectualPropertyDto> GetAll();
    }
}
