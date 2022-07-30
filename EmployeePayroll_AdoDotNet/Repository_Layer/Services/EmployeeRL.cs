using DataAccess_Layer.EmployeeModels;
using Microsoft.Extensions.Configuration;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository_Layer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly string connectionString;

        public EmployeeRL(IConfiguration configuraton)
        {
            connectionString = configuraton.GetConnectionString("EmpPayroll");
        }
        public void AddEmployee(AddEmpModel emp)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    //Added a stored Procedure for adding Employee into database
                    SqlCommand com = new SqlCommand("spAddEmployee", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Emp_Name ", emp.Emp_Name);
                    com.Parameters.AddWithValue("@Profile_Img", emp.Profile_Img);
                    com.Parameters.AddWithValue("@Gender", emp.Gender);
                    com.Parameters.AddWithValue("@Department", emp.Department);
                    com.Parameters.AddWithValue("@Salary", emp.Salary);
                    com.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    com.Parameters.AddWithValue("@Notes", emp.Notes);
                    var result = com.ExecuteNonQuery();
                }
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
                List<EmployeeModel> employees = new List<EmployeeModel>();
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("Select * From Employee", connection);
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();
                        emp.Emp_Id = reader["Emp_Id"] == DBNull.Value ? default : reader.GetInt32("Emp_Id");
                        emp.Emp_Name = reader["Emp_Name"] == DBNull.Value ? default : reader.GetString("Emp_Name");
                        emp.Profile_Img = reader["Profile_Img"] == DBNull.Value ? default : reader.GetString("Profile_Img");
                        emp.Gender = reader["Gender"] == DBNull.Value ? default : reader.GetString("Gender");
                        emp.Department = reader["Department"] == DBNull.Value ? default : reader.GetString("Department");
                        emp.Salary = reader["Salary"] == DBNull.Value ? default : reader.GetDouble("Salary");
                        emp.StartDate = reader["StartDate"] == DBNull.Value ? default : reader.GetDateTime("StartDate");
                        emp.Notes = reader["Notes"] == DBNull.Value ? default : reader.GetString("Notes");
                        employees.Add(emp);
                    }
                    return employees;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 

        public EmployeeModel GetEmployee(int empId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("Select * From Employee Where Emp_Id = "+empId+"", connection);
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();
                        emp.Emp_Id = reader["Emp_Id"] == DBNull.Value ? default : reader.GetInt32("Emp_Id");
                        emp.Emp_Name = reader["Emp_Name"] == DBNull.Value ? default : reader.GetString("Emp_Name");
                        emp.Profile_Img = reader["Profile_Img"] == DBNull.Value ? default : reader.GetString("Profile_Img");
                        emp.Gender = reader["Gender"] == DBNull.Value ? default : reader.GetString("Gender");
                        emp.Department = reader["Department"] == DBNull.Value ? default : reader.GetString("Department");
                        emp.Salary = reader["Salary"] == DBNull.Value ? default : reader.GetDouble("Salary");
                        emp.StartDate = reader["StartDate"] == DBNull.Value ? default : reader.GetDateTime("StartDate");
                        emp.Notes = reader["Notes"] == DBNull.Value ? default : reader.GetString("Notes");
                        connection.Close();
                        return emp;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeModel emp)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    //Added a stored Procedure for adding Employee into database
                    SqlCommand com = new SqlCommand("spUpdateEmployee", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Emp_Id ", emp.Emp_Id);
                    com.Parameters.AddWithValue("@Emp_Name ", emp.Emp_Name);
                    com.Parameters.AddWithValue("@Profile_Img", emp.Profile_Img);
                    com.Parameters.AddWithValue("@Gender", emp.Gender);
                    com.Parameters.AddWithValue("@Department", emp.Department);
                    com.Parameters.AddWithValue("@Salary", emp.Salary);
                    com.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    com.Parameters.AddWithValue("@Notes", emp.Notes);
                    var result = com.ExecuteNonQuery();
                }
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
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("delete from Employee where Emp_Id = " + empId + "", connection);
                    com.CommandType = CommandType.Text;
                    var result = com.ExecuteNonQuery();
                
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
