using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcSmallScreen.Models;

namespace MvcSmallScreen.Controllers
{
    [Authorize(Roles = "admin")]
    public class StoreManagerController : Controller
    {
        private PCStoreEntities db = new PCStoreEntities();

        // GET: /StoreManager/
        public ActionResult Index()
        {
            var goods = db.Goods.Include(g => g.Laptop).Include(g => g.products);
            return View(goods.ToList());
        }

        // GET: /StoreManager/Details/1
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.LaptopId = new SelectList(db.Laptops, "LaptopId", "Name");
            ViewBag.ProductId = new SelectList(db.products, "ProductId", "Name");
            return View();
        }

        // POST: /StoreManager/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GoodsId,ProductId,LaptopId,Title,Price,GoodArtUrl")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(goods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaptopId = new SelectList(db.Laptops, "LaptopId", "Name", goods.LaptopId);
            ViewBag.ProductId = new SelectList(db.products, "ProductId", "Name", goods.ProductId);
            return View(goods);
        }

        // GET: /StoreManager/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaptopId = new SelectList(db.Laptops, "LaptopId", "Name", goods.LaptopId);
            ViewBag.ProductId = new SelectList(db.products, "ProductId", "Name", goods.ProductId);
            return View(goods);
        }

        // POST: /StoreManager/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GoodsId,ProductId,LaptopId,Title,Price,GoodArtUrl")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaptopId = new SelectList(db.Laptops, "LaptopId", "Name", goods.LaptopId);
            ViewBag.ProductId = new SelectList(db.products, "ProductId", "Name", goods.ProductId);
            return View(goods);
        }

        // GET: /StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goods goods = db.Goods.Find(id);
            db.Goods.Remove(goods);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
