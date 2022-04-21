using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VietQR
{
    public class VQR_Post
    {
        public string accountNo { get; set; }
        public string accountName { get; set; }
        public string acqId { get; set; }
        public string addInfo { get; set; }

        public string amount { get; set; }
        public string format { get; set; }


    }

    public class VQR_Response
    {
        public string code { get; set; }
        public string desc { get; set; }

        public data_respones data { get; set; }

    }

    public class data_respones
    {

        public string qrDataURL { get; set; }
        public string qrCode { get; set; }

    }


    public class VietQRApi
    {
        private string urlapi = "https://api.vietqr.io";
        static HttpClient client;

        public VietQRApi()
        {

            client = new HttpClient();

            client.BaseAddress = new Uri(urlapi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }

        public async Task<VQR_Response> GetVietQR(VQR_Post post)
        {
            var content = new StringContent(
    JsonConvert.SerializeObject(post),
    Encoding.UTF8,
    "application/json");
            var response = await client.PostAsync("v1/generate", content);
            if (response.IsSuccessStatusCode)
            {


                string data = await response.Content.ReadAsStringAsync();
                //use JavaScriptSerializer from System.Web.Script.Serialization
                var myInstance = JsonConvert.DeserializeObject<VQR_Response>(data);
                //deserialize to your class
                return myInstance;
            }
            else
            {
                return null;
            }


        }
    }
}
