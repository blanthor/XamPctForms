using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamPctForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : NavigationPage
    {
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = new UserListPageViewModel();
        }
    }
}