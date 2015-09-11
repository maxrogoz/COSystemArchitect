using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LBLogService
{
    [DebuggerStepThrough]
    public partial class LogClient : ClientBase<ILogClient>, ILogClient
    {
    
        public LogClient()
        {
        }
    
        public LogClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
    
        public LogClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
    
        public LogClient(string endpointConfigurationName, EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public LogClient(Binding binding, EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }

        public void WriteLog(string applicationName, EventLogEntryType messageType, string message)
        {
            base.Channel.WriteLog(applicationName, messageType, message);
        }

        public Task WriteLogAsync(string applicationName, EventLogEntryType messageType, string message)
        {
            return base.Channel.WriteLogAsync(applicationName, messageType, message);
        }
    }
}