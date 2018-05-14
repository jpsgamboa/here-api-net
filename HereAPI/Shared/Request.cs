using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared
{
    class Request
    {

        private string url { get; set; }

        public Request(string service, string path, string resource)
        {
            url = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?" +
                $"app_id={HereAPI.Instance.AppId}&app_code={HereAPI.Instance.AppCode}";
        }

        public void AddParameter(string parameter, string value)
        {
            url += $"&{parameter}={value}";
        }


    }
}
