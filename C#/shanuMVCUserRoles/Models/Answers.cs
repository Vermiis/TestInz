using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class Answers
    {
        public enum Status { AcceptedProposal, Rejected, InRealization, RejectedRealization };
        public int TopicID { get; set; }
        public int StudentID { get; set; }
        public Status TopicStatus {get;set;}
        public string Description { get; set; }
    }
}