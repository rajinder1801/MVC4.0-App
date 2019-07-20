using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC40_Knockout_App.Models
{
    public partial class EmployeeInfo
    {
        private const string salaryRegex = @"^[1-9]\d*$";

        public int EmpNo { get; set; }

        public string EmpName { get; set; }

        [RegularExpression(salaryRegex, ErrorMessage = "Salary Must Greater than 0.")]
        public decimal Salary { get; set; }

        public string DeptName { get; set; }

        public string Position { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
