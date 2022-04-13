using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersonnelEntryService
    {
        void Add(RdCenterCalPersonnelEntryDto rdCenterCalPersonnelEntity);
        void Update(RdCenterCalPersonnelEntryDto rdCenterCalPersonnelEntity);
        void Delete(int id);
        RdCenterCalPersonnelEntryDto GetById(int id);
        List<RdCenterCalPersonnelEntryDto> GetAll(int year);
        List<RdCenterCalPersonnelEntryDto> GetAllByMonth(DateTime startDate, DateTime endDate);
    }
}
