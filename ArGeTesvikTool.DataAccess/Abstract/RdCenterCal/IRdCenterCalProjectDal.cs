﻿using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterCal
{
    public interface IRdCenterCalProjectDal : IEntityRepository<RdCenterCalProjectInfoDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
