using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class DailyTaskMessageListViewModel
    {
        public IEnumerable<DailyTaskMessageDto> DailyTaskMessages { get; set; }

        public DailyTaskMessageListViewModel()
        {
        }

        public DailyTaskMessageListViewModel(IEnumerable<DailyTaskMessageDto> DailyTaskMessagesDto)
        {
            this.DailyTaskMessages = DailyTaskMessagesDto;
        }
    }
}
