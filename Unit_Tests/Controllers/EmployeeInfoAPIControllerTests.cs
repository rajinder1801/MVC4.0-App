using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC40_Knockout_App.Contracts;
using MVC40_Knockout_App.Controllers;
using MVC40_Knockout_App.Models;
using MVC40_Knockout_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVC40_Knockout_App.Controllers.Tests
{
    [TestClass()]
    public class EmployeeInfoAPIControllerTests
    {
        private Mock<IEmployeeInfoService> _employeeInfoService;

        [TestInitialize]
        public void Setup()
        {
            _employeeInfoService = new Mock<IEmployeeInfoService>();
        }

        [TestMethod()]
        public void PutEmployeeInfoTest_EmptyRequest()
        {
            _employeeInfoService.Setup(x => x.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeInfo>())).Returns(false);

            var controller = GetController(_employeeInfoService.Object);

            var response = controller.PutEmployeeInfo(1, null);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod()]
        public void PutEmployeeInfoTest_InvalidData()
        {
            _employeeInfoService.Setup(x => x.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeInfo>())).Returns(false);

            var controller = GetController(_employeeInfoService.Object);

            var response = controller.PutEmployeeInfo(1, new EmployeeInfo { EmpNo =2});

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod()]
        public void PutEmployeeInfoTest_ValidData()
        {
            _employeeInfoService.Setup(x => x.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeInfo>())).Returns(true);

            var controller = GetController(_employeeInfoService.Object);
            
            var response = controller.PutEmployeeInfo(1, new EmployeeInfo { EmpNo = 1 });

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod()]
        public void PutEmployeeInfoTest_ValidData_Exception()
        {
            _employeeInfoService.Setup(x => x.UpdateEmployee(It.IsAny<int>(), It.IsAny<EmployeeInfo>())).Returns(false);

            var controller = GetController(_employeeInfoService.Object);

            var response = controller.PutEmployeeInfo(1, new EmployeeInfo { EmpNo = 1 });

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        private EmployeeInfoAPIController GetController(IEmployeeInfoService employeeInfoService)
        {
            var controller = new EmployeeInfoAPIController(employeeInfoService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            return controller;
        }
    }
}