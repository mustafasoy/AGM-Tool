using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerformance
{
    public interface IRdCenterPerformanceProjectService
    {
        void Add(RdCenterPerformanceProjectDto rdCenterPerformanceProject);
        void Update(RdCenterPerformanceProjectDto rdCenterPerformanceProject);
        void Delete(int id);
        RdCenterPerformanceProjectDto GetById(int id);
        List<RdCenterPerformanceProjectDto> GetAllByYear(int year);
    }
}
