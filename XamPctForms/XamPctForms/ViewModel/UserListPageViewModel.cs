using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;
using System.Threading.Tasks;

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
                //ObservableCollection<UserDTO> 
                //var CurrentUsers = conn.Table<UserDTO>().ToList();
                UserList = new ObservableCollection<UserDTO>(conn.Table<UserDTO>().ToList());

            }
        }

        public UserListPageViewModel(string newUser = "")
        {

            //UserList = new ObservableCollection<string>();
            DisplayUserList();
        }

        private void DisplayUserList()
        {
            //UserList.Add("Moe");
            //UserList.Add("Curly");
            //UserList.Add("Larry");

            //TODO: Change to showing actual data.
            ReadFromDatabase();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
