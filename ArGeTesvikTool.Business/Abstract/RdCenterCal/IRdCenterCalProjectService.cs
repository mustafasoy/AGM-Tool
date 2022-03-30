using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalProjectService
    {
        void Add(RdCenterCalProjectInfoDto rdCenterCalProject);
        void Update(RdCenterCalProjectInfoDto rdCenterCalProject);
        void Delete(int id);
        RdCenterCalProjectInfoDto GetById(int id);
        List<RdCenterCalProjectInfoDto> GetAll();
    }
}
