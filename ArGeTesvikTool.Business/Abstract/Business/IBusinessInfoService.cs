using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessInfoService
    {
        void Add(BusinessInfoDto businessInfo);
        void Update(BusinessInfoDto businessInfo);
        BusinessInfoDto GetByYear(int year);
    }
}
