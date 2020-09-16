using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;
using System.Collections.Generic;
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

        internal async Task ReadFromDatabase()
        {
            List<UserDTO> users = await App.Database.GetItemsAsync();
            UserList = new ObservableCollection<UserDTO>(users);
        }

        public UserListPageViewModel(string newUser = "")
        {
            DisplayUserList();
        }

        private void DisplayUserList()
        {
            _ = ReadFromDatabase();

            //TODO: Scroll to the very end.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
