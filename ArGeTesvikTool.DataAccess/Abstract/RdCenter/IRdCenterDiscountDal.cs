﻿using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenter
{
    public interface IRdCenterDiscountDal : IEntityRepository<RdCenterDiscountDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
