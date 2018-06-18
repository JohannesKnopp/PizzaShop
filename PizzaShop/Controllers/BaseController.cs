using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class BaseController : Controller
    {

        protected PizzaShopEntities _db = new PizzaShopEntities();

        // GET: Base
        public ActionResult Index()
        {
            return View();
        }


    }
}