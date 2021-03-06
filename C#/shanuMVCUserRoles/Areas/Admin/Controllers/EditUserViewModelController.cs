﻿using zarzadzanieTematami.Areas.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zarzadzanieTematami.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace zarzadzanieTematami.Areas.Admin.Controllers
{
    public class EditUserViewModelController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var Db = new ApplicationDbContext();
            var users = Db.Users;
            var model = new List<EditUserViewModel>();
            foreach (var user in users)
            {
                var u = new EditUserViewModel(user);
                model.Add(u);
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(string id)
        {
            var Db = new ApplicationDbContext();
            var users = Db.Users;
            var user = users.Select(u => u.Id == id);
            if (ModelState.IsValid)
            {
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);


        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            var model = new EditUserViewModel(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            Db.Users.Remove(user);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}