﻿using System;

namespace SimpleCRM.App.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastContacted { get; set; }
        public int ActiveAds { get; set; }
        public int OpenIssue { get; set; }
    }
}
