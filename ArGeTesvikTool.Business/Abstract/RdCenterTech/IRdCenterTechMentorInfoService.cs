using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechMentorInfoService
    {
        void Add(RdCenterTechMentorInfoDto rdCenterTechMentor);
        void Update(RdCenterTechMentorInfoDto rdCenterTechMentor);
        void Delete(int id);
        RdCenterTechMentorInfoDto GetById(int id);
        List<RdCenterTechMentorInfoDto> GetAll();
    }
}
