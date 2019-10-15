using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Helpers
{
    public static class LoggerCommon
    {
        public static string createLogLine(string changedBy, string actionPerformed, string newValueSet)
        {
            return DateTime.Now + " | [ " + actionPerformed + " ] [ "+ newValueSet + " ] | performed by [ " + changedBy + " ]" + Environment.NewLine;
        }
    }
}
