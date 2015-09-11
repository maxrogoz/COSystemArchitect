using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using LBCommon;

namespace LBLogService
{
    [ServiceContract(ConfigurationName = "ILogService")]
    public interface ILogClient
    {
        [OperationContract(Action = "http://tempuri.org/ILogService/WriteLog", ReplyAction = "http://tempuri.org/ILogService/WriteLogResponse")]
        void WriteLog(string applicationName, EventLogEntryType messageType, string message);

        [OperationContract(Action = "http://tempuri.org/ILogService/WriteLog", ReplyAction = "http://tempuri.org/ILogService/WriteLogResponse")]
        Task WriteLogAsync(string applicationName, EventLogEntryType messageType, string message);
    }
}
