using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<ProductViewModel> cart = (List < ProductViewModel > )Session["cart"];
            return View(cart);
        }

        /*
        public EmptyResult AddProduct(int id, int amount)
        {
            OrderHasProduct orderHasProduct = new OrderHasProduct();
            if(Session["cart"] == null)
            {
                List<OrderHasProduct> cart = new List<OrderHasProduct>();
                cart.Add(new OrderHasProduct { ProductID = id, amount = amount });
                Session["cart"] = cart;
            }
            else
            {
                List<OrderHasProduct> cart = (List<OrderHasProduct>)Session["cart"];
                int index = cart.FindIndex(i => i.ProductID == id);
                if(isInCart(id))
                {
                    cart[index].amount += amount;
                }
                else
                {
                    cart.Add(new OrderHasProduct { ProductID = id, amount = amount });
                }
            }
            return null;
        }

    */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(int id, int amount)
        {
            if (ModelState.IsValid)
            {
                if (Session["cart"] == null)
                {
                    List<ProductViewModel> cart = new List<ProductViewModel>();
                    cart.Add(new ProductViewModel { ID = id, Amount = amount });
                    Session["cart"] = cart;
                }
                else
                {
                    List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
                    if (cart.Where(x => x.ID == id).Count() < 1)
                    {
                        cart.Add(new ProductViewModel { ID = id, Amount = amount });
                    }
                    else
                    {
                        cart.Where(x => x.ID == id).ToList().ForEach(s => s.Amount += amount);
                    }
                    Session["cart"] = cart;
                }
                return View("Index");
            }
            return RedirectToAction("Index", "Product");
        }

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
    }
}