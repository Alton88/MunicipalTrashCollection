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
            return View();
        }
    }
}