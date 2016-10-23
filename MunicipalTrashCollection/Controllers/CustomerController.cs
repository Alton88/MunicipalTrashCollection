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
    public class CustomerController : Controller
    {
        ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);

            return View(customer);
        }
    }
}