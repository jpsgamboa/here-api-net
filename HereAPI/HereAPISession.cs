using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;

namespace HereAPI
{
    /// <summary>
    /// Singleton class to register and save the api <see cref="AppCode"/> and <see cref="AppId"/>
    /// and keep then available for services to use during the session.
    /// <para/>
    /// <para/>
    /// Here provides trial keys which can only be used the Custumer Integration environment.
    /// Therefore, an option is provided to chose on which environment to run: <see cref="RunInProdEnv"/>
    /// <para/>
    /// Usage:
    /// <para/>
    /// HereAPI.Register(app_id, app_code)
    /// </summary>
    public class HereAPISession : IDisposable
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
            instance = new HereAPISession();
            instance.AppCode = app_code;
            instance.AppId = app_id;
            instance.RunInProdEnv = runInProductionEnvironment;
        }

        private static HereAPISession instance;

        private HereAPISession()
        {
            HttpClient = new HttpClient();
        }

        public static HereAPISession Instance
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