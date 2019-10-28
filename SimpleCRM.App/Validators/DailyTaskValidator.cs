using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Validators
{
    public static class DailyTaskValidator
    {
        public static bool isValid(DailyTask dailyTask)
        {
            return CommonValidator.ValidateName(dailyTask.Title, true);
        }
    }
}
