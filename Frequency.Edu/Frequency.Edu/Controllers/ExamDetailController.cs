using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Frequency.Edu.Models;

namespace Frequency.Edu.Controllers
{
    public class ExamDetailController : Controller
    {
        private FrequencyEduDBEntities db = new FrequencyEduDBEntities();

        // GET: ExamDetail
        public ActionResult Index()
        {
            return View(db.ExamDetails.ToList());
        }

        // GET: ExamDetail/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // GET: ExamDetail/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ExamDetailID,ExamName,ExamDate,ExternalMarks,EvidenceMarks")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExamDetails.Add(examDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examDetail);
        }

        // GET: ExamDetail/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // POST: ExamDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ExamDetailID,ExamName,ExamDate,ExternalMarks,EvidenceMarks")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examDetail);
        }

        // GET: ExamDetail/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // POST: ExamDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamDetail examDetail = db.ExamDetails.Find(id);
            db.ExamDetails.Remove(examDetail);
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
