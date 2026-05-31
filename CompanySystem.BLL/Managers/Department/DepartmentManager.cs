using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class DepartmentManager : IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<DepartmentReadVM> GetDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentsVM = departments.Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            });
            return departmentsVM;
        }
        /*------------------------------------------------------------------*/
        public DepartmentReadVM? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }
            var departmentVM = new DepartmentReadVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return departmentVM;
        }
        /*------------------------------------------------------------------*/
        public void Insert(DepartmentCreateVM departmentCreateVM)
        {
            var newDepartment = new Department
            {
                Name = departmentCreateVM.Name
            };
            _unitOfWork.DepartmentRepository.Add(newDepartment);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------*/
        public DepartmentEditVM? GetDepartmentByIdForEdit(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }
            var departmentVM = new DepartmentEditVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return departmentVM;
        }
        /*------------------------------------------------------------------*/
        public void Edit(DepartmentEditVM departmentEditVM)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(departmentEditVM.Id);
            if (department == null)
            {
                return;
            }
            department.Name = departmentEditVM.Name;
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------*/
        public void Delete(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return;
            }
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
