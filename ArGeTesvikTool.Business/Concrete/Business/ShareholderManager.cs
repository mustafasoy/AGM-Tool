using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class ShareholderManager : IShareholderService
    {
        private readonly IShareholderDal _shareholderDal;

        public ShareholderManager(IShareholderDal shareholderDal)
        {
            _shareholderDal = shareholderDal;
        }

        public void Add(ShareholdersDto shareholder)
        {
            _shareholderDal.Add(shareholder);
        }

        public void Update(ShareholdersDto shareholder)
        {
            _shareholderDal.Update(shareholder);
        }

        public void Delete(int id)
        {
            _shareholderDal.Delete(new ShareholdersDto { Id = id });
        }

        public ShareholdersDto GetById(int id)
        {
            return _shareholderDal.Get(x => x.Id == id);
        }

        public List<ShareholdersDto> GetAll()
        {
            return _shareholderDal.GetList();
        }
    }
}
