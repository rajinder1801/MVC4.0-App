using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC40_Knockout_App.Services;
using MVC40_Knockout_App.Models;
using System.Linq;
using MVC40_Knockout_App.Contracts;

namespace Unit_Tests
{
    [TestClass]
    public class EmployeeUnitTests
    {
        [TestMethod]
        public void TestLeaveApplicationView()
        {
            IEmployeeInfoService employeeInfoService = new EmployeeInfoService();
            LeaveApplicationService service = new LeaveApplicationService(employeeInfoService);

            var result = service.LeaveApplicationViews();

            Assert.AreEqual(5, result.ToList().Count);
        }

        [TestMethod]
        public void TestLeaveApplicationView_2LeaveDays()
        {
            IEmployeeInfoService employeeInfoService = new EmployeeInfoService();
            LeaveApplicationService service = new LeaveApplicationService(employeeInfoService);

            var result = service.LeaveApplicationViews();

            Assert.AreEqual(3, result.First(x=>x.EmpNo == 1).LeaveDays);
        }

        [TestMethod]
        public void TestLeaveApplicationView_1LeaveDay()
        {
            IEmployeeInfoService employeeInfoService = new EmployeeInfoService();
            LeaveApplicationService service = new LeaveApplicationService(employeeInfoService);

            var result = service.LeaveApplicationViews();
            var leaveApplication = result.First(x => x.EmpNo == 4 && x.EndDate.Equals(x.StartDate));

            Assert.AreEqual(1, leaveApplication.LeaveDays);
        }

        [TestMethod]
        public void TestLeaveApplicationView_TotalLeaveDays()
        {
            IEmployeeInfoService employeeInfoService = new EmployeeInfoService();
            LeaveApplicationService service = new LeaveApplicationService(employeeInfoService);

            var result = service.LeaveApplicationViews();

            var totalLeaves = result.Where(x => x.EmpNo == 4).Select(x=>x.LeaveDays).DefaultIfEmpty(0).Sum();

            Assert.AreEqual(4, totalLeaves);
        }
    }
}
