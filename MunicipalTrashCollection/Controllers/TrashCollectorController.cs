using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Net;
using MunicipalTrashCollection.Models;
namespace MunicipalTrashCollection.Controllers
{
    public class TrashCollectorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: TrashCollecter
        public ActionResult Index()
        {           
            if(User.IsInRole("TrashCollector") || User.IsInRole("Admin"))
            return View();
            return View("ReadOnly");
        }
        public ActionResult Route(string zip)
        {
            if (zip == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Address> addresses = db.Addresses.ToList();
            List<Address> stops = new List<Address>();
            foreach (Address address in addresses) {
                if (zip == address.ZipCode) { stops.Add(address); }
            }
            return View(stops);

        }
    }
}