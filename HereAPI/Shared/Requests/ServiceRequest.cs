using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Requests
{
    class ServiceRequest : Request
    {

        private string baseUrl;

        public ServiceRequest(string service, string path, string resource) : base()
        {
            baseUrl = $"https://{service}{(HereAPI.Instance.RunInProdEnv ? "" : ".cit")}.api.here.com/{path}/{resource}.json?";

            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppId), HereAPI.Instance.AppId);
            AddAttribute(PropertyHelper.GetDescription(() => HereAPI.Instance.AppCode), HereAPI.Instance.AppCode);
        }


    }
}
