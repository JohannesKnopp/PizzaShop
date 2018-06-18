using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {

        PizzaShopEntities db = new PizzaShopEntities();

        public ActionResult Index()
        {
            List<Product> products = db.Product.ToList();
            ViewBag.products = products;
            return View();
        }


        public ActionResult Category(int categoryId)
        {
            List<Product> products = db.Product.Where(p => p.CategoryID == categoryId).ToList();
            return View(products);
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