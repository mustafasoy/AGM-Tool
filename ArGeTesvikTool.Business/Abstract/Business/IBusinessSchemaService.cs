using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessSchemaService
    {
        void Add(BusinessSchemaDto businessSchema);
        void Update(BusinessSchemaDto businessSchema);
        void Delete(int id);
        BusinessSchemaDto GetById(int id);
        List<BusinessSchemaDto> GetAllByYear(int year);
    }
}
