﻿using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private IDailyTaskRepository _dailyTaskRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
        }


        public async Task<DailyTaskListViewModel> GetListByEmployeeIdAsync(int id)
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetListByEmployeeIdAsync(id);

            return DailyTaskConverter.ToDailyTaskListViewModel(dailyTasks);
        }

        public async Task<DailyTaskListViewModel> GetDailyTaskListAsync()
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetDailyTaskListAsync();

            return DailyTaskConverter.ToDailyTaskListViewModel(dailyTasks);
        }

        public async Task<DailyTaskViewModel> GetDailyTaskAsync(int id)
        {
            if (!await _dailyTaskRepository.ExistsAsync(id))
            {
                return new DailyTaskViewModel();
            }

            DailyTask dailyTask = await _dailyTaskRepository.GetDailyTaskAsync(id);

            return DailyTaskConverter.ToDailyTaskViewModel(dailyTask);
        }

        public async Task AddDailyTaskAsync(DailyTaskViewModel dailyTask)
        {
            DailyTask e = DailyTaskConverter.ToDailyTask(dailyTask.DailyTask);
            await _dailyTaskRepository.AddAsync(e);
        }

        public async Task DeleteDailyTaskAsync(int id)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                await _dailyTaskRepository.DeleteAsync(id);
            }
        }

        public async Task UpdateDailyTaskAsync(int id, DailyTaskViewModel dailyTask)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTask task = DailyTaskConverter.ToDailyTask(dailyTask.DailyTask);
                task.Id = id;
                await _dailyTaskRepository.UpdateAsync(task);
            }
        }

    }
}
