using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public sealed class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            //ActionResult result;

            //object model = Request.Url.PathAndQuery;

            //if (!Request.IsAjaxRequest())
            //    result = View(model);
            //else
            //    result = PartialView("_NotFound", model);

            //return result;
            return View("Error404");
        }
    }
}