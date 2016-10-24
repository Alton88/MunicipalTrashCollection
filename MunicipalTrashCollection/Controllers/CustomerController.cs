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
        public ActionResult Edit()
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);

            return View();
        }
        public ActionResult EditPickUpInfo(int? id)
        {

            return View();
        }
        public ActionResult EditPickUpInfo(Customer customer)
        {

            return View();
        }
        [HttpGet]
        public ActionResult TempPickUpDay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult TempPickUpDay(Day pickUpDate)
        {
            
            return Content(pickUpDate.PickUpDateChange.ToString());
        }
        [HttpGet]
        public ActionResult EditCustomerDay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomerDay(Address address)
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);
            customer.Day.Name = address.Day.Days.ToString();
            var dateChange = customer.Day.Name;

            db.SaveChanges();
            return View("Index",customer);
        }
    }
}