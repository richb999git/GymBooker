﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymBooker1.Models;

namespace GymBooker1.Controllers
{
    public class StdGymClassTimetablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StdGymClassTimetables
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.StdGymClassTimetables.OrderBy(x => x.Day).ThenBy(x => x.Hour).ThenBy(x => x.Minute).ToList());
        }

        // GET: StdGymClassTimetables/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StdGymClassTimetable stdGymClassTimetable = db.StdGymClassTimetables.Find(id);
            if (stdGymClassTimetable == null)
            {
                return HttpNotFound();
            }
            return View(stdGymClassTimetable);
        }

        // GET: StdGymClassTimetables/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name");//the soure of dropdownlist
            return View();
        }

        // POST: StdGymClassTimetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Instructor,Hall,Duration,Day,Hour,Minute,MaxPeople,Deleted,GymClassId")] StdGymClassTimetable stdGymClassTimetable)
        {
            if (ModelState.IsValid)
            {
                db.StdGymClassTimetables.Add(stdGymClassTimetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name");//the soure of dropdownlist
            return View(stdGymClassTimetable);
        }

        // GET: StdGymClassTimetables/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StdGymClassTimetable stdGymClassTimetable = db.StdGymClassTimetables.Find(id);
            if (stdGymClassTimetable == null)
            {
                return HttpNotFound();
            }
 
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View(stdGymClassTimetable);
        }

        // POST: StdGymClassTimetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Instructor,Hall,Duration,Day,Hour,Minute,MaxPeople,Deleted,GymClassId")] StdGymClassTimetable stdGymClassTimetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stdGymClassTimetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View(stdGymClassTimetable); //the soure of dropdownlist
        }



        // GET: StdGymClassTimetables/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StdGymClassTimetable stdGymClassTimetable = db.StdGymClassTimetables.Find(id);
            if (stdGymClassTimetable == null)
            {
                return HttpNotFound();
            }

            ViewBag.Time = DateTime.Now.Date + new TimeSpan(stdGymClassTimetable.Hour, stdGymClassTimetable.Minute, 0);

            return View(stdGymClassTimetable);
        }

        // POST: StdGymClassTimetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            StdGymClassTimetable stdGymClassTimetable = db.StdGymClassTimetables.Find(id);
            db.StdGymClassTimetables.Remove(stdGymClassTimetable);
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
