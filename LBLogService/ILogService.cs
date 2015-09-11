using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LBLogService
{
    [ServiceContract]
    public interface ILogService
    {

        [OperationContract]
        Task WriteLog(string applicationName, EventLogEntryType messageType, string message);
    }
}
