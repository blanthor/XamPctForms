using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;

namespace XamPctForms
{
    class UserListPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> userList;

        public ObservableCollection<string> UserList
        {
            get => userList;
            set
            {
                if (userList == value) return;
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        internal void ReadFromDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<UserDTO>();
                //ObservableCollection<UserDTO> 
                    var CurrentUsers = conn.Table<UserDTO>().ToList();
            }
        }

        public UserListPageViewModel(string newUser = "")
        {

            UserList = new ObservableCollection<string>();
            PopulateUserList();
        }

        private void PopulateUserList()
        {
            UserList.Add("Moe");
            UserList.Add("Curly");
            UserList.Add("Larry");

            //TODO: Change to showing actual data.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
