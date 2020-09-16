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

            IDatabasePathService service = DependencyService.Get<IDatabasePathService>();

            FilePath = service.GetPath(DBConstants.DatabaseFilename);
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
