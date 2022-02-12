using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterSchemaManager : IRdCenterSchemaService
    {
        private readonly IRdCenterSchemaDal _rdCenterSchemaDal;

        public RdCenterSchemaManager(IRdCenterSchemaDal rdCenterSchemaDal)
        {
            _rdCenterSchemaDal = rdCenterSchemaDal;
        }

        public void Add(RdCenterSchemaDto rdCenterSchema)
        {
            _rdCenterSchemaDal.Add(rdCenterSchema);
        }

        public void Update(RdCenterSchemaDto rdCenterSchema)
        {
            _rdCenterSchemaDal.Update(rdCenterSchema);
        }

        public void Delete(int id)
        {
            _rdCenterSchemaDal.Delete(new RdCenterSchemaDto { Id = id });
        }

        public RdCenterSchemaDto GetById(int id)
        {
            return _rdCenterSchemaDal.Get(x => x.Id == id);
        }

        public List<RdCenterSchemaDto> GetAllByYear(int year)
        {
            return _rdCenterSchemaDal.GetList(x => x.Year == year);
        }
    }
}
