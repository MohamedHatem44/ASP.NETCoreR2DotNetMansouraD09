using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class DepartmentCreateVM
    {
        /*------------------------------------------------------------------*/
        [Display(Name = "Department Name")]
        public required string Name { get; set; }
        /*------------------------------------------------------------------*/
    }
}
