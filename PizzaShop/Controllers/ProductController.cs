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
            /*
            Product product = new Product();
            ViewBag.products = db.Product.Where(p => p.IsInSortiment && p.CategoryID != 4).ToList();
            ViewBag.toppings = db.Product.Where(p => p.IsInSortiment && p.CategoryID == 4).ToList();
            */
            var products = (from p in db.Product
                            where p.IsInSortiment
                            select new
                            {
                                ID = p.ID,
                                CategoryID = p.CategoryID,
                                Name = p.Name,
                                Price = p.Price
                            }).ToList()
                            .Select(x => new ProductViewModel()
                            {
                                ID = x.ID,
                                CategoryID = x.CategoryID,
                                Name = x.Name,
                                Price = x.Price
                            });

            return View(products);
        }

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
                return View("Index", "Cart");
            }
            return View("Index");
        }

    }
}