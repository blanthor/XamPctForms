using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamPctForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = new UserListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}