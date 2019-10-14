using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Helpers
{
    public static class LoggerCommon
    {
        public static string createLogLine(string changedBy, string actionPerformed)
        {
            return DateTime.Now + " | [" + actionPerformed + "] | performed by [" + changedBy + "]" + Environment.NewLine;
        }
    }
}
