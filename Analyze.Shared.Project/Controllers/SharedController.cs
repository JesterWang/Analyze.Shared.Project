using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analyze.Shared.Project.Controllers
{
    public class SharedController : BaseController
    {
        // GET: Shared
        public ActionResult Index()
        {
            string _username = GetUserEmplyeeName();
            ViewData["emplyee_name"] = _username;
            return View();
        }
    }
}