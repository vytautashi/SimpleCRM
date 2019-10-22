using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public static class PosterType
    {
        const string EMPLOYEE = "employee";
        const string CUSTOMER = "customer";
    }

    public class Message : IEntity
    {
        public int Id { get; set; }
        public string MessagePosterType { get; set; }
        public int PosterId { get; set; }
        public string PosterFullName { get; set; }
        public string MessageText { get; set; }

/*
        public int ReplyToMessageId { get; set; }
        public Message ReplyToMessage { get; set; }
*/


    }
}
