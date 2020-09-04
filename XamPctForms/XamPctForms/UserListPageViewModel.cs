using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace XamPctForms
{
    class UserListPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> UserList = new ObservableCollection<string>();

        public UserListPageViewModel()
        {
            UserList.Add("Moe");
            UserList.Add("Curly");
            UserList.Add("Larry");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
