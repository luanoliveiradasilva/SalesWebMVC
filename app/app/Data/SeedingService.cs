using app.Models;
using app.Models.Enums;

namespace app.Data
{
    public class SeedingService
    {

        private appContext _appContext;

        public SeedingService(appContext appContext)
        {
            _appContext = appContext;
        }

        public void Seed()
        {
            if(_appContext.Departments.Any() || _appContext.Sellers.Any() || _appContext.SalesRecords.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");

            Seller s1 = new Seller(1, "Bob", "teste@teste.com", new DateTime(1991, 1, 1), 1000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 23), 11000.0, SalesStatus.BILLED, s1);

            _appContext.Departments.AddRange(d1);

            _appContext.Sellers.AddRange(s1);

            _appContext.SalesRecords.AddRange(r1);

            _appContext.SaveChanges();
        }
    }
}
