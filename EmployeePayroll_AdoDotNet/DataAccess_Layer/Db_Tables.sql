create database EmployeePayroll_MVC_AdoDotNet
use EmployeePayroll_MVC_AdoDotNet

create table Employee(
Emp_Id int identity(1,1) primary Key,
Emp_Name varchar(250),
Profile_Img varchar(max),
Gender varchar(250),
Department varchar(max),
Salary float,
StartDate datetime,
Notes varchar(max)
)

delete from Employee where Emp_Id =4 
