using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace zarzadzanieTematami.Models
{
    public class Topics
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string PromotorID { get; set; }
        public string PromotorName { get; set; }
        public bool IsTaken { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public bool IsProposed { get; set; }
        public string TakenByID { get; set; }
        public string TakenBy { get; set; }
        public string TypeOf { get; set; }
    }
    public class AttendanceDBContext : DbContext
    {
        public DbSet<Topics> Topics { get; set; }
    }
}