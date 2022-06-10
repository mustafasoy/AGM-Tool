using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPublicHolidayManager : IRdCenterCalPublicHolidayService
    {
        private readonly IRdCenterCalPublicHolidayDal _holiday;

        public RdCenterCalPublicHolidayManager(IRdCenterCalPublicHolidayDal holiday)
        {
            _holiday = holiday;
        }

        public void Add(RdCenterCalPublicHolidayDto rdCenterCalHoliday)
        {
            _holiday.Add(rdCenterCalHoliday);
        }

        public void Update(RdCenterCalPublicHolidayDto rdCenterCalHoliday)
        {
            _holiday.Update(rdCenterCalHoliday);
        }

        public void Delete(int id)
        {
            _holiday.Delete(new RdCenterCalPublicHolidayDto { Id = id });
        }

        public RdCenterCalPublicHolidayDto GetById(int id)
        {
            return _holiday.Get(x => x.Id == id);
        }


        public List<RdCenterCalPublicHolidayDto> GetAll()
        {
            return _holiday.GetList()
                .OrderBy(x=>x.StartDate)
                .ToList();
        }

        public List<RdCenterCalPublicHolidayDto> GetAllByYear(int year)
        {
            return _holiday.GetList(x => x.Year == year);
        }

        public List<RdCenterCalPublicHolidayDto> GetAllByMonth(DateTime startDate, DateTime endDate)
        {
            return _holiday.GetList(x => x.StartDate >= startDate && x.EndDate <= endDate);
        }
    }
}
