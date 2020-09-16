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
            //using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            //{
            //    conn.CreateTable<UserDTO>(); // Conditionally creates table
            //    int rowsAdded = conn.Insert(user);
            //} 
            App.Database.SaveItemAsync(user);
        }

        #region Properties
        private ValidatableObject<string> userName;
        //public string UserName
        //{
        //    get { return userName; }
        //    set 
        //    {
        //        if (userName == value) return;
        //        userName = value;
        //        OnPropertyChanged(nameof(UserName));
        //    }
        //}

        private ValidatableObject<string> password;
        //public string Password
        //{
        //    get { return password; }
        //    set 
        //    {
        //        if (password == value) return;
        //        password = value;
        //        OnPropertyChanged(nameof(Password));
        //    }
        //}

        public ValidatableObject<string> UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                //RaisePropertyChanged(() => UserName);
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
                //RaisePropertyChanged(() => Password);
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
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            return isValidUser && isValidPassword;
        }
        private bool ValidateUserName()
        {
            return userName.Validate();
        }
        private bool ValidatePassword()
        {
            return password.Validate();
        }

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

        public bool IsValidPassword(string pass)
        {
            string trimmedPass = pass.Trim();
            if (trimmedPass.Length < 5 || trimmedPass.Length > 12) return false;

            Regex rx = new Regex(@"^([a-zA-Z0-9]){5,12}$");
            //TODO: check for repeating sequence
            //TODO: move to IValidator
            //TODO: change where test is pointing

            MatchCollection matches = rx.Matches(trimmedPass);
            return (matches.Count > 0);
        }
    }
}
