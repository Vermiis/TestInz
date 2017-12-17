using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class UsersDetails
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public bool IsPromotor { get; set; }
        public bool IsStudent { get; set; }
        public bool IsAdmin { get; set; }
    }
}