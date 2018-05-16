using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Shared.Requests
{
    public enum HttpStatus
    {
        /// <summary>
        /// Indicates success, but may also be returned when an invalid resource name and/or an invalid parameter combination has been used in the request. 
        /// </summary>
        OK = 200,
        /// <summary>
        /// Invalid parameter value in the request, for example zoom out of range.
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// Invalid authentication.
        /// </summary>
        Unauthorized = 401,     
        /// <summary>
        /// Incorrect app_code or app_id in the request. See Acquiring Credentials for more information.
        /// </summary>
        Forbidden = 403,    
        /// <summary>
        /// Unsupported parameter in the request.
        /// </summary>
        NotFound = 404,   
        /// <summary>
        /// There is a server configuration issue.
        /// </summary>
        InternalError = 500,   
        /// <summary>
        /// Indicates that the service is temporarily unavailable due to system overload or maintenance.
        /// </summary>
        ServiceUnavailable = 503    
    }
}
