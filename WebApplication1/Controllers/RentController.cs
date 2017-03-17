using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        public ActionResult RentsList()
        {
            return View();
        }

        public ActionResult RentForm()
        {
            return View();
        }


    }
}