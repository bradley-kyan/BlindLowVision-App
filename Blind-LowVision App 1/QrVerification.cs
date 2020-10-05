using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Blind_LowVision_App_1
{
    public class QrVerification
    {
        public static async Task<string> QrCheck(string id)
        {
            var postParams = new Dictionary<string, string>();
            postParams.Add("UserID", id);
            var data = new FormUrlEncodedContent(postParams);

            var client = new HttpClient();
            var uri = "http://192.168.1.10/qrVerify.php";

            var response = await client.PostAsync(uri, data);
            string result = response.Content.ReadAsStringAsync().Result;

            if (result == "404")
            {
                return null;
            }
            else
            {
                dynamic jToken = JToken.Parse(result);
                string FName = jToken.FName;
                string LName = jToken.LName;
                string balance = jToken.Balance;
                string name = $"{FName} {LName}";
                GetName.Balance = Convert.ToDecimal(balance);
                return name;
            }
        }
        public static async Task<string> InfoEdit(string id, decimal value)
        {
            var postParams = new Dictionary<string, string>();
            postParams.Add("UserID", id);
            postParams.Add("Value", Convert.ToString(value));
            var data = new FormUrlEncodedContent(postParams);

            var client = new HttpClient();
            var uri = "http://192.168.1.10/qrUpdate.php";

            var response = await client.PostAsync(uri, data);
            string result = response.Content.ReadAsStringAsync().Result;

            if (result == "404")
            {
                return "404";
            }
            else
            {
                return "200";
            }
        }

    }
}