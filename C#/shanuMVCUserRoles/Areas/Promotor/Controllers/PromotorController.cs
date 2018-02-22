using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zarzadzanieTematami.Models;
using zarzadzanieTematami.Areas.Promotor.Models.ViewModels;

namespace zarzadzanieTematami.Areas.Promotor.Controllers
{
    public class PromotorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promotor/Promotor
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }
        public ActionResult MyTopicsAll()
        {
            return View(db.Topics.ToList().Where(x=>x.PromotorName==User.Identity.Name));
        }
        public ActionResult MyTopicsFree()
        {
            return View(db.Topics.ToList().Where(x => x.PromotorName == User.Identity.Name && x.IsTaken==false));
        }
        public ActionResult MyTopicsTaken()
        {
            return View(db.Topics.ToList().Where(x => x.PromotorName == User.Identity.Name && x.IsTaken == true));
        }
        public ActionResult MyTopicsProposed()
        {
            return View(db.Topics.ToList().Where(x => x.PromotorName == User.Identity.Name && x.IsProposed == true));
        }

        // GET: Promotor/Promotor/Details/5
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
        public ActionResult PromotorAddTopic()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PromotorAddTopic([Bind(Include = "ID,Title,Details,PromotorID,PromotorName,IsTaken,IsAccepted,IsRejected,IsProposed, TakenByID, TypeOf")] Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topics);
                topics.PromotorID = User.Identity.GetUserId();
                topics.PromotorName = User.Identity.Name.ToString();
                topics.IsAccepted = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topics);
        }


        // GET: Promotor/Promotor/Edit/5
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

        // POST: Promotor/Promotor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        // GET: Promotor/Promotor/Edit/5
        public ActionResult AcceptProposition(int? id)
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

        // POST: Promotor/Promotor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptProposition(Topics topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }

        // GET: Promotor/Promotor/Delete/5
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

        // POST: Promotor/Promotor/Delete/5
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
