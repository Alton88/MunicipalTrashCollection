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
            var addresses = db.Addresses.ToList();
            if(User.IsInRole("TrashCollector") || User.IsInRole("Admin"))
            return View();
            return View("ReadOnly");
        }
        [HttpPost]
        public ActionResult Route(Address address)
        {
            if (address.ZipCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Address> addresses = db.Addresses.ToList();
            List<Address> stops = new List<Address>();
            foreach (Address a in addresses) {
                if (a.ZipCode == address.ZipCode) { stops.Add(address); }
            }
            return View(stops);

        }
    }
}