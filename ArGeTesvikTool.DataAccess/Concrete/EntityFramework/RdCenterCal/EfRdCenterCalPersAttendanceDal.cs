using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterCal
{
    public class EfRdCenterCalPersAttendanceDal : EfEntityRepositoryBase<RdCenterCalPersAttendanceDto, AGMDbContext>, IRdCenterCalPersAttendanceDal
    {
    }
}
