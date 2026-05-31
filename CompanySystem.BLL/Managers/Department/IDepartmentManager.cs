namespace CompanySystem.BLL
{
    public interface IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        // Get All Departments
        IEnumerable<DepartmentReadVM> GetDepartments();
        /*------------------------------------------------------------------*/
        // Get Department By Id
        DepartmentReadVM? GetDepartmentById(int id);
        /*------------------------------------------------------------------*/
        // Insert New Department
        void Insert(DepartmentCreateVM departmentCreateVM);
        /*------------------------------------------------------------------*/
        // Get Department By Id For Edit
        DepartmentEditVM? GetDepartmentByIdForEdit(int id);
        /*------------------------------------------------------------------*/
        // Edit Department
        void Edit(DepartmentEditVM departmentEditVM);
        /*------------------------------------------------------------------*/
        // Delete Department
        void Delete(int id);
        /*------------------------------------------------------------------*/
    }
}
