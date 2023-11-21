using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WaterTracker.Models;

namespace WaterTracker.Controllers
{
    public class TrackersController : Controller
    {
        private TrackersContext db = new TrackersContext();

        // GET: Trackers
        public ActionResult Index()
        {
            return View(db.Tracker.ToList());
        }

        // GET: Trackers/Details/5
        public ActionResult Details(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Tracker.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // GET: Trackers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,VolumeOfWaterConsumed")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Tracker.Add(tracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tracker);
        }

        // GET: Trackers/Edit/5
        public ActionResult Edit(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Tracker.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,VolumeOfWaterConsumed")] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tracker);
        }

        // GET: Trackers/Delete/5
        public ActionResult Delete(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracker tracker = db.Tracker.Find(id);
            if (tracker == null)
            {
                return HttpNotFound();
            }
            return View(tracker);
        }

        // POST: Trackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(bool id)
        {
            Tracker tracker = db.Tracker.Find(id);
            db.Tracker.Remove(tracker);
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
