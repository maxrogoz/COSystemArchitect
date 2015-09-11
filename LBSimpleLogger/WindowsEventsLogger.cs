using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using LBCommon;

namespace LBLogger
{
    /// <summary>
    /// Writes application log to the windows events journal
    /// </summary>
    public class WindowsEventsLogger : ILogWriter
    {
        public WindowsEventsLogger(string applicationName)
        {
            _applicationName = applicationName;
            if (!EventLog.SourceExists(applicationName))
            {
                EventLog.CreateEventSource(applicationName, applicationName);
            }
        }

        #region ILogWriter Members

        public void WriteLog(System.Diagnostics.EventLogEntryType messageType, string message)
        {
            EventLog.WriteEntry(_applicationName, message, messageType);
        }

        #endregion

        private string _applicationName;
    }

}
