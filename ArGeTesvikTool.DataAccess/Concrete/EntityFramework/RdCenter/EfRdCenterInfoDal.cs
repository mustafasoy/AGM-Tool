﻿using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenter
{
    public class EfRdCenterInfoDal : EfEntityRepositoryBase<RdCenterInfoDto, AGMDbContext>, IRdCenterInfoDal
    {
    }
}
