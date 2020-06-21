using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Android.Content;
using Android.Content.PM;
using IdentityModel.OidcClient.Browser;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Auth0.Xamarin.Droid.Model;
using Android.Support.V7.App;



//https://www.youtube.com/watch?v=5CgQUbnf1Qk&ab_channel=ResoCoder
namespace Blind_LowVision_App_1
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTask)]
    
    public class LoginActivity : Activity
    { 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignIn);
        }


    }
}