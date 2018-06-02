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
    public class EmployeeOrdersController : Controller
    {
        private Food_OrderingEntities db = new Food_OrderingEntities();

        // GET: EmployeeOrders
        public ActionResult Index()
        {
            return View(db.EmployeeOrders.ToList());
        }

        // GET: EmployeeOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOrder employeeOrder = db.EmployeeOrders.Find(id);
            if (employeeOrder == null)
            {
                return HttpNotFound();
            }
            return View(employeeOrder);
        }

        // GET: EmployeeOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeOrder employeeOrder)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeOrders.Add(employeeOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeOrder);
        }

        // GET: EmployeeOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOrder employeeOrder = db.EmployeeOrders.Find(id);
            if (employeeOrder == null)
            {
                return HttpNotFound();
            }
            return View(employeeOrder);
        }

        // POST: EmployeeOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeOrder employeeOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeOrder);
        }

        // GET: EmployeeOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOrder employeeOrder = db.EmployeeOrders.Find(id);
            if (employeeOrder == null)
            {
                return HttpNotFound();
            }
            return View(employeeOrder);
        }

        // POST: EmployeeOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeOrder employeeOrder = db.EmployeeOrders.Find(id);
            db.EmployeeOrders.Remove(employeeOrder);
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
