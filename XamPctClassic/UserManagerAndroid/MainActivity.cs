using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using App2.Adapters;
using Android.Content;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _usersRecyclerView;
        private RecyclerView.LayoutManager _userLayoutManager;
        private UsersAdapter _usersAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _usersRecyclerView =  FindViewById<RecyclerView>(Resource.Id.usersRecyclerView);

            _userLayoutManager = new LinearLayoutManager(this);
            _usersRecyclerView.SetLayoutManager(_userLayoutManager);
            _usersAdapter = new UsersAdapter();
            _usersRecyclerView.SetAdapter(_usersAdapter);

            Button addButton = FindViewById<Button>(Resource.Id.AddButton);
            addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(AddUserActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}