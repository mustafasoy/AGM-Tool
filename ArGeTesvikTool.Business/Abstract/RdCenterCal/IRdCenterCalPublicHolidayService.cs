using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPublicHolidayService
    {
        void Add(RdCenterCalPublicHolidayDto rdCenterCalHoliday);
        void Update(RdCenterCalPublicHolidayDto rdCenterCalHoliday);
        void Delete(int id);
        RdCenterCalPublicHolidayDto GetById(int id);
        List<RdCenterCalPublicHolidayDto> GetAll();
        List<RdCenterCalPublicHolidayDto> GetAllByYear(int year);
        List<RdCenterCalPublicHolidayDto> GetAllByMonth(DateTime startDate, DateTime endDate);
    }
}
