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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _appContext.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _appContext.Add(obj);
            await _appContext.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _appContext.Sellers.Include(obj => obj.department).FirstOrDefaultAsync(obj => obj.id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _appContext.Sellers.FindAsync(id);
                _appContext.Sellers.Remove(obj);
                await _appContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _appContext.Sellers.AnyAsync(x => x.id == obj.id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _appContext.Update(obj);
                await _appContext.SaveChangesAsync();
            }
            catch(DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }

            
        }
    }
}
