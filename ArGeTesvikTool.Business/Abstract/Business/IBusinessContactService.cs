using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessContactService
    {
        void Add(BusinessContactDto businessContact);
        void Update(BusinessContactDto businessContact);
        void Delete(int id);
        BusinessContactDto GetByYear(int year);
    }
}
