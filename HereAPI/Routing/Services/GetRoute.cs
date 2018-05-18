using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.Services
{
    public class GetRoute : RoutingRequest
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="service"></param>
        /// <param name="path"></param>
        /// <param name="resource"></param>
        public GetRoute(string service, string path, string resource) : base(service, path, resource)
        {
        }

        public override string[] ValidateConditionalAttributes()
        {
            throw new NotImplementedException();
        }

        protected override void AddSpecifiedAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
