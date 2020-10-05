using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content.PM;



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


            FindViewById<Button>(Resource.Id.loginButtonInitial).Click += (e, o) =>
            StartActivity(typeof(LoginFormActivity));

        }


    }
}