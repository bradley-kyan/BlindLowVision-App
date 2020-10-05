using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "DonationEditActivity")]
    public class DonationEditActivity : Activity
    {
        RadioButton button1, button2, button3, button4, button5, button6;
        private static decimal itemValue;
        private static bool button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DonationEdit);
            FindViewById<TextView>(Resource.Id.UserInformation).Text = GetName.FullName;
            FindViewById<TextView>(Resource.Id.currentBalance).Text = Convert.ToString(GetName.Balance);
            FindViewById<TextView>(Resource.Id.otherValue).Text = "0";
            FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
            button1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            button2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            button3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            button4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
            button5 = FindViewById<RadioButton>(Resource.Id.radioButton5);
            button6 = FindViewById<RadioButton>(Resource.Id.radioButton6);
            

            button1.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
                itemValue = 1;
                updateValue(itemValue);
                button = false;
            };
            button2.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
                itemValue = 5;
                updateValue(itemValue);
                button = false;
            };
            button3.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
                itemValue = 5;
                updateValue(itemValue);
                button = false;
            };
            button4.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
                itemValue = 5;
                updateValue(itemValue);
                button = false;
            };
            button5.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = false;
                itemValue = 15;
                updateValue(itemValue);
                button = false;
            };
            button6.Click += delegate
            {
                FindViewById<TextView>(Resource.Id.otherValue).Enabled = true;
                if (FindViewById<TextView>(Resource.Id.otherValue).Text == null)
                {
                    FindViewById<TextView>(Resource.Id.otherValue).Text = "0";
                }
                button = true;
            };

            FindViewById<TextView>(Resource.Id.otherValue).KeyPress += onEditTextKeyPress;
            FindViewById<Button>(Resource.Id.confirmButton).Click += sendData;
            FindViewById<Button>(Resource.Id.cancelButton).Click += (e, o) =>
            {
                Finish();
                StartActivity(typeof(ScanActivity));
            };
        }
        protected void onEditTextKeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter && button == true)
            {
                e.Handled = true;
                DismissKeyboard();
                var editText = (EditText)sender;
                itemValue = Convert.ToDecimal(editText.Text);
                updateValue(itemValue);
            }
            else
                e.Handled = false;
        }
        private void DismissKeyboard()
        {
            var view = CurrentFocus;
            if (view != null)
            {
                var imm = (InputMethodManager)GetSystemService(InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }
        private void updateValue (decimal value)
        {

            FindViewById<TextView>(Resource.Id.newBalance).Text = Convert.ToString(GetName.Balance - value);
        }

        private async void sendData(object sender, EventArgs e)
        {
            string data = await QrVerification.InfoEdit(GetName.UserID, itemValue);
            if(data == "404")
            {
                Finish();
                StartActivity(typeof(ScanActivity));
                Toast.MakeText(this, "An Error Occured", ToastLength.Long).Show();
            }
            else
            {
                Finish();
                StartActivity(typeof(ScanActivity));
                Toast.MakeText(this, "Transaction Successful", ToastLength.Long).Show();
            }  
        }

    }
}