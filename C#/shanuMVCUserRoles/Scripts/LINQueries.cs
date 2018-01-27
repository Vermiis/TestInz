using zarzadzanieTematami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;

namespace zarzadzanieTematami
{

    public class LINQueries
    {
      
        public static IEnumerable<SelectListItem> GetPromotors()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<ApplicationUser> usersInRole = db.Users.Where(u => u.Roles.Join(db.Roles, usrRole => usrRole.RoleId, role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("Promotor"))).ToList();
                IEnumerable<string> v = usersInRole.Select(p => p.UserName);
                var promotornames = usersInRole.Select(s => new SelectListItem { Value = s.Id, Text = s.UserName });
                
                return promotornames;
            }           
        }
        public static IEnumerable<ApplicationUser> GetAllUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var AllUsers = context.Users.ToList();
            var UsrNamesAndID = AllUsers.Select(u => new SelectListItem { Value = u.Id, Text = u.UserName });
            var x = UserManager.Users;
            return UserManager.Users;
        }
        public static void GetStudentsWithTopic()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var AllUsers = context.Users.ToList();
            //do dokończenia

        }

    }
}