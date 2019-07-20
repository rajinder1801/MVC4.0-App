using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC40_Knockout_App.Contracts;
using MVC40_Knockout_App.Models;


namespace MVC40_Knockout_App.Services
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private List<EmployeeInfo> employees;

        public EmployeeInfoService()
        {
            employees = new List<EmployeeInfo>
            {
                new EmployeeInfo{DeptName = "HR", Position="Manager", EmpName="Keith Richards", EmpNo=1, Salary=80000, DateOfBirth = DateTime.Parse("2000-12-03") },
                new EmployeeInfo{DeptName = "Executive", Position="CEO", EmpName="Mick Jagger", EmpNo=2, Salary=100000, DateOfBirth = DateTime.Parse("1969-01-01") },
                new EmployeeInfo{DeptName = "R&D", Position="Programmer", EmpName="Bill Wyman", EmpNo=3, Salary=85000, DateOfBirth = DateTime.Parse("1980-01-08") },
                new EmployeeInfo{DeptName = "R&D", Position="Product Owner", EmpName="Ronnie Wood", EmpNo=4, Salary=90000, DateOfBirth = DateTime.Parse("1999-12-01") },
                new EmployeeInfo{DeptName = "Sales", Position="Business Development Manager", EmpName="Charlie Watts", EmpNo=5, Salary=95000, DateOfBirth = null},
            };
        }

        public List<EmployeeInfo> Employees { get { return employees; }  }
        
        public EmployeeInfo FindEmployee(int id)
        {
            return employees.Where(e => e.EmpNo == id).FirstOrDefault();
        }

        public bool UpdateEmployee(int id, EmployeeInfo employee)
        {
            var success = false;
            try
            {
                if (employee?.EmpNo == id)
                {
                    var index = employees.FindIndex(x => x.EmpNo == id);
                    if (index >= default(int))
                    {
                        employees[index] = employee;
                        success = true;
                    }
                }
            }
            catch (Exception)
            {
            }

            return success;
        }

        public void InsertEmployee(EmployeeInfo employee)
        {
            employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            var empToDelete = FindEmployee(id);
            if (empToDelete != null)
            {
                employees.Remove(empToDelete);
            }
        }
    }
}
