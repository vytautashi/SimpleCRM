using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Converters
{
    public class DailyTaskMessageConverter : GenericConverter<DailyTaskMessage, DailyTaskMessageDto>
    {
        public override DailyTaskMessageDto ToDto(DailyTaskMessage dailyTaskMessage)
        {
            DailyTaskMessageDto dailyTaskMessageDto = new DailyTaskMessageDto
            {
                Id = dailyTaskMessage.Id,
                Enabled = dailyTaskMessage.Enabled,
                MessageText = dailyTaskMessage.MessageText,
                PosterFullName = dailyTaskMessage.PosterFullName,
                DateTime = dailyTaskMessage.DateTime,
                DailyTaskId = dailyTaskMessage.DailyTaskId,
                EmployeeId = dailyTaskMessage.EmployeeId,
            };
            return dailyTaskMessageDto;
        }

        public DailyTaskMessageListViewModel ToDailyTaskMessageListView(IEnumerable<DailyTaskMessage> dailyTaskMessage)
        {
            return new DailyTaskMessageListViewModel(ToDtoList(dailyTaskMessage));
        }
    }
}
