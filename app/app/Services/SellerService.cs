using app.Data;
using app.Models;
using app.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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
            return _appContext.Sellers.Include(obj => obj.department).FirstOrDefault(obj => obj.id == id);
        }

        public void Remove(int id)
        {
            var obj = _appContext.Sellers.Find(id);
            _appContext.Sellers.Remove(obj);
            _appContext.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_appContext.Sellers.Any(x => x.id == obj.id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _appContext.Update(obj);
                _appContext.SaveChanges();
            }
            catch(DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }

            
        }
    }
}
