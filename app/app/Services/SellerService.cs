using app.Data;
using app.Models;
using NuGet.Protocol;

namespace app.Services
{
    public class SellerService
    {
        private readonly appContext _appContext;

        public SellerService (appContext appContext)
        {
            _appContext = appContext;
        }

        public List<Seller> FindAll()
        {
            return _appContext.Sellers.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.department = _appContext.Departments.First();
            _appContext.Add(obj);
            _appContext.SaveChanges();
        }
    }
}
