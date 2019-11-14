﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ceoname { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }

        //public ICollection<Task> Tasks { get; set; }

    }
}
