using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class ProductController : Controller
    {

        PizzaShopEntities db = new PizzaShopEntities();

        // GET: Product
        public ActionResult Index()
        {
            Product product = new Product();
            ViewBag.products = db.Product.Where(p => p.IsInSortiment && p.CategoryID != 4).ToList();
            ViewBag.toppings = db.Product.Where(p => p.IsInSortiment && p.CategoryID == 4).ToList();
            return View();
        }

        /*
        [NonAction]
        public ActionResult AddProduct(int id, int amount)
        {
            OrderHasProduct orderHasProduct = new OrderHasProduct();
            if (Session["cart"] == null)
            {
                List<OrderHasProduct> cart = new List<OrderHasProduct>();
                cart.Add(new OrderHasProduct { ProductID = id, amount = amount });
                Session["cart"] = cart;
            }
            else
            {
                List<OrderHasProduct> cart = (List<OrderHasProduct>)Session["cart"];
                int index = cart.FindIndex(i => i.ProductID == id);
                if (isInCart(id))
                {
                    cart[index].amount += amount;
                }
                else
                {
                    cart.Add(new OrderHasProduct { ProductID = id, amount = amount });
                }
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        public ActionResult RemoveProduct(int id)
        {
            List<OrderHasProduct> cart = (List<OrderHasProduct>)Session["cart"];
            cart.RemoveAt(cart.FindIndex(i => i.ProductID == id));
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private bool isInCart(int id)
        {
            List<OrderHasProduct> cart = (List<OrderHasProduct>)Session["cart"];
            return cart.Exists(x => x.ProductID == id);
        }
        */
    }
}