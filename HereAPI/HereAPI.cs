using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI
{
    class HereAPI
    {

        public string AppId { get; set; } = "bC4fb9WQfCCZfkxspD4z";
        public string AppCode { get; set; } = "K2Cpd_EKDzrZb1tz0zdpeQ";

        public bool RunInProdEnv { get; set; } = true;

        public static void Register(string app_id, string app_code, bool runInProductionEnvironment)
        {
            instance = new HereAPI();
            instance.AppCode = app_code;
            instance.AppId = app_id;
            instance.RunInProdEnv = runInProductionEnvironment;
        }

        private static HereAPI instance;

        private HereAPI() { }

        public static HereAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HereAPI();
                    //TODO throw new Exception("The HereAPI instance must be initialized using the HereAPI.Register() method.");
                }
                return instance;
            }
        }

    }
}
