﻿using System;

namespace SimpleCRM.Data.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastContacted { get; set; }
    }
}
