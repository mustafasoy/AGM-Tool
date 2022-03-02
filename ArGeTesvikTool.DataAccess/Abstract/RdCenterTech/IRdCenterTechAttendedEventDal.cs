﻿using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterTech
{
    public interface IRdCenterTechAttendedEventDal : IEntityRepository<RdCenterTechAttendedEventDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}