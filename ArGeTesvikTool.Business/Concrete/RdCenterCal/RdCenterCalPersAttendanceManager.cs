using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersAttendanceManager : IRdCenterCalPersAttendanceService
    {
        private readonly IRdCenterCalPersAttendanceDal _attendance;

        public RdCenterCalPersAttendanceManager(IRdCenterCalPersAttendanceDal attendance)
        {
            _attendance = attendance;
        }

        public void Delete(int id)
        {
            _attendance.Delete(new RdCenterCalPersAttendanceDto { Id = id });
        }

        public RdCenterCalPersAttendanceDto GetById(int id)
        {
            return _attendance.Get(x => x.Id == id);
        }

        public List<RdCenterCalPersAttendanceDto> GetAllByMonth(DateTime startDate, DateTime endDate)
        {
            DateTime startDateTime = new(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
            DateTime endDateTime = new(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 0);

            return _attendance.GetList(x => x.EventTime >= startDateTime && x.EventTime <= endDateTime);
        }

        public List<RdCenterCalPersAttendanceDto> GetAllByMonthByPersonnelId(string regNo, DateTime startDate, DateTime endDate)
        {
            DateTime startDateTime = new(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
            DateTime endDateTime = new(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 0);

            return _attendance.GetList(x => x.UserId == regNo &&
                                            x.EventTime >= startDateTime && x.EventTime <= endDateTime);
        }
    }
}
