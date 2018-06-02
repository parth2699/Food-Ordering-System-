using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.DAL;
using OnlineFoodOrderingSystem.Models;

namespace WebApplication1.Controllers
{
    public class OrderedFooodsController : Controller
    {
        private Food_OrderingEntities db = new Food_OrderingEntities();

        // GET: OrderedFooods
        public ActionResult Index()
        {
            var orderedFooods = db.OrderedFooods.Include(o => o.CustomerOrder).Include(o => o.Product);
            return View(orderedFooods.ToList());
        }

        // GET: OrderedFooods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedFoood orderedFoood = db.OrderedFooods.Find(id);
            if (orderedFoood == null)
            {
                return HttpNotFound();
            }
            return View(orderedFoood);
        }

        // GET: OrderedFooods/Create
        public ActionResult Create()
        {
            ViewBag.CustomerOrderId = new SelectList(db.EmployeeOrders, "Id", "FirstName");
            ViewBag.ProductId = new SelectList(db.Menus, "ID", "Name");
            return View();
        }

        // POST: OrderedFooods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CustomerOrderId,Quantity")] OrderedFoood orderedFoood)
        {
            if (ModelState.IsValid)
            {
                db.OrderedFooods.Add(orderedFoood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerOrderId = new SelectList(db.EmployeeOrders, "Id", "FirstName", orderedFoood.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Menus, "ID", "Name", orderedFoood.ProductId);
            return View(orderedFoood);
        }

        // GET: OrderedFooods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedFoood orderedFoood = db.OrderedFooods.Find(id);
            if (orderedFoood == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerOrderId = new SelectList(db.EmployeeOrders, "Id", "FirstName", orderedFoood.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Menus, "ID", "Name", orderedFoood.ProductId);
            return View(orderedFoood);
        }

        // POST: OrderedFooods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CustomerOrderId,Quantity")] OrderedFoood orderedFoood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderedFoood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerOrderId = new SelectList(db.EmployeeOrders, "Id", "FirstName", orderedFoood.CustomerOrderId);
            ViewBag.ProductId = new SelectList(db.Menus, "ID", "Name", orderedFoood.ProductId);
            return View(orderedFoood);
        }

        // GET: OrderedFooods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedFoood orderedFoood = db.OrderedFooods.Find(id);
            if (orderedFoood == null)
            {
                return HttpNotFound();
            }
            return View(orderedFoood);
        }

        // POST: OrderedFooods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderedFoood orderedFoood = db.OrderedFooods.Find(id);
            db.OrderedFooods.Remove(orderedFoood);
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
