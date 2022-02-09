﻿using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenter
{
    public interface IRdCenterInfoDal : IEntityRepository<RdCenterInfoDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
