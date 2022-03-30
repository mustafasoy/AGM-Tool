using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersAssingService
    {
        void Add(RdCenterCalPersAssingDto rdCenterCalPersAssing);
        void Update(RdCenterCalPersAssingDto rdCenterCalPersAssing);
        void Delete(int id);
        RdCenterCalPersAssingDto GetById(int id);
        List<RdCenterCalPersAssingDto> GetAll();
    }
}
