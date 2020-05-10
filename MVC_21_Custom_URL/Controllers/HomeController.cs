using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_21_Custom_URL.Controllers
{
    using Models;
    // [RoutePrefix("")] // Ön takı atar. Home'nin önünde girilen değer gözükür.
    public class HomeController : Controller
    {
        NORTHWND db = new NORTHWND();
        public ActionResult GetCategories()
        {
            IEnumerable<Category> categories = db.Categories;
            return View(categories);
        }

        public ActionResult GetProducts(string name)
        {
            /* string ad = "Negan";
            ad.Trim('s', ' ', 'f', 'd', ' '); */
            IEnumerable<Product> products = db.Products.Where(p => p.CategoryID != null);
            products = products.Where(p => p.Category.CategoryName.Replace(' ', '-') == name);
            return View(products);
        }

        public ActionResult GetProduct(int id, string name)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        // Home/ListProduct
        // Home/urunListele
        // [ActionName("UrunListele")]
        [Route("List/Product")]
        public ActionResult ListProduct()
        {
            return View();
        }
    }
}