using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu");
        }

        public ActionResult StylishExit()
        {
            return Redirect("http://www.linkedin.com/in/marcus-jin"); 
        }
    }
}