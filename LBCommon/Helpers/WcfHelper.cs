using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace LBCommon
{
    public class WcfHelper
    {
        /// <summary>
        /// Returns client IP address
        /// </summary>
        /// <returns>Client IP address</returns>
        public static string GetClientIP()
        {
            OperationContext context = OperationContext.Current;

            if (context == null)
                throw new InvalidOperationException("GetClientIP: Operation context not assigned. You should use this method in WCF main thread.");

            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
               prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;

            // If webservice called as 'localhost' from the local machine then endpoint.Address will be ::1.
            if (ip == "::1")
                ip = "127.0.0.1";

            return ip;

        }
    }
}
