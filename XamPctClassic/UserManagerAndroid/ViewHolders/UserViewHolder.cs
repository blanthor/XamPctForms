using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App2.ViewHolders
{
    public class UserViewHolder : RecyclerView.ViewHolder

    {
        public TextView UserNameTextView { get; set; }
        public TextView PasswordTextView { get; set; }

        public UserViewHolder(View itemView) : base(itemView)
        {
            UserNameTextView = itemView.FindViewById<TextView>(Resource.Id.userNameTextView);
            PasswordTextView = itemView.FindViewById<TextView>(Resource.Id.passwordTextView);
        }
    }
}