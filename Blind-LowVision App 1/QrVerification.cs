using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Blind_LowVision_App_1
{
    public static class QrVerification
    {
        
        public static async Task<string> QrCheck(string id)
        {
            var postParams = new Dictionary<string, string>();
            postParams.Add("ID", id);
            var data = new FormUrlEncodedContent(postParams);

            var client = new HttpClient();
            var uri = "http://192.168.1.10/qrVerify.php";


            var response = await client.PostAsync(uri, data);
            string result = response.Content.ReadAsStringAsync().Result;

            if(result == "200")
            {
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}