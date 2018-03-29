using Microsoft.AspNet.Identity;
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
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {          
            return View(db.Topics.ToList().Where(x => x.IsTaken == false && x.IsProposed == false));
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

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentProposition([Bind(Include = "ID,Title,Details,PromotorID,PromotorName,IsTaken,IsAccepted,IsRejected,IsProposed, TakenByID, TypeOf")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topics);
                topics.TakenBy = User.Identity.Name.ToString();
                topics.TakenByID = User.Identity.GetUserId().ToString();
                topics.IsProposed = true;
                topics.PromotorName = LINQueries.GetNameByID(topics.PromotorID);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(topics);
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
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
    }
}