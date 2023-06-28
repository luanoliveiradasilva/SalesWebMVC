using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class DepartmentService
    {
        private readonly appContext _appContext;

        public DepartmentService(appContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _appContext.Departments.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
