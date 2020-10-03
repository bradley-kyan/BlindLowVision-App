using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "LoginFormActivity")]
    public class LoginFormActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginForm);


            var username = FindViewById<EditText>(Resource.Id.textUname).Text;
            var password = FindViewById<EditText>(Resource.Id.textPass).Text;

            var loginBtn = FindViewById<Button>(Resource.Id.loginPostButton);

            loginBtn.Click += (e, o) =>
            sendLoginPhp(username,password);
        }
        void sendLoginPhp(string username, string password)
        {

            WebClient client = new WebClient();
            Uri uri = new Uri("http://localhost/xamlogin.php");
            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("Username", username);
            parameters.Add("Password", password);
            Toast.MakeText(this, $"Username {username} Password {password}", ToastLength.Long).Show();

        }

    }
}