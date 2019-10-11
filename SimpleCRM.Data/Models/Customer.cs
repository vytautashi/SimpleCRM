using System;
using System.Collections.Generic;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastContacted { get; set; }
        public int ActiveAds { get; set; }
        public int OpenIssue { get; set; }


        //public int CompanyId { get; set; }
        //public Company Company { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}
