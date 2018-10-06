using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Frequency.Edu.Models;
using PagedList;

namespace Frequency.Edu.Controllers
{
    public class CourseController : Controller
    {
        private FrequencyEduDBEntities db = new FrequencyEduDBEntities();

        // GET: Course
        public ActionResult Index(string sortOrder, string searchstring, string currentFilter, int? page)
        {
            var courses = db.Courses.Include(c => c.ExamDetail).Include(c => c.Trainer);

            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentFilter;
            }

            ViewBag.currentFilter = searchstring;

            var Course = from r in courses
                        select r;

            if (!String.IsNullOrEmpty(searchstring))
            {
                courses = courses.Where(r => r.CourseName.ToUpper().Contains(searchstring.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Course = courses.OrderByDescending(r => r.CourseName);
                    break;
                default:
                    Course = courses.OrderBy(r => r.CourseName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(Course.ToPagedList(pageNumber, pageSize));
        }

        // GET: Course/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create

        public ActionResult Create()
        {
            ViewBag.ExamDetailID = new SelectList(db.ExamDetails, "ExamDetailID", "ExamName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseFees,Schedule,CourseDuration,TrainerID,ExamDetailID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamDetailID = new SelectList(db.ExamDetails, "ExamDetailID", "ExamName", course.ExamDetailID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            return View(course);
        }

        // GET: Course/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamDetailID = new SelectList(db.ExamDetails, "ExamDetailID", "ExamName", course.ExamDetailID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseFees,Schedule,CourseDuration,TrainerID,ExamDetailID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamDetailID = new SelectList(db.ExamDetails, "ExamDetailID", "ExamName", course.ExamDetailID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            return View(course);
        }

        // GET: Course/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
