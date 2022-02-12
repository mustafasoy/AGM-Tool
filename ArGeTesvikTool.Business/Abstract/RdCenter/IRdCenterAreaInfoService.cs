using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterAreaInfoService
    {
        void Add(RdCenterAreaInfoDto rdCenterAreaInfo);
        void Update(RdCenterAreaInfoDto rdCenterAreaInfo);
        void Delete(int id);
        RdCenterAreaInfoDto GetById(int id);
        List<RdCenterAreaInfoDto> GetAllByYear(int year);
    }
}
