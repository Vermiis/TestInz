using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace zarzadzanieTematami.Models
{
    public class Topics
    {
        public int ID { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Details { get; set; }
        public string PromotorID { get; set; }
        [Display(Name = "Promotor")]
        public string PromotorName { get; set; }
        [Display(Name = "Zarezerwowany")]
        public bool IsTaken { get; set; }
        [Display(Name = "Zaakceptowany")]
        public bool IsAccepted { get; set; }
        [Display(Name = "Odrzucony")]
        public bool IsRejected { get; set; }
        [Display(Name = "Proponowany")]
        public bool IsProposed { get; set; }
        public string TakenByID { get; set; }
        [Display(Name = "Zarezerwowany przez:")]
        public string TakenBy { get; set; }
        [Display(Name = "Zakres")]
        public string TypeOf { get; set; }
        [Display(Name = "Uwagi")]
        public string Commentary { get; set; }
    }
    public class AttendanceDBContext : DbContext
    {
        public DbSet<Topics> Topics { get; set; }
    }
}