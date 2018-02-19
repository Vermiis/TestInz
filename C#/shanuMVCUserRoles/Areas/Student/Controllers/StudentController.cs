using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zarzadzanieTematami.Models;

namespace zarzadzanieTematami.Areas.Student.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Student/Student
        public ActionResult Index()
        {          
            return View(db.Topics.ToList().Where(x => x.IsTaken == false && x.IsProposed == false));
        }

        public ActionResult Create()
        {
            TopicCreateStudentViewModel model = new TopicCreateStudentViewModel();
            model.IsProposed = true;
            model.TakenBy = User.Identity.Name.ToString();
            model.IsTaken = true;

            return View(model);
        }

        //REZERWACJA

        public ActionResult Reservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topics = db.Topics.Find(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation(TopicReservationStudentViewModel topics)
        {
            if (ModelState.IsValid)
            {              
                topics.TakenByID = User.Identity.Name.ToString();
                topics.IsTaken = true;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }
    }
}