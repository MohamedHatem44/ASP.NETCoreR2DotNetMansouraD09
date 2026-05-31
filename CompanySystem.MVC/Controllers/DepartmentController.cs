using CompanySystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly IDepartmentManager _departmentManager;
        /*------------------------------------------------------------------*/
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        /*------------------------------------------------------------------*/
        // Get All Departments
        [HttpGet]
        public IActionResult Index()
        {
            var departmentsReadVM = _departmentManager.GetDepartments();
            return View(departmentsReadVM);
        }
        /*------------------------------------------------------------------*/
        // View Details 
        [HttpGet]
        public IActionResult Details(int id)
        {
            var departmentVM = _departmentManager.GetDepartmentById(id);
            if (departmentVM == null)
            {
                return RedirectToAction("Index");
            }

            return View(departmentVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(DepartmentCreateVM departmentCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentCreateVM);
            }

            _departmentManager.Insert(departmentCreateVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var departmentVM = _departmentManager.GetDepartmentByIdForEdit(id);
            if (departmentVM == null)
            {
                return RedirectToAction("Index");
            }

            return View(departmentVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(DepartmentEditVM departmentEditVM)
        {
            _departmentManager.Edit(departmentEditVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            _departmentManager.Delete(id);
            // Check Result
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
