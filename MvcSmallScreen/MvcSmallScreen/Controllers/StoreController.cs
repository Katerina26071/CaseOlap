using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSmallScreen.Models;

namespace MvcSmallScreen.Controllers
{
    public class StoreController : Controller
    {
        PCStoreEntities storeDB = new PCStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var products = storeDB.products.ToList();
            return View(products);
        }

        //
        // GET: /Store/ProductsMenu
        [ChildActionOnly]
        public ActionResult ProductsMenu()
        {
            var products = storeDB.products.ToList();
            return PartialView(products);
        }

        //
        // GET: /Store/Browse?product=Tablet
        public ActionResult Browse(string products)
        {
            var productModel = storeDB.products.Include("Goods")
                .Single(g => g.Name == products);

            return View(productModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var goods = storeDB.Goods.Find(id);
            return View(goods);
        }
	}
}