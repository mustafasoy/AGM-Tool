﻿using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonRewardDal : IEntityRepository<RdCenterPersonRewardDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
