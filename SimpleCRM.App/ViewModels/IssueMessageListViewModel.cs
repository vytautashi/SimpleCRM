using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class IssueMessageListViewModel
    {
        public IEnumerable<IssueMessageDto> IssueMessages { get; set; }
        public IssueMessageListViewModel()
        {
        }

        public IssueMessageListViewModel(IEnumerable<IssueMessageDto> issueMessagesDto)
        {
            this.IssueMessages = issueMessagesDto;
        }
    }
}
