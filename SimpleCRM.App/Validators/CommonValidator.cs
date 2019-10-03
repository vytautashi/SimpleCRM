using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.Validators
{
    public static class CommonValidator
    {
        public static bool ValidateName(string str, bool required)
        {
            if (!required && IsEmpty(str))
                return true;
            
            return IsNonNull(str)
                && IsLengthValid(str, 3, 100);
        }
        public static bool ValidatePhone(string str, bool required)
        {
            if (!required && IsEmpty(str))
                return true;

            return IsNonNull(str)
                && IsLengthValid(str, 3, 20)
                && IsNumber(str);
        }
        public static bool ValidateEmail(string str, bool required)
        {
            if (!required && IsEmpty(str))
                return true;

            return IsNonNull(str)
                && IsLengthValid(str, 3, 100)
                && str.IndexOf('@') != -1;
        }

        private static bool IsNonNull(string str)
        {
            return str != null;
        }
        private static bool IsEmpty(string str)
        {
            return str == null || str.Length == 0;
        }
        private static bool IsNumber(string str)
        {
            return int.TryParse(str, out int n);
        }
        private static bool IsLengthValid(string str, int minLength, int maxLength)
        {
            return (str.Length >= minLength) && (str.Length <= maxLength);
        }
        private static bool isIdType(int number)
        {
            return number > 0;
        }
    }
}
