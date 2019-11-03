using SimpleCRM.Data.Models;
using SimpleCRM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Interfaces
{
    public interface IDailyTaskMessageService
    {
        Task<DailyTaskMessageListViewModel> GetListAsync();
    }
}
