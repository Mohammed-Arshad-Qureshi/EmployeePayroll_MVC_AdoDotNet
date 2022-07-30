using Business_Layer.Interface;
using DataAccess_Layer.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeePayroll_AdoDotNet.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL _employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _employeeBL.GetAllEmployees();
                return View(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmpModel empModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeBL.AddEmployee(empModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            try
            {
                var result = _employeeBL.GetEmployee(id);
                return View(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeBL.UpdateEmployee(employeeModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult DeleteEmployee(int? id)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeBL.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
