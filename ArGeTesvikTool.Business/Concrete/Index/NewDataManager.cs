using ArGeTesvikTool.Business.Abstract.Index;
using ArGeTesvikTool.DataAccess.Abstract.Index;
using ArGeTesvikTool.Entities.Concrete.Index;

namespace ArGeTesvikTool.Business.Concrete.Index
{
    public class NewDataManager : INewDataService
    {
        private readonly INewDataDal _newData;

        public NewDataManager(INewDataDal newData)
        {
            _newData = newData;
        }

        public void Add(NewDataDto newData)
        {
            _newData.Add(newData);
        }

        public void Update(NewDataDto newData)
        {
            _newData.Update(newData);
        }

        public void Delete(int id)
        {
            _newData.Delete(new NewDataDto { Id = id });
        }

        public NewDataDto GetByYear(int year)
        {
            return _newData.Get(x => x.Year == year);
        }
    }
}
