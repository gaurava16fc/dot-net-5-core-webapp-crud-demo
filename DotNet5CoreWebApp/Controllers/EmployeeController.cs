using DotNet5CoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CoreWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public EmployeeController(ApplicationDBContext applicationDBContext)
        {
            this._dbContext = applicationDBContext;
        }
        public IActionResult EmployeeList()
        {
            try
            {
                var empList = from e in _dbContext.tblEmployee
                              join d in _dbContext.tblDepartment on e.DepartmentId equals d.Id into Dep
                              from d in Dep.DefaultIfEmpty()
                              select new Employee
                              {
                                  EmployeeId = e.EmployeeId,
                                  Name = e.Name,
                                  City = e.City,
                                  Gender = e.Gender,
                                  DateOfBirth = e.DateOfBirth,
                                  DepartmentId = e.DepartmentId,
                                  Department = d == null ? "" : d.Name
                              };
                return View(empList);

            }
            catch (Exception ex)
            {
                return View();
                throw;
            }
        }

        public IActionResult Create(Employee employee)
        {
            LoadDDL();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (employee.EmployeeId == 0)
                    {
                        _dbContext.tblEmployee.Add(employee);                        
                    }
                    else
                    {
                        _dbContext.Entry(employee).State = EntityState.Modified;
                    }
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("EmployeeList");
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("EmployeeList");
            }
        }

        private void LoadDDL()
        {
            try
            {
                var depList = new List<Departments>();
                depList = _dbContext.tblDepartment.ToList();
                depList.Insert(0, new Departments { Id = -1, Name = "Select Department" });
                ViewBag.DepList = depList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                var emp = await _dbContext.tblEmployee.FindAsync(employeeId);
                if (emp != null)
                {
                    _dbContext.tblEmployee.Remove(emp);
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction("EmployeeList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EmployeeList");
            }
        }
    }
}
