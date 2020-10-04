using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Karumi.Dexter;
using Com.Karumi.Dexter.Listener;
using Com.Karumi.Dexter.Listener.Single;
using EDMTDev.ZXingXamarinAndroid;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "ScanActivity")]
    public class ScanActivity : Activity,IPermissionListener
    {   //https://www.youtube.com/watch?v=S78S3z6BT88&ab_channel=EDMTDev
        
        private ZXingScannerView scannerView;
        private ToastLength tlength; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Camera);
            scannerView = FindViewById<ZXingScannerView>(Resource.Id.zxscan);

            Dexter.WithActivity(this)
                .WithPermission(Manifest.Permission.Camera)
                .WithListener(this)
                .Check();
        }

        protected override void OnDestroy()
        {
            scannerView.StopCamera();
            base.OnDestroy();
        }
        public void OnPermissionDenied(PermissionDeniedResponse p0)
        {
            string msg = "You must enable permissions";
            OnToastCreate(msg, "long");
            
        }

        public void OnPermissionGranted(PermissionGrantedResponse p0)
        {                
            scannerView.StartCamera();

            scannerView.SetResultHandler(new MyResultHandler(this));
            FindViewById<Button>(Resource.Id.qrButton).Click += (e, o) =>
            {
                restartActivity();
            };
        }

        public void OnPermissionRationaleShouldBeShown(PermissionRequest p0, IPermissionToken p1)
        {

        }
        //Toast creation
        public void OnToastCreate(string errorMsg, string length)
        {
            switch(length)
            {
                case "long":
                    tlength = ToastLength.Long;
                    break;

                case "short":
                    tlength = ToastLength.Short;
                    break;

                default:
                    tlength = ToastLength.Long;
                    break;
            }
            if(errorMsg == null)
            {
                Toast.MakeText(this, "Invalid QR Code", tlength).Show();
            }
            else 
            { 
                Toast.MakeText(this, $"{errorMsg}", tlength).Show(); 
            }
            
        } 
        public void ViewController(string location)
        {
            switch (location)
            {
                case "DonationEdit":
                    SetContentView(Resource.Layout.DonationEdit);
                    break;
                case "loginForm":
                    SetContentView(Resource.Layout.loginForm);
                    break;
                case "Camera":
                    SetContentView(Resource.Layout.Camera);
                    break;
                case "SignIn":
                    SetContentView(Resource.Layout.SignIn);
                    break;
            }
        }
        public void restartActivity()
        {
            Finish();
            StartActivity(typeof(ScanActivity));
        }

        public class MyResultHandler : IResultHandler
        {
            private ScanActivity scanActivity;

            public MyResultHandler(ScanActivity scanActivity)
            {
                this.scanActivity = scanActivity;
            }

            public void HandleResult(ZXing.Result rawResult)
            {
                ProcessResult(rawResult.Text);
            }

            private async void ProcessResult(string text) 
            {
                string status = await QrVerification.QrCheck(text);
                if(status == "200")
                {
                    string value = "DonationEdit";
                    scanActivity.ViewController(value);
                }
                else
                {
                    string value = "DonationEdit";
                    scanActivity.ViewController(value);
                }
            }
        }
    }

}