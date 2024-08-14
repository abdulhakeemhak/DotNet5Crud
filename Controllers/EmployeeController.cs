using DotNet5Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDBContext _context;

        public EmployeeController(CompanyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? employeeId)
        {
            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;
            ViewBag.Religions = new SelectList(_context.Religions.ToList(), "ReligionName", "ReligionName");
            //        var religions = new List<SelectListItem>
            //{
            //    new SelectListItem { Value = "1", Text = "Christianity" },
            //    new SelectListItem { Value = "2", Text = "Islam" },
            //    new SelectListItem { Value = "3", Text = "Hinduism" },
            //    new SelectListItem { Value = "4", Text = "Buddhism" },
            //    new SelectListItem { Value = "5", Text = "Judaism" }
            //};

            // Assigning the hardcoded list to ViewBag
            //ViewBag.Religions = new SelectList(religions, "Value", "Text");
            if (employeeId == null)
            {
                return View();
            }
            else
            {
                var employee = await _context.Employees.FindAsync(employeeId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }        
        }
        
        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int employeeId, [Bind("EmployeeId,EmployeeNumber,Name,Religion,DOB,DOJ,Role,BasicSalary,JoiningDate")]
        Employee employeeData)
        {
            bool IsEmployeeExist = false;

            Employee employee = await _context.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                IsEmployeeExist = true;
            }
            else
            {
                employee = new Employee();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employee.Name = employeeData.Name;
                    employee.EmployeeNumber = employeeData.EmployeeNumber;
                    employee.Religion = employeeData.Religion;
                    employee.DOB = employeeData.DOB;
                    employee.DOJ = employeeData.DOJ;
                    employee.BasicSalary = employeeData.BasicSalary;
                    
                    employee.Role = employeeData.Role;
                    //employee.ActiveStatus = employeeData.ActiveStatus;



                    if (IsEmployeeExist)
                    {
                        _context.Update(employee);
                    }
                    else
                    {
                        _context.Add(employee);
                    }                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }

        // Employee Details
        public async Task<IActionResult> Details(int? employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
    

}
}
