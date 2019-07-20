using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MVC40_Knockout_App.Contracts;
using MVC40_Knockout_App.Models;
using MVC40_Knockout_App.Services;

namespace MVC40_Knockout_App.Controllers
{
    /// <summary>
    /// EmployeeInfoAPIController is used to manage the interactions
    /// between the presentation and the application layer
    /// </summary>
    public class EmployeeInfoAPIController : ApiController
    {

        private IEmployeeInfoService _service;

        public EmployeeInfoAPIController(IEmployeeInfoService employeeInfoService)
        {
            _service = employeeInfoService;
        }
        // GET api/EmployeeInfoAPI
        public HttpResponseMessage GetEmployeeInfoes()
        {
            // INTERVIEW_TODO: 1. Return a list of Employees
            // Details: 
            // Modify this method to return a HttpResponseMessage with status code 200 and the serialised list of employees
            // in the response body.
            //
            // Question 1: 
            // This application is using a layered architecture with an API Controller that is dependant on the 
            // concrete implementation of EmployeeInfoService. 
            // This service is re-created each time the API controller is instantiated.
            // How would we improve it for a production application? - Implemented DI using Autofac Container.
            // Also, we can use caching strategies for static data as well.
            // Question 2: 
            // What are some of the anti-patterns used in this design? - Vendor Lock-in(as it is dependent on Concrete Implementaions, not abstractions.
            //HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not implemented!");
            //return response;

            var response = Request.CreateResponse(HttpStatusCode.OK, _service.Employees);
            return response;
        }

        //GET api/EmployeeInfoAPI/5
        public HttpResponseMessage GetEmployeeInfo(int id)
        {
            // INTERVIEW_TODO: 2. Return the Employee or a Not Found (404) response if the ID is not valid
            // Details:
            // Use the  EmployeeInfoService to find the employee, and return one of the following:
            // The full EmployeeInfo object if it exists OR HttpStatusCode.NotFound

            var employee = _service.FindEmployee(id);

            if (employee?.EmpNo > default(int))
                return Request.CreateResponse(HttpStatusCode.OK, employee);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not Found");
        }

        // PUT api/EmployeeInfoAPI/5
        public HttpResponseMessage PutEmployeeInfo(int id, EmployeeInfo employeeinfo)
        {
            if (employeeinfo == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            // INTERVIEW_TODO: 3. Implement the UpdateEmployee method of the employee service
            // Details: 
            // The previous developer didn't implement the UpdateEmployee function,
            // modify the existing UpdateEmployee method to find the employee, and update the record.
            // Question 1: How do we ensure that the employee exists, what should we do if they don't? - Return BadRequest
            // Question 2: What unit tests do we need to implement? - Implemented unit test for both controller and service class.
            if (ModelState.IsValid && id == employeeinfo.EmpNo)
            {
                var success = _service.UpdateEmployee(id, employeeinfo);

                return success ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);            
        }

        // POST api/EmployeeInfoAPI
        public HttpResponseMessage PostEmployeeInfo(EmployeeInfo employeeinfo)
        {
            // INTERVIEW_TODO: 4. Validate the employee, and return a meaningful error if it is not valid
            // Details:
            // We need to modify the application to ensure that all employees have salary > 0, and a unique EmpNo
            // The user should be notified with a meaningful error message if the request is not valid.
            // The check should be done in the presentation as well as the business layer.
            // Please modify the Create.cshtml file (it contains all the javascript code) to handle the validation logic.
            // Question 1: There are several approaches to solve this, what is the best one for a production application? - Validate at both client and server side.
            // Question 2: How would you change the application UI design to improve the user interaction? -  Changed the input type pf employee number and salary.

            var errorResponse = ValidateEmployeeInfo(employeeinfo);
            if (ModelState.IsValid && string.IsNullOrWhiteSpace(errorResponse))
            {
                _service.InsertEmployee(employeeinfo);
                var response = Request.CreateResponse(HttpStatusCode.Created, employeeinfo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employeeinfo.EmpNo }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }        

        // DELETE api/EmployeeInfoAPI/5
        public HttpResponseMessage DeleteEmployeeInfo(int id)
        {
            _service.DeleteEmployee(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private string ValidateEmployeeInfo(EmployeeInfo employeeinfo)
        {
            var errorString = string.Empty;

            if (employeeinfo?.Salary <= default(decimal))
                errorString = "Salary must be greater than 0.";

            if(employeeinfo?.EmpNo > default(int))
            {
                if (_service.FindEmployee(employeeinfo.EmpNo)?.EmpNo > default(int))
                {
                    if (string.IsNullOrWhiteSpace(errorString))
                        errorString = "Employee No already in use.";
                    else
                        errorString = "\nEmployee No already in use.";
                }
            }

            return errorString;
        }
    }
}