using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ac554215MIS4200Project.DAL1;
using ac554215MIS4200Project.Models;

namespace ac554215MIS4200Project.Controllers
{
    public class enrollmentsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: enrollments
        public ActionResult Index()
        {
            var enrollments = db.enrollments.Include(e => e.course).Include(e => e.student);
            ViewBag.ID = new SelectList(db.students, "studentID", "fullName");
            return View(enrollments.ToList());
        }

        // GET: enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: enrollments/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.courses, "courseID", "title");
            ViewBag.studentID = new SelectList(db.students, "studentID", "fullName");
            return View();
        }

        // POST: enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enrollmentID,studentID,courseID")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.courses, "courseID", "title", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "firstName", enrollment.studentID);
            return View(enrollment);
        }

        // GET: enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "title", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "fullName", enrollment.studentID);
            return View(enrollment);
        }

        // POST: enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enrollmentID,studentID,courseID")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "title", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "fullName", enrollment.studentID);
            return View(enrollment);
        }

        // GET: enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enrollment enrollment = db.enrollments.Find(id);
            db.enrollments.Remove(enrollment);
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
