using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Processors
{
    public static class CommonProcessor
    {
        private static string NullFix(string str)
        {
            return str == null ? "" : str;
        }
        public static string ProcessString(string str)
        {
            return NullFix(str).Trim();
        }
        public static string ProcessNumber(string str)
        {
            return NullFix(str)
                .Replace(" ", "")
                .Replace("-", "");
        }
        public static string ProcessPhoneNumber(string str)
        {
            return NullFix(str)
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");
        }
    }
}
