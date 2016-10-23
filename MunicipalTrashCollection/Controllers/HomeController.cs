using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MunicipalTrashCollection.Models;
using Microsoft.AspNet.Identity;

namespace MunicipalTrashCollection.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            //var userEmail = User.Identity.Name;
            //var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}