using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCommon
{
    public interface ILogWriter
    {
        /// <summary>
        /// Writes message to the log.
        /// </summary>
        /// <param name="messageType">Message type (Error, Warning, Info)</param>
        /// <param name="message">Message</param>
        void WriteLog(System.Diagnostics.EventLogEntryType messageType, string message);
    }
}
