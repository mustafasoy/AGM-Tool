using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersAttendanceDal : IEntityRepository<RdCenterCalPersAttendanceDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
