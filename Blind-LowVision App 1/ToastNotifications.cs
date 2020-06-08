using Android.App;
using Android.Widget;

namespace Blind_LowVision_App_1
{
    public static class ToastNotification
    {
        public static void TostMessageShort(string message)
        {
            var context = Application.Context;
            var tostMessage = message;
            var durtion = ToastLength.Short;


            Toast.MakeText(context, tostMessage, durtion).Show();
        }
        public static void TostMessageLong(string message)
        {
            var context = Application.Context;
            var tostMessage = message;
            var durtion = ToastLength.Long;


            Toast.MakeText(context, tostMessage, durtion).Show();
        }
    }
}