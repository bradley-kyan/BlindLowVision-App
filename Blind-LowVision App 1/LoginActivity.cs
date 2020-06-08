using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Android.Content;
using Android.Content.PM;
using IdentityModel.OidcClient.Browser;
using Auth0.OidcClient;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Auth0.Xamarin.Droid.Model;
using Android.Support.V7.App;
using StartUpDecisions;



//https://www.youtube.com/watch?v=5CgQUbnf1Qk&ab_channel=ResoCoder
namespace Blind_LowVision_App_1
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.aci.blindlowvision",
    DataHost = "dev-ta0k74kn.auth0.com",
    DataPathPrefix = "/android/com.aci.blindlowvision/callback")]

    public class LoginActivity : Auth0ClientActivity
    { 
        private Auth0Client _auth0Client;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Auth0 client details for callbacks

            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "dev-ta0k74kn.auth0.com",
                ClientId = "C40Vt95xT8vI1Ugjc5xTw5oOOjpNmwCP"
            });
            
            //Button events to call Auth0

            SetContentView(Resource.Layout.SignIn);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            var loginButton = FindViewById<Button>(Resource.Id.loginButtonInitial);
            loginButton.Click += LoginButton_Click;

            FindViewById<Button>(Resource.Id.signinButtonInitial).Click += (e, o) =>
            {
                _auth0Client.LogoutAsync();
            };


        }
        private async void LoginButton_Click(object sender, System.EventArgs e)
        {
            await LoginAsync();
        }
        private async Task LoginAsync()
        {
            var loginResult = await _auth0Client.LoginAsync();

            if (!loginResult.IsError)
            {
                var name = loginResult.User.FindFirst(c => c.Type == "name")?.Value;
                var email = loginResult.User.FindFirst(c => c.Type == "email")?.Value;
                var image = loginResult.User.FindFirst(c => c.Type == "picture")?.Value;

                var userProfile = new UserProfile
                {
                    Email = email,
                    Name = name,
                    ProfilePictureUrl = image
                };
                var intent = new Intent(this, typeof(UserProfileActivity));
                var serializedLoginResponse = JsonConvert.SerializeObject(userProfile);
                intent.PutExtra("LoginResult", serializedLoginResponse);
                StartActivity(intent);
                
            }
            else
            {
                string toastMsg = "Sign In Failed...";
                ToastNotification.TostMessageShort(toastMsg);
            }
        }

    }
}