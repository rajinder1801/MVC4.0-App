using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC40_Knockout_App.Controllers
{
    /// <summary>
    /// This Controller is the MVC Controller for the UI
    /// </summary>
    public class EmployeeInfoController : Controller
    {
        //
        // GET: /EmployeeInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }

    }
}
