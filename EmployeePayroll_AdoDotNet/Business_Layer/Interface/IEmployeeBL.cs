using DataAccess_Layer.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IEmployeeBL
    {
        void AddEmployee(AddEmpModel employeeModel);

        List<EmployeeModel> GetAllEmployees();

        EmployeeModel GetEmployee(int employeeId);

        void UpdateEmployee(EmployeeModel empModel);

        void DeleteEmployee(int empId);
    }
}
