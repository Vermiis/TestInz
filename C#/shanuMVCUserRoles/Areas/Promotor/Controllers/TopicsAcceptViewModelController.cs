using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zarzadzanieTematami.Areas.Promotor.Models.ViewModels;
using zarzadzanieTematami.Models;

namespace shanuMVCUserRoles.Areas.Promotor.Controllers
{
    public class TopicsAcceptViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Promotor/TopicsAcceptViewModel
        public ActionResult Index()
        {
            return View();
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
        public ActionResult AcceptProposition(TopicsAcceptViewModel topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topics);
        }
    }
}