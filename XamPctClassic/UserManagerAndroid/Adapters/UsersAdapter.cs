using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using App2.ViewHolders;
using SQLite;
using UserManagerAndroid.Core.DAL;
using UserManagerAndroid.Core.Model;

namespace App2.Adapters
{
    public class UsersAdapter : RecyclerView.Adapter
    {
        List<UserDTO> _users;

        public UsersAdapter()
        {
            GetUsers();
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

        private void GetUsers()
        {
            ReadUsers();
            //_ = ReadFromDatabase();
        }

        internal async Task ReadFromDatabase()
        {
            _users = await Database.GetItemsAsync();
        }

        internal void ReadUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBConstants.DatabasePath))
            {
                conn.CreateTable<UserDTO>();
                _users = conn.Table<UserDTO>().ToList();
            }
        }
        public override int ItemCount => _users.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if(holder is UserViewHolder userViewHolder)
            {
                userViewHolder.UserNameTextView.Text = _users[position].UserName;
                userViewHolder.PasswordTextView.Text = _users[position].Password;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.user_viewholder, parent, false);
            UserViewHolder userViewHolder = new UserViewHolder(itemView);
            return userViewHolder;
        }
    }
}