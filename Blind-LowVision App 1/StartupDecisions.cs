using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Blind_LowVision_App_1;

namespace StartUpDecisions
{
    [Activity(Label = "@string/app_name", MainLauncher = false, LaunchMode = LaunchMode.SingleTask)]
    public class currentWindow : Activity
    {
        private int _ans;
        public int Ans
        {
            get => Ans;
            set => _ans = value;
        }
        public void loggedIn()
        {

            if (_ans == 1)
            {
                StartActivity(typeof(MyAdapter));

            }
            else
            {
                StartActivity(typeof(LoginActivity));
            }

        }

    }

}
