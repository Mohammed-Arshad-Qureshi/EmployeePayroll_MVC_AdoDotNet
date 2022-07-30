create procedure spAddEmployee(
@Emp_Name varchar(250), 
@Profile_Img varchar(max),
@Gender varchar(250),
@Department varchar(max),
@Salary float,
@StartDate datetime,
@Notes varchar(max)
)
As
Begin try
insert into Employee(Emp_Name,Profile_Img,Gender,Department,Salary,StartDate,Notes) values(@Emp_Name,@Profile_Img,@Gender,@Department,@Salary,@StartDate,@Notes)
--select * from Users where Email=@Email
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spAddEmployee 'adfd','Profile_Img','Male','CSE',2000.0,'2022-07-29','notes'
select * from Employee

--Update Employee -----------------------------------------
create procedure spUpdateEmployee(
@Emp_Id int,
@Emp_Name varchar(250), 
@Profile_Img varchar(max),
@Gender varchar(250),
@Department varchar(max),
@Salary float,
@StartDate datetime,
@Notes varchar(max)
)
As
Begin try
Update Employee  set Emp_Name=@Emp_Name,Profile_Img=@Profile_Img ,Gender=@Gender,Department=@Department,Salary=@Salary,StartDate=@StartDate,Notes=@Notes where Emp_Id = @Emp_Id;
--select * from Users where Email=@Email
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH



