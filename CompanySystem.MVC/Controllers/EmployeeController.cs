using CompanySystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly IEmployeeManager _employeeManager;
        /*------------------------------------------------------------------*/
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var employeesReadVM = _employeeManager.GetEmployees();
            return View(employeesReadVM);
        }
        /*------------------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employeeReadVM = _employeeManager.GetEmployeeById(id);
            if (employeeReadVM == null)
            {
                return RedirectToAction("Index");
            }
            return View(employeeReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            var employeeCreateVM = _employeeManager.ReturnDepartmentList();
            return View(employeeCreateVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateVM employeeCreateVM)
        {
            if (!ModelState.IsValid)
            {
                employeeCreateVM = _employeeManager.ReturnDepartmentList();
                return View(employeeCreateVM);
            }
            _employeeManager.Insert(employeeCreateVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            _employeeManager.Delete(id);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
