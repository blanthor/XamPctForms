using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using SQLite;

namespace XamPctForms
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
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
                    UserName = this.UserName,
                    Password = this.Password
                };

                SaveUserToDatabase(user);
                var page = new UserListPage();
                await Application.Current.MainPage.Navigation.PushAsync(page);
            });
        }

        private void SaveUserToDatabase(UserDTO user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserDTO>();
                int rowsAdded = conn.Insert(user);
            } 
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set 
            {
                if (userName == value) return;
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set 
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
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

            MatchCollection matches = rx.Matches(trimmedPass);
            return (matches.Count > 0);
        }
    }
}
