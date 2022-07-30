using Business_Layer.Interface;
using DataAccess_Layer.EmployeeModels;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL _employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            _employeeRL = employeeRL;
        }

        public void AddEmployee(AddEmpModel employeeModel)
        {
            try
            {
                _employeeRL.AddEmployee(employeeModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return _employeeRL.GetAllEmployees();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel GetEmployee(int employeeId)
        {
            try
            {
                return _employeeRL.GetEmployee(employeeId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeModel empModel)
        {
            try
            {
                _employeeRL.UpdateEmployee(empModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployee(int empId)
        {
            try
            {
                _employeeRL.DeleteEmployee(empId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
