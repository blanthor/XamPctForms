using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamPctForms
{
    public partial class App : Application
    {
        public static string FilePath { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string fullPath) : this()
        {
            FilePath = fullPath;
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
