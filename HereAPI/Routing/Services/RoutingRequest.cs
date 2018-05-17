using HereAPI.Routing.Conversions;
using HereAPI.Shared.Conversions;
using HereAPI.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.Services
{
    public abstract class RoutingRequest : Request
    {
        
        public RoutingRequest(string service, string path, string resource) : 
            base(service, path, resource)
        {            
        }

        protected override void SetConversions()
        {
            Conversions = new RoutingJsonTypeConversions();
        }
    }
}
