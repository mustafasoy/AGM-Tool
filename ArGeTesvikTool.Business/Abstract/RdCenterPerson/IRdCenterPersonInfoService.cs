using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonInfoService
    {
        void Add(RdCenterPersonInfoDto rdCenterPersoInfo);
        void Update(RdCenterPersonInfoDto rdCenterPersoInfo);
        void Delete(int id);
        RdCenterPersonInfoDto GetById(int id);
        List<RdCenterPersonInfoDto> GetAll();
    }
}
