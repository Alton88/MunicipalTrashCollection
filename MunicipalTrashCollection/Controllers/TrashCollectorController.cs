using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MunicipalTrashCollection.Models;
using Microsoft.AspNet.Identity;
using System.Net;
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
        public ActionResult Route(Address routeZip)
        {

            var pickUpDay = DateTime.Now.DayOfWeek.ToString();
            
            var addresses = db.Addresses.Include(a => a.Customer).Include(x => x.Day).ToList();
            List<Address> stops = new List<Address>();
            foreach (Address address in addresses) {
                if (address.ZipCode == routeZip.ZipCode && pickUpDay == address.Day.Name && address.IsActive)
                {
                    stops.Add(address);
                    //address.Customer.Balance += 25;
                }
                
            }
            return View(stops);

        }
    }
}