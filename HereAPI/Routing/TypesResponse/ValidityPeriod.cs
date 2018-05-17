using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.TypesResponse
{

    /// <summary>
    /// Time period when the something is relevant
    /// </summary>
    public class ValidityPeriod
    {

        public DateTime From { get; set; }

        public DateTime Until { get; set; }

    }
}
