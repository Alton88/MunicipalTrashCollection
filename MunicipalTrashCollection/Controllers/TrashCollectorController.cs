using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MunicipalTrashCollection.Controllers
{
    public class TrashCollectorController : Controller
    {
        // GET: TrashCollecter
        public ActionResult Index()
        {
            if(User.IsInRole("TrashCollector") || User.IsInRole("Admin"))
            return View();
            return Redirect("Home");
        }
    }
}