using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagerAndroid.Core.Model.Validation
{
    public class ValidationsRulesCollection<T>
    {
        private List<IValidationRule<T>> _validations;
        public ValidationsRulesCollection()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
            AddAllRules();

        }

        private void AddAllRules()
        {
            Add(new IsNotNullOrEmptyRule<T>() { ValidationMessage= "A password is required." });
            Add(new AllowedCharactersRule<T>() { ValidationMessage = "Only Alphanumeric characters are allowed." });
            Add(new NoRepeatingCharacterRule<T>() { ValidationMessage = "Password must not have repeating characters." });
            Add(new NoRepeatingSequencRule<T>() { ValidationMessage = "Password must not have repeating patterns." });
            Add(new AtLeastOneNumberAndLetterEachRule<T>() { ValidationMessage = "Password should have at least one number and one letter." });
        }

        public List<IValidationRule<T>> Validations => _validations;

        private T _value;

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public void Add(IValidationRule<T> rule)
        {
            _validations.Add(rule);
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
        private List<string> _errors;

        public List<string>  Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }
        private bool _isValid;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
            }
        }

        public string ErrorMessages()
        {
            return String.Join(" : ", Errors);
        }
    }
}
