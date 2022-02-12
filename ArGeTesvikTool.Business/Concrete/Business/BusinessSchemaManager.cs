using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessSchemaManager : IBusinessSchemaService
    {
        private readonly IBusinessSchemaDal _businessSchemaDal;

        public BusinessSchemaManager(IBusinessSchemaDal businessSchemaDal)
        {
            _businessSchemaDal = businessSchemaDal;
        }

        public void Add(BusinessSchemaDto businessSchema)
        {
            _businessSchemaDal.Add(businessSchema);
        }

        public void Update(BusinessSchemaDto businessSchema)
        {
            _businessSchemaDal.Update(businessSchema);
        }

        public void Delete(int id)
        {
            _businessSchemaDal.Delete(new BusinessSchemaDto { Id = id });
        }

        public BusinessSchemaDto GetById(int id)
        {
            return _businessSchemaDal.Get(x => x.Id == id);
        }

        public List<BusinessSchemaDto> GetAllByYear(int year)
        {
            return _businessSchemaDal.GetList(x => x.Year == year);
        }
    }
}
