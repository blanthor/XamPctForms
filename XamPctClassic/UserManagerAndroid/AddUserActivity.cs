using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using SQLite;
using UserManagerAndroid.Core.DAL;
using UserManagerAndroid.Core.Model;
using UserManagerAndroid.Core.Model.Validation;

namespace App2
{
    [Activity(Label = "AddUserActivity")]
    public class AddUserActivity : Activity
    {

        Button _submitButton;
        TextView _newUserNameEdit;
        TextView _newPasswordTextView;
        TextView _errorTextView;

        ValidationsRulesCollection<string> _rules;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_user);
            // Create your application here
            _rules = new ValidationsRulesCollection<string>();
            FindViews();
            _submitButton.Click += _submitButton_Click;
        }

        private void _submitButton_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                UserName = _newUserNameEdit.Text,
                Password = _newPasswordTextView.Text
            };
            if (Validate(user.Password))
            {
                // Save
                using (SQLiteConnection conn = new SQLiteConnection(DBConstants.DatabasePath))
                {
                    conn.CreateTable<UserDTO>();
                    int numberInserted = conn.Insert(user, typeof(UserDTO));
                }
                // Pop navigation
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                DisplayErrors();
            }
        }

        private bool Validate(string value)
        {
            _rules.Value = value;
            return _rules.Validate();
        }

        private void DisplayErrors()
        {
            string errors = _rules.ErrorMessages();
            _errorTextView.SetTextColor(Color.Red);
            _errorTextView.Text = errors;
        }

        private void FindViews()
        {
            _submitButton = FindViewById<Button>(Resource.Id.submitButton);
            _newUserNameEdit = FindViewById<EditText>(Resource.Id.newUserName);
            _newPasswordTextView = FindViewById<EditText>(Resource.Id.newUserPassword);
            _errorTextView = FindViewById<TextView>(Resource.Id.errorTextView);
        }
    }
}