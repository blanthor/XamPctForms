using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;

namespace XamPctForms
{
    class UserListPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UserDTO> userList;

        public ObservableCollection<UserDTO> UserList
        {
            get => userList;
            set
            {
                if (userList == value) return;
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        //TODO: Implement a DB Class https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases

        internal void ReadFromDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserDTO>();
                UserList = new ObservableCollection<UserDTO>(conn.Table<UserDTO>().ToList());

            }
        }

        public UserListPageViewModel(string newUser = "")
        {
            DisplayUserList();
        }

        private void DisplayUserList()
        {
            ReadFromDatabase();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
