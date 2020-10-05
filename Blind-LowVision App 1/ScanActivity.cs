using Android;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Karumi.Dexter;
using Com.Karumi.Dexter.Listener;
using Com.Karumi.Dexter.Listener.Single;
using EDMTDev.ZXingXamarinAndroid;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "ScanActivity")]
    public class ScanActivity : Activity,IPermissionListener
    {        
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
            OnToastCreate(msg, true);
            
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

        /// <summary>Void <c>OnToastCreate</c> creates a toast notification from inputted variables.
        /// Length == True -> Toast duration is long, Lenth == False -> Toast duration is short.</summary>
        public void OnToastCreate(string errorMsg, bool length)
        {
            switch(length)
            {
                case true:
                    tlength = ToastLength.Long;
                    break;

                case false:
                    tlength = ToastLength.Short;
                    break;
            }
            if(errorMsg == null)
            {
                Toast.MakeText(this, "Undefined Message", tlength).Show();
            }
            else 
            { 
                Toast.MakeText(this, $"{errorMsg}", tlength).Show(); 
            }
            
        } 
        
        public void restartActivity()
        {
            Finish();
            StartActivity(typeof(ScanActivity));
        }
        public void gotoDonationEditActivity()
        {
            StartActivity(typeof(DonationEditActivity));
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
                string data = await QrVerification.QrCheck(text);
                if(data == null)
                {
                    scanActivity.OnToastCreate("QR or UserID is invalid", false);
                }
                else
                {
                    GetName.FullName = data;
                    GetName.UserID = text;
                    scanActivity.gotoDonationEditActivity();
                }
            }
        }
    }

}