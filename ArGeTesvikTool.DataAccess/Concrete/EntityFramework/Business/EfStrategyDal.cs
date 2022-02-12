﻿using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business
{
    public class EfStrategyDal: EfEntityRepositoryBase<StrategyDto, AGMDbContext>, IStrategyDal
    {
    }
}
