using app.Data;
using app.Models;

namespace app.Services
{
    public class DepartmentService
    {
        private readonly appContext _appContext;

        public DepartmentService(appContext appContext)
        {
            _appContext = appContext;
        }

        public List<Department> FindAll()
        {
            return _appContext.Departments.OrderBy(x => x.Name).ToList();
        }
    }
}
