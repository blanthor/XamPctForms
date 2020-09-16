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


}
