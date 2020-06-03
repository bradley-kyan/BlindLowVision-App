using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Java.Security;
using Android.Renderscripts;
//https://www.youtube.com/watch?v=5CgQUbnf1Qk&ab_channel=ResoCoder
namespace Blind_LowVision_App_1
{
    [Activity(Label = "Scavanger Hunt App", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Button signInButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.SignIn);

            //signInButton = FindViewById<Button>(Resource.Id.signinButtonInitial);
            FindViewById<Button>(Resource.Id.signinButtonInitial).Click += (e, o) => {
                StartActivity(typeof(Carousel));
            };

            


        }

    }
}