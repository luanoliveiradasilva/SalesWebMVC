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
    }
}
