using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersonnelService
    {
        void Add(RdCenterCalPersonnelInfoDto rdCenterCalPersonnel);
        void Update(RdCenterCalPersonnelInfoDto rdCenterCalPersonnel);
        void Delete(int id);
        RdCenterCalPersonnelInfoDto GetById(int id);
        List<RdCenterCalPersonnelInfoDto> GetAll();
    }
}
