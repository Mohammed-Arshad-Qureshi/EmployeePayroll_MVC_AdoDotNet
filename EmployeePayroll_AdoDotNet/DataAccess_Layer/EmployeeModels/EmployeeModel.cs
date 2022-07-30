using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess_Layer.EmployeeModels
{
    public class EmployeeModel
    {
        public int Emp_Id { get; set; }

        [Required]
        public string Emp_Name { get; set; }

        [Required]
        public string Profile_Img { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Range(0,500000)]
        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
