using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Frequency.Edu.Models;
using Frequency.Edu.ViewModels;

namespace MyExamPractise.Controllers
{
    public class TraineeCourseVMController : Controller
    {
        FrequencyEduDBEntities db = new FrequencyEduDBEntities();
        // GET: TraineeCourseVM
        public ActionResult Index()
        {
            List<TraineesCourseInformationVM> trnCrsList = new List<TraineesCourseInformationVM>();

            var traineeCourseList = (from crs in db.Courses
                                     join trn in db.Trainees
                              on crs.CourseID equals trn.CourseID
                                     select new { crs.CourseName, crs.Schedule, trn.TraineeName, trn.Mobile,trn.Email }).ToList();

            foreach (var item in traineeCourseList)
            {
                TraineesCourseInformationVM tcvm = new TraineesCourseInformationVM();
                tcvm.CourseName = item.CourseName;
                tcvm.Schedule = item.Schedule;
                tcvm.TraineeName = item.TraineeName;
                tcvm.Email = item.Email;
                tcvm.Mobile = item.Mobile;

                trnCrsList.Add(tcvm);
            }
            return View(trnCrsList);
        }
    }
}