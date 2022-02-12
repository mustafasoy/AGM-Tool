using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterSchemaService
    {
        void Add(RdCenterSchemaDto rdCenterSchema);
        void Update(RdCenterSchemaDto rdCenterSchema);
        void Delete(int id);
        RdCenterSchemaDto GetById(int id);
        List<RdCenterSchemaDto> GetAllByYear(int year);
    }
}
