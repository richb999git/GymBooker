﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymBooker1.Controllers;
using GymBooker1.Models;
using Microsoft.AspNet.Identity;

namespace GymBooker1.Views
{
    public class CalendarItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult CancelClass(string id)
        {
            var strCurrentUserId = User.Identity.GetUserId();
            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem gymClass = db.CalendarItems.Find(idInt);
            if (gymClass == null || gymClass.UserIds == "") // if user enters web address parameters manually and they are not valid
            {
                return HttpNotFound();
            }
            // get UserId list
            List<string> gymClassAttenders = gymClass.UserIds.Split(',').ToList();
            // find and delete any that match user id
            gymClassAttenders.Remove(strCurrentUserId);
            // save it
            // return view confirming delete
            gymClass.UserIds = string.Join(",", gymClassAttenders.Select(n => n.ToString()).ToArray());
            db.SaveChanges();

            var pics2 = GetPics.Get2Pics(gymClass.GymClass.Name);

            ViewBag.pic0 = "/Content/Images/Classes/" + pics2[0];
            ViewBag.pic1 = "/Content/Images/Classes/" + pics2[1];

            return View(gymClass); /// go to page showing confirmation of cancelled class

        }


        // GET: CalendarItems/BookClass/2
        // Add class to user or add user to class!
        [Authorize]
        public ActionResult BookClass(string id)
        {
            
            var strCurrentUserId = User.Identity.GetUserId();

            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CalendarItem gymClass = db.CalendarItems.Find(idInt);
            if (gymClass == null)
            {
                return HttpNotFound();
            }

            // get UserIds string and check how many people in class
            List<string> gymClassAttenders = new List<string>();
            int numInClass = gymClass.UserIds == "" ? 0 : gymClass.UserIds.Count(x => x == ',') + 1;
            if (numInClass != 0)
            {
                gymClassAttenders = gymClass.UserIds.Split(',').ToList();
            }
            
            var userInString = gymClassAttenders.Find(x => x == strCurrentUserId); 

            if (userInString != null || numInClass >= gymClass.MaxPeople)
            {
                return RedirectToAction("Index", "CalendarItems");
            }

            gymClassAttenders.Add(strCurrentUserId);
            gymClass.UserIds = string.Join(",", gymClassAttenders.Select(n => n.ToString()).ToArray());
            db.SaveChanges();

            var pics2 = GetPics.Get2Pics(gymClass.GymClass.Name);

            ViewBag.pic0 = "/Content/Images/Classes/" + pics2[0];
            ViewBag.pic1 = "/Content/Images/Classes/" + pics2[1];

            return View(gymClass); /// go to page showing confirmation of booking

        }


        // GET: CalendarItems/ClassDescription/2
        // Show description of a class
        public ActionResult ClassDescription(string id)
        {
            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem gymClass = db.CalendarItems.Find(idInt);
            if (gymClass == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserId = User.Identity.GetUserId();

            var pics2 = GetPics.Get2Pics(gymClass.GymClass.Name);

            ViewBag.pic0 = "/Content/Images/Classes/" + pics2[0];
            ViewBag.pic1 = "/Content/Images/Classes/" + pics2[1];

            return View(gymClass);
        }


        // GET: CalendarItems
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index(string fitnessClass, string classDate)
        {

            DateTime dateFrom = DateTime.Now;

            if (classDate != null)
            {
                dateFrom = DateTime.Parse(classDate);
            }

            var x = new TimetableController();
            x.UpdateCalendar();

            var Calendar = new List<CalendarItem>();
            if (dateFrom < DateTime.Now) dateFrom = DateTime.Now;
            DateTime dateTo = dateFrom.AddDays(7);

            if (fitnessClass != null && fitnessClass != "ALL")
            {
                Calendar = db.CalendarItems
                    .Where(d => d.GymClassTime >= dateFrom)
                    //.Where(d => d.GymClassTime <= dateTo)
                    .Where(d => d.GymClass.Name == fitnessClass)
                    .OrderBy(d => d.GymClassTime).ToList();
            }
            else
            {
                Calendar = db.CalendarItems
                    .Where(d => d.GymClassTime >= dateFrom)
                    //.Where(d => d.GymClassTime <= dateTo)
                    .OrderBy(d => d.GymClassTime).ToList();
            }

            ViewBag.GymClasses = db.GymClasses.ToList();
            ViewBag.ClassDate = dateFrom;
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.fitnessClass = fitnessClass;
            return View(Calendar);
        }


        // GET: MembersPage
        [Authorize]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult MembersPage()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            DateTime dateFrom = DateTime.Now;

            var x = new TimetableController();
            x.UpdateCalendar();

            var Calendar = new List<CalendarItem>();
            if (dateFrom < DateTime.Now) dateFrom = DateTime.Now;
            DateTime dateTo = dateFrom.AddDays(7);

            Calendar = db.CalendarItems
                .Where(d => d.GymClassTime >= dateFrom)
                .Where(d => d.UserIds.Contains(strCurrentUserId))
                .OrderBy(d => d.GymClassTime).ToList();           

            ViewBag.GymClasses = db.GymClasses.ToList();
            ViewBag.ClassDate = dateFrom;
            ViewBag.UserName = User.Identity.GetUserName();
            return View(Calendar);
        }



