using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalManagerEntryService
    {
        void Add(RdCenterCalManagerEntryDto rdCenterCalManagerEntry);
        void AddList(List<RdCenterCalManagerEntryDto> rdCenterCalManagerEntry);
        void Update(RdCenterCalManagerEntryDto rdCenterCalManagerEntry);
        void Delete(int id);
        RdCenterCalManagerEntryDto GetById(int id);
        List<RdCenterCalManagerEntryDto> GetAllByYear(int year);
    }
}
