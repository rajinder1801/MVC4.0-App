using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC40_Knockout_App.Models;
using MVC40_Knockout_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC40_Knockout_App.Services.Tests
{
    [TestClass()]
    public class EmployeeInfoServiceTests
    {
        private EmployeeInfoService _employeeInfoService;


        [TestInitialize]
        public void Setup()
        {
            _employeeInfoService = new EmployeeInfoService();
        }

        [TestMethod()]
        public void UpdateEmployeeTest_InputMismatch()
        {
            var inputEmp = new EmployeeInfo { EmpNo = 2 };
            var response = _employeeInfoService.UpdateEmployee(1, inputEmp);

            Assert.IsFalse(response);
        }

        [TestMethod()]
        public void UpdateEmployeeTest_ValidData()
        {
            var inputEmp = new EmployeeInfo { EmpNo = 1 };
            var response = _employeeInfoService.UpdateEmployee(1, inputEmp);

            Assert.IsTrue(response);
        }

        [TestMethod()]
        public void UpdateEmployeeTest_EmployeeNotFound()
        {
            var inputEmp = new EmployeeInfo { EmpNo = -1 };
            var response = _employeeInfoService.UpdateEmployee(-1, inputEmp);

            Assert.IsFalse(response);
        }
    }
}