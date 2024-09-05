using EmployeeManagement.Domain;
using EmployeeManagement.Entities.Models.EntityModels;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository
    {
        EmployeeManagementContext _context;
        public DepartmentRepository(EmployeeManagementContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This methods gets all the departments
        /// </summary>
        /// <returns>list of dept</returns>
        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
