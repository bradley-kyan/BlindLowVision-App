using System.Collections.Generic;
using System.Net.Http;

using Android.App;
using Android.OS;
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


            var loginBtn = FindViewById<Button>(Resource.Id.loginPostButton);

            loginBtn.Click += (e, o) =>
            {
                var username = FindViewById<EditText>(Resource.Id.textUname).Text;
                var password = FindViewById<EditText>(Resource.Id.textPass).Text;
                sendLoginPhp(username, password);
            };
        }
        private async void sendLoginPhp(string username, string password)
        {
            var postParams = new Dictionary<string, string>();
            postParams.Add("Username", username);
            postParams.Add("Password", password);
            var data = new FormUrlEncodedContent(postParams);

            var client = new HttpClient();
            var uri = "http://192.168.1.10/appLogin.php";

       
            var response = await client.PostAsync(uri, data);
            string result = response.Content.ReadAsStringAsync().Result;

            if(result == "200")
            {
                Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                client.Dispose();
                StartActivity(typeof(ScanActivity));
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Login Unsuccessful", ToastLength.Long).Show();
                client.Dispose();
            }
        }

    }
}