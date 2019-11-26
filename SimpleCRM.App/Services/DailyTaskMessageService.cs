using SimpleCRM.App.Converters;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System.Collections.Generic;
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

        public async Task<IEnumerable<DailyTaskMessageDto>> GetListAsync()
        {
            IEnumerable<DailyTaskMessage> dailyTaskMessages = await _dailyTaskMessageRepository.GetListAsync();

            return _dailyTaskMessageConverter.ToDtoList(dailyTaskMessages);
        }
    }
}