using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using SQLite;
using XamPctForms.Model;
using XamPctForms.Model.Validation;

namespace XamPctForms
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddUserViewModel()
        {

            UserListCommand = new Command(async () =>
            {
                var page = new UserListPage();
                await Application.Current.MainPage.Navigation.PushAsync(page);
            });

            SaveUserCommand = new Command(async () =>
            {
                UserDTO user = new UserDTO()
                {
                    UserName = this.UserName.Value,
                    Password = this.Password.Value
                };
                if (Validate())
                {
                    SaveUserToDatabase(user);
                    UserName.Value = "";
                    Password.Value = "";
                    var page = new UserListPage();
                    await Application.Current.MainPage.Navigation.PushAsync(page);
                }
                else
                {
                    PasswordErrors = Password.ErrorMessages();
                }
            });

            userName = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            AddValidations();
        }

        private void SaveUserToDatabase(UserDTO user)
        {
            App.Database.SaveItemAsync(user);
        }

        #region Properties
        private ValidatableObject<string> userName;

        private ValidatableObject<string> password;

        public ValidatableObject<string> UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public ValidatableObject<string> Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string passwordErrors;

        public string PasswordErrors
        {
            get { return passwordErrors; }
            set
            {
                passwordErrors = value;
                OnPropertyChanged(nameof(PasswordErrors));
            }
        }

        #endregion //Properties

        #region Validation Methods
        //TODO: Regions might be sign that refactoring is needed.
        private void AddValidations()
        {
            userName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A username is required."
            });
            password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A password is required."
            });
            password.Validations.Add(new AllowedCharactersRule<string>
            {
                ValidationMessage = "Only Alphanumeric characters are allowed."
            });
            password.Validations.Add(new AtLeastOneNumberAndLetterEachRule<string>
            {
                ValidationMessage = "Password should have at least one number and one letter."
            });
            password.Validations.Add(new NoRepeatingCharacterRule<string>
            {
                ValidationMessage = "Password must not have repeating characters."
            });
            password.Validations.Add(new NoRepeatingSequencRule<string>
            {
                ValidationMessage = "Password must not have repeating patterns."
            });
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            return isValidUser && isValidPassword;
        }
        public bool ValidateUserName()
        {
            return userName.Validate();
        }
        public bool ValidatePassword()
        {
            return password.Validate();
        }
        #endregion //Validation Methods

        private ICommand userListCommand;

        public ICommand UserListCommand
        {
            get { return userListCommand; }
            set { userListCommand = value; }
        }

        private ICommand saveUserCommand;

        public ICommand SaveUserCommand
        {
            get { return saveUserCommand; }
            set { saveUserCommand = value; }
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
