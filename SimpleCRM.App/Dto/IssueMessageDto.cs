using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Dto
{
    public class IssueMessageDto
    {
        public int Id { get; set; }
        public bool IsCustomer { get; set; }
        public string PosterId { get; set; }
        public string PosterFullName { get; set; }
        public string MessageText { get; set; }
        public int IssueId { get; set; }
    }
}
