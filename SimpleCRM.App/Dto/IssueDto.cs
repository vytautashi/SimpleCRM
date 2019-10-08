using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Dto
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IssueClosed { get; set; }
        public DateTime IssueOpenDateTime { get; set; }
        public DateTime IssueCloseDateTime { get; set; }
        public int CustomerId { get; set; }
    }
}
