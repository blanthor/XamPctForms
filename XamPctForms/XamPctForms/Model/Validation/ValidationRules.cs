using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XamPctForms.Model.Validation
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }

    public class AllowedCharactersRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            Regex regex = new Regex(@"^([a-zA-Z0-9]){5,12}$");
            Match match = regex.Match(str);
            return match.Success;
        }
    }

    public class NoRepeatingCharacterRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            Regex rx = new Regex(@"^(?!.*(.)\1).{5,12}$");
            Match match = rx.Match(str);
            return match.Success;
        }
    }

    public class NoRepeatingSequencRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            int length = str.Length;
            bool matchFound = true;
            for (int segmentLength = 2; segmentLength < 7; segmentLength++)
            {
                // each position, find seg, go accross
                for (int startIndex = 0; startIndex < length - segmentLength; startIndex++)
                {
                    string sub = str.Substring(startIndex, segmentLength);
                    // * look in rest of string
                    string remainder = str.Substring(startIndex + segmentLength);
                    int matchIndex = remainder.IndexOf(sub);
                    if (matchIndex > 0) return false;
                }
            }

            return matchFound;
        }

    }

    public class AtLeastOneNumberAndLetterEachRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;

            Regex rx = new Regex(@"^[a-zA-Z]{1,11}[1-8]{1,11}$");
            Match match = rx.Match(str);
            return match.Success;
        }
    }
}
