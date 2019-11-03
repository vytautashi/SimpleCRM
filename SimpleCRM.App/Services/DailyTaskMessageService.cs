using SimpleCRM.App.Converters;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class DailyTaskMessageService : IDailyTaskMessageService
    {
        private IDailyTaskMessageRepository _dailyTaskMessageRepository;
        private DailyTaskMessageConverter _dailyTaskMessageConverter;

        public DailyTaskMessageService(IDailyTaskMessageRepository dailyTaskMessageRepository)
        {
            _dailyTaskMessageRepository = dailyTaskMessageRepository;
            _dailyTaskMessageConverter = new DailyTaskMessageConverter();
        }

        public async Task<DailyTaskMessageListViewModel> GetListAsync()
        {
            IEnumerable<DailyTaskMessage> dailyTaskMessages = await _dailyTaskMessageRepository.GetListAsync();

            return _dailyTaskMessageConverter.ToDailyTaskMessageListView(dailyTaskMessages);
        }
    }
}