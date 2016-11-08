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
        [HttpGet]
        public ActionResult PausePickUpService(int? id)
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
        public ActionResult PausePickUpService(Day day)
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);
            customer.Day.StartVacation = day.StartVacation.Value.Date;
            customer.Day.EndVacation = day.EndVacation.Value.Date;
            db.SaveChanges();
            return Content($"Vacation start date {customer.Day.StartVacation.Value.ToShortDateString()} and vacation end date {customer.Day.EndVacation.Value.ToShortDateString()}");
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
            //DateTime day = pickUpDate.PickUpDateChange.Value.Date;
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.EmailAddress == userEmail);
            customer.Day.PickUpDateChange = pickUpDate.PickUpDateChange.Value.Date;
            db.SaveChanges();
            return Content(customer.Day.PickUpDateChange.Value.ToShortDateString());
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