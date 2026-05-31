using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        /*------------------------------------------------------------------*/
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<Employee> GetAllWithDepartment()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }
        /*------------------------------------------------------------------*/
        public Employee? GetByIdWithDepartment(int employeeId)
        {
            return _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == employeeId);
        }
        /*------------------------------------------------------------------*/
        //This method will make the changes permanent in the database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
