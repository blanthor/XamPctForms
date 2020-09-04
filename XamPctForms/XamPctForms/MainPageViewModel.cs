using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace XamPctForms
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
