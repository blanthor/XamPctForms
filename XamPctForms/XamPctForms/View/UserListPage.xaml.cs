using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace XamPctForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public void OnGesture(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

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