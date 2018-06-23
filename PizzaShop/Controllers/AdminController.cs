using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class AdminController : Controller
    {

        private PizzaShopEntities db = new PizzaShopEntities();

        // GET: /Admin/Customers
        public ActionResult CustomersList()
        {
            var customers = db.Customer.ToList();
            return View(customers);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customer.PasswordHash = Cryptography.Hash(customer.Password);
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("CustomersList");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(customer);
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}