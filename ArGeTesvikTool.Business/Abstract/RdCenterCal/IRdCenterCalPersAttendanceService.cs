using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersAttendanceService
    {
        void Delete(int id);
        RdCenterCalPersAttendanceDto GetById(int id);
        List<RdCenterCalPersAttendanceDto> GetAllByMonth(DateTime startDate, DateTime endDate);
        List<RdCenterCalPersAttendanceDto> GetAllByMonthByPersonnelId(string regNo, DateTime startDate, DateTime endDate);
    }
}
