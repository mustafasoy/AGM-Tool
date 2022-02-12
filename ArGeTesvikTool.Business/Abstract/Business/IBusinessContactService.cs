using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessContactService
    {
        void Add(BusinessContactDto businessContact);
        void Update(BusinessContactDto businessContact);
        BusinessContactDto GetByYear(int year);
    }
}
