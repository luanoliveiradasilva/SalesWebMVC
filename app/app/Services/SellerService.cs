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
            _appContext.Add(obj);
            _appContext.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _appContext.Sellers.FirstOrDefault(obj => obj.id == id);
        }

        public void Remove(int id)
        {
            var obj = _appContext.Sellers.Find(id);
            _appContext.Sellers.Remove(obj);
            _appContext.SaveChanges();
        }
    }
}
