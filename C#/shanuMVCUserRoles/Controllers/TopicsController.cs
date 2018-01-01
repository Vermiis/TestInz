using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace shanuMVCUserRoles.Controllers
{
    public class TopicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Topics
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        // GET: Topics
        public ActionResult ProposedTopics()
        {
            return View(db.Topics.Where(x => x.IsProposed == true).ToList());
        }

        public ActionResult MyTopics()
        {
            return View(db.Topics.Where(x => x.TakenByID == User.Identity.Name || x.PromotorName == User.Identity.Name && x.IsAccepted == true || x.IsTaken == true).ToList());
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

        // GET: Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Details,PromotorID,PromotorName,IsTaken,IsAccepted,IsRejected,IsProposed, TakenByID, TypeOf")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topics);
        }

        // GET: Topics/Create
        public ActionResult StudentProposition()
        {
            return View();
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
                topics.TakenByID = User.Identity.Name.ToString();
                topics.IsProposed = true;
                db.SaveChanges();

                //var promotors = Roles.GetUsersInRole("Admin");
                // var x = db.Roles.Where(role => role.Id == "87d86bf1-6826-463a-9d22-afe4673d3b07").ToList();
              //  var s = db.Users.SelectMany(c => c.Id);
              //  var t = db.Roles.SelectMany(r => r.Id);
                var usersInRole = db.Users.Where(u => u.Roles.Join(db.Roles, usrRole => usrRole.RoleId, role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("Promotor"))).ToList();
                var promotornames=usersInRole.Select(p=>p.UserName);
              


                return RedirectToAction("Index");
            }

            return View(topics);
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
        public ActionResult Reservation(Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;

                var entry = db.Entry(topics);
                entry.Property(e => e.Title).IsModified = false;
                entry.Property(e => e.Details).IsModified = false;
                entry.Property(e => e.PromotorID).IsModified = false;
                entry.Property(e => e.PromotorName).IsModified = false;
                entry.Property(e => e.IsAccepted).IsModified = false;
                entry.Property(e => e.IsProposed).IsModified = false;
                entry.Property(e => e.IsRejected).IsModified = false;
                entry.Property(e => e.TypeOf).IsModified = false;

                topics.TakenByID = User.Identity.Name.ToString();
                topics.IsTaken = true;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Details,PromotorID,PromotorName,IsTaken,IsAccepted,IsRejected,IsProposed,TakenByID, TypeOf")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topics topics = db.Topics.Find(id);
            db.Topics.Remove(topics);
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
