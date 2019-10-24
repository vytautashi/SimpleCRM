using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Helpers
{
    public static class LoggerCommon
    {
        public static string createLogLine(string actionPerformedBy, string actionName, string newValueSet)
        {
            return DateTime.Now + " | [ " + actionName + " ] [ "+ newValueSet + " ] | performed by [ " + actionPerformedBy + " ]" + Environment.NewLine;
        }
    }
}
