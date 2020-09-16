using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamPctForms.DAL;

namespace XamPctForms
{
    public partial class App : Application
    {
        public static string FilePath { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AddUserPage());
        }

        public App(string fullPath) : this()
        {
            FilePath = fullPath;
        }

        static UserDatabase database;
        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
