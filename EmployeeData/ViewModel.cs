using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;

namespace EmployeeData
{
    public class ViewModel
    {   
        public IEnumerable<EmployeeViewModel> List { get; set; }
        public EmployeeViewModel Employee { get; set; }
       // public IEnumerable<SelectListItem> Division { get; set; }
    }
}
