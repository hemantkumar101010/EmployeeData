using EmployeeData.DbContetxt;
using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            viewModel.List = await _context.Employees.ToListAsync();
            viewModel.Employee = employeeViewModel;

            List<SelectListItem> Division = new List<SelectListItem>() {
              new SelectListItem {
                     Text = "IT", Value = "IT"
                    },
             new SelectListItem {
                 Text = "Account", Value = "Account"
                 },
              new SelectListItem {
                 Text = "Payroll", Value = "Payroll"
                 },
            };
            ViewBag.Division = Division;

            return View(viewModel);
        }

       // GET: Employee/Create
        public IActionResult Create()
        {
            List<SelectListItem> Division = new List<SelectListItem>() {
              new SelectListItem {
                     Text = "IT", Value = "IT"
                    },
             new SelectListItem {
                 Text = "Account", Value = "Account"
                 },
              new SelectListItem {
                 Text = "Payroll", Value = "Payroll"
                 },
            };
            ViewBag.Division = Division;
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Division = new List<SelectListItem>() {
              new SelectListItem {
                     Text = "IT", Value = "IT"
                    },
             new SelectListItem {
                 Text = "Account", Value = "Account"
                 },
              new SelectListItem {
                 Text = "Payroll", Value = "Payroll"
                 },
            };
            ViewBag.Division = Division;
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.Employees.FindAsync(id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Division,Role")] EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeViewModelExists(employeeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var employeeViewModel = await _context.Employees.FindAsync(id);
            if (employeeViewModel != null)
            {
                _context.Employees.Remove(employeeViewModel);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          
        }


        private bool EmployeeViewModelExists(int id)
        {
          return _context.Employees.Any(e => e.Id == id);
        }
    }
}
