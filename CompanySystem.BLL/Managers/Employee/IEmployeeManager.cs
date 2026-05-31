namespace CompanySystem.BLL
{
    public interface IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        // Get All Employees
        IEnumerable<EmployeeReadVM> GetEmployees();
        /*------------------------------------------------------------------*/
        // Get Employee By Id
        EmployeeReadVM? GetEmployeeById(int id);
        /*------------------------------------------------------------------*/
        EmployeeCreateVM ReturnDepartmentList();
        /*------------------------------------------------------------------*/
        // Insert New Employee
        void Insert(EmployeeCreateVM employeeCreateVM);
        /*------------------------------------------------------------------*/
        // Delete
        void Delete(int id);
        /*------------------------------------------------------------------*/
    }
}
