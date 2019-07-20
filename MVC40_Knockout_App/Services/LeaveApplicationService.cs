using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC40_Knockout_App.Contracts;
using MVC40_Knockout_App.Models;


namespace MVC40_Knockout_App.Services
{
    /// <summary>
    /// The LeaveApplicationService implements the business logic
    /// for leave applications.
    /// </summary>
    public class LeaveApplicationService
    {
        private List<LeaveApplication> leaves;
        private IEmployeeInfoService _employeeInfoService;
        public LeaveApplicationService(IEmployeeInfoService employeeInfoService)
        {
            _employeeInfoService = employeeInfoService ?? throw new ArgumentNullException(nameof(employeeInfoService));

            leaves = new List<LeaveApplication>
            {
                new LeaveApplication{EmpNo=1, StartDate=DateTime.Now.AddDays(-1),EndDate=DateTime.Now.AddDays(1)},
                new LeaveApplication{EmpNo=2, StartDate=DateTime.Now.AddDays(-1),EndDate=DateTime.Now.AddDays(1)},
                new LeaveApplication{EmpNo=3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(1)},
                new LeaveApplication{EmpNo=4, StartDate=DateTime.Now.AddDays(-1),EndDate=DateTime.Now.AddDays(1)},
                new LeaveApplication{EmpNo=4, StartDate=DateTime.Now.AddDays(-2),EndDate=DateTime.Now.AddDays(-2)},
            };
        }

        public List<LeaveApplication> LeaveApplications { get { return leaves; }  }

        public IQueryable<LeaveApplication> FindEmployeeLeave(int id)
        {
            return leaves.Where(e => e.EmpNo == id).AsQueryable();
        }

        public IQueryable<LeaveApplicationView> LeaveApplicationViews()
        {
            // INTERVIEW_TODO: 5. Transform the LeaveApplication to a LeaveApplicationView using lambda or linq syntax
            // Details:
            // We want to return a list of LeaveApplicationView class to the presentation layer.
            // Modify the method so that it returns a IQueryable<LeaveApplicationView>
            // While there are several approaches to mapping a data object to a view objectm,
            // in this instance, please use linq/lambda to convert leaves to a queryable collection of LeaveApplicationView.
            // Question: What other mapping approaches would be better for a production application?

            var employees = _employeeInfoService.Employees;
           
            var leaveApplications = from leave in leaves
                            join employee in employees on leave.EmpNo equals employee.EmpNo
                            select new LeaveApplicationView
                            {
                                EmployeeName = employee.EmpName,
                                EmpNo = employee.EmpNo,
                                StartDate = leave.StartDate,
                                EndDate = leave.EndDate
                            };

            return leaveApplications.AsQueryable();
        }

    }
}
