using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersonnelEntryService
    {
        void Add(RdCenterCalPersonnelEntryDto rdCenterCalPersonnelEntity);
        void AddList(List<RdCenterCalPersonnelEntryDto> rdCenterCalPersonnelEntityList);
        void Update(RdCenterCalPersonnelEntryDto rdCenterCalPersonnelEntity);
        void Delete(int id);
        RdCenterCalPersonnelEntryDto GetById(int id);
        List<RdCenterCalPersonnelEntryDto> GetAllByYear(int year);
        List<RdCenterCalPersonnelEntryDto> GetAllByYearByUserId(int year, string userId);
        List<RdCenterCalPersonnelEntryDto> GetAllByMonth(DateTime startDate, DateTime endDate);
        List<RdCenterCalPersonnelEntryDto> GetAllByMonthByPersonnel(string regNo, DateTime startDate, DateTime endDate);
        List<RdCenterCalPersonnelEntryDto> GetAllPersonnel();
        List<RdCenterCalPersonnelEntryDto> GetAllPersonnelByCode(int id, string projectCode, string timeAwayCode);
    }
}