        ////////////// ADMIN AREAS FOR UPDATING LIVE TIMETABLE /////////////////

        // GET: CalendarItems
        [Authorize(Roles = "Admin")]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult CalendarViewAdmin(string fitnessClass, string classDate)
        {

            DateTime dateFrom = DateTime.Now;

            if (classDate != null)
            {
                dateFrom = DateTime.Parse(classDate);
            }

            var x = new TimetableController();
            x.UpdateCalendar();

            var Calendar = new List<CalendarItem>();
            if (dateFrom < DateTime.Now) dateFrom = DateTime.Now;
            DateTime dateTo = dateFrom.AddDays(7);

            if (fitnessClass != null && fitnessClass != "ALL")
            {
                Calendar = db.CalendarItems
                    .Where(d => d.GymClassTime >= dateFrom)
                    //.Where(d => d.GymClassTime <= dateTo)
                    .Where(d => d.GymClass.Name == fitnessClass)
                    .OrderBy(d => d.GymClassTime).ToList();
            }
            else
            {
                Calendar = db.CalendarItems
                    .Where(d => d.GymClassTime >= dateFrom)
                    //.Where(d => d.GymClassTime <= dateTo)
                    .OrderBy(d => d.GymClassTime).ToList();
            }

            ViewBag.GymClasses = db.GymClasses.ToList();
            ViewBag.ClassDate = dateFrom;
            //ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.fitnessClass = fitnessClass;
            return View(Calendar);
        }




        // GET: CalendarItems/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(idInt);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // GET: CalendarItems/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View();
        }

        // POST: CalendarItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Instructor,Duration,Hall,GymClassTime,MaxPeople,GymClassId")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                calendarItem.UserIds = "";
                db.CalendarItems.Add(calendarItem);
                db.SaveChanges();
                return RedirectToAction("CalendarViewAdmin");
            }
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View(calendarItem);
        }

        // GET: CalendarItems/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            int idInt;
            try { idInt = Int32.Parse(id); }
            catch { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            
            CalendarItem calendarItem = db.CalendarItems.Find(idInt);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            if (calendarItem.UserIds.Length != 0) ViewBag.UsersInClass = true;
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View(calendarItem);
        }

        // POST: CalendarItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Instructor,Duration,Hall,GymClassTime,MaxPeople,GymClassId,UserIds")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                if (calendarItem.UserIds == null) calendarItem.UserIds = "";
                 db.Entry(calendarItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CalendarViewAdmin");
            }
            ViewBag.ClassId = new SelectList(db.GymClasses, "Id", "Name"); //the soure of dropdownlist
            return View(calendarItem);
        }

        // GET: CalendarItems/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(idInt);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            if (calendarItem.UserIds.Length != 0)
            {
                ViewBag.UsersInClass = true;
            }
            return View(calendarItem);
        }

        // POST: CalendarItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            int idInt;
            try
            {
                idInt = Int32.Parse(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItems.Find(idInt);
            db.CalendarItems.Remove(calendarItem);
            db.SaveChanges();
            return RedirectToAction("CalendarViewAdmin");
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