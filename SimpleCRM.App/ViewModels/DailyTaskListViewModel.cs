﻿using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class DailyTaskListViewModel
    {
        public IEnumerable<DailyTaskDto> DailyTasks { get; set; }
        public DailyTaskListViewModel()
        {
        }

        public DailyTaskListViewModel(IEnumerable<DailyTaskDto> dailyTasksDto)
        {
            this.DailyTasks = dailyTasksDto;
        }
    }
}
