using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "ScanActivity")]
    public class ScanActivity : Activity
    {   //https://www.youtube.com/watch?v=S78S3z6BT88&ab_channel=EDMTDev
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Camera);
        }
    }
}