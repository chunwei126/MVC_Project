using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingSite_BackEnd.Site.Models.EFModels;

namespace ShoppingSite_BackEnd.Site.Controllers
{
    public class OrderItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: OrderItems
        public ActionResult Index()
        {
            var orderItems = db.OrderItems.Include(o => o.Order).Include(o => o.Product);
            return View(orderItems.ToList());
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Receiver");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: OrderItems/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,ProductId,ProductName,Qty,Price,SubTotal")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Receiver", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Receiver", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,ProductId,ProductName,Qty,Price,SubTotal")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Receiver", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
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
