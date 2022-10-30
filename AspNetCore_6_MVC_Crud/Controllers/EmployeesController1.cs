using AspNetCore_6_MVC_Crud.Data;
using AspNetCore_6_MVC_Crud.Models;
using AspNetCore_6_MVC_Crud.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Cors;

namespace AspNetCore_6_MVC_Crud.Controllers
{
    [EnableCors("ReglasCors")]
    public class EmployeesController1 : Controller
    {
        //DataContext injection
        private readonly DataContext context;
        public EmployeesController1(DataContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await context.Employees.ToListAsync();
                return View(employees);
            } catch (Exception ex)
            {
                Console.WriteLine("Error while loading the employees data: " + ex.Message);
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeModel employeeRequest)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = employeeRequest.Name,
                    Department = employeeRequest.Department,
                    Email = employeeRequest.Email,
                    Salary = employeeRequest.Salary,
                    DateOfBirth = employeeRequest.DateOfBirth,
                };

                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                Console.WriteLine("Employee saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployeer(Guid Id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            if (employee != null)
            {
                UpdateEmployeeModel employeeToUpdate = new UpdateEmployeeModel() {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email,
                };

                return View(employeeToUpdate);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployeer(UpdateEmployeeModel model)
        {
            var employee = await context.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Email = model.Email;
                employee.Department = model.Department;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
              
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployeer(Guid id)
        {
            var employee = await context.Employees.FindAsync(id);
            
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index"); 
        }
    }
}
