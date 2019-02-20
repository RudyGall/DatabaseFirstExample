using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabAdminDB.Models;

namespace LabAdminDB.Controllers
{
    public class AdminItemsController : Controller
    {
        private LabAdminDBEntities db = new LabAdminDBEntities();

        // GET: AdminItems
        public ActionResult Index()
        {
            return View(db.AdminItems.ToList());
        }

        // GET: AdminItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminItem adminItem = db.AdminItems.Find(id);
            if (adminItem == null)
            {
                return HttpNotFound();
            }
            return View(adminItem);
        }

        // GET: AdminItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,Description,Quantity,Price")] AdminItem adminItem)
        {
            if (ModelState.IsValid)
            {
                db.AdminItems.Add(adminItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminItem);
        }

        // GET: AdminItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminItem adminItem = db.AdminItems.Find(id);
            if (adminItem == null)
            {
                return HttpNotFound();
            }
            return View(adminItem);
        }

        // POST: AdminItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,Description,Quantity,Price")] AdminItem adminItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminItem);
        }

        // GET: AdminItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminItem adminItem = db.AdminItems.Find(id);
            if (adminItem == null)
            {
                return HttpNotFound();
            }
            return View(adminItem);
        }

        // POST: AdminItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminItem adminItem = db.AdminItems.Find(id);
            db.AdminItems.Remove(adminItem);
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
