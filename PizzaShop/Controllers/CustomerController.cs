using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class CustomerController : Controller
    {

        PizzaShopEntities db = new PizzaShopEntities();

        // GET: Customer
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {

                #region Username exists
                if (UsernameExists(customer.Username))
                {
                    ModelState.AddModelError("UsernameExists", "Username is already taken");
                    return View(customer);
                }
                #endregion

                #region  Password Hashing 
                customer.PasswordHash = Cryptography.Hash(customer.PasswordHash);
                customer.ConfirmPassword = Cryptography.Hash(customer.ConfirmPassword); //
                #endregion
                //customer.IsEmailVerified = false;

                #region Save to 
                db.Customer.Add(customer);
                db.SaveChanges();

                /*
                //Send Email to User
                SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                message = "Registration successfully done. Account activation link " +
                    " has been sent to your email id:" + user.EmailID;
                */
                message = "Registration Successfull!";
                Status = true;
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            ViewBag.CustomerData = customer;
            return View();
        }

        [NonAction]
        public bool UsernameExists(string username)
        {
            var query = db.Customer.Where(c => c.Username == username).FirstOrDefault();
            return query != null;
        }
    }
}