using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class EmployeeManager : IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<EmployeeReadVM> GetEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAllWithDepartment();
            var employeesVM = employees.Select(e => new EmployeeReadVM
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                Department = e.Department != null ? e.Department.Name : null
            });
            return employeesVM;
        }
        /*------------------------------------------------------------------*/
        public EmployeeReadVM? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByIdWithDepartment(id);
            if (employee == null)
            {
                return null;
            }
            var employeeVM = new EmployeeReadVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Department = employee.Department != null ? employee.Department.Name : null
            };
            return employeeVM;
        }
        /*------------------------------------------------------------------*/
        public EmployeeCreateVM ReturnDepartmentList()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentsVM = departments.Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
            var employeeCreateVM = new EmployeeCreateVM
            {
                Departments = departmentsVM
            };
            return employeeCreateVM;
        }
        /*------------------------------------------------------------------*/
        public void Insert(EmployeeCreateVM employeeCreateVM)
        {
            var employee = new Employee
            {
                Name = employeeCreateVM.Name,
                Age = employeeCreateVM.Age,
                Salary = employeeCreateVM.Salary,
                DepartmentId = employeeCreateVM.DepartmentId
            };
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------*/
        public void Delete(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return;
            }
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
