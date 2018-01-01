using shanuMVCUserRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Web.ModelBinding;

namespace shanuMVCUserRoles
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
    }
}