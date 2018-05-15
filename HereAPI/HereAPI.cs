using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;

namespace HereAPI
{
    public class HereAPI : IDisposable
    {
        [Description("app_id")]
        public string AppId { get; set; } = "bC4fb9WQfCCZfkxspD4z";
        [Description("app_code")]
        public string AppCode { get; set; } = "K2Cpd_EKDzrZb1tz0zdpeQ";

        public bool RunInProdEnv { get; set; } = true;

        public HttpClient HttpClient { get; }

        public static CultureInfo Culture = CultureInfo.InvariantCulture;

        public static void Register(string app_id, string app_code, bool runInProductionEnvironment)
        {
            instance = new HereAPI();
            instance.AppCode = app_code;
            instance.AppId = app_id;
            instance.RunInProdEnv = runInProductionEnvironment;
        }

        private static HereAPI instance;

        private HereAPI()
        {
            HttpClient = new HttpClient();
        }

        public static HereAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("The HereAPI instance must be initialized using the HereAPI.Register() method.");
                }
                return instance;
            }
        }

        public void Dispose()
        {
            if (HttpClient != null) HttpClient.Dispose();
        }

    }
}
