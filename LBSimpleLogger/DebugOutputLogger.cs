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
    /// Writes application log to the Debug output
    /// </summary>
    public class DebugOutputLogger: ILogWriter
    {
        #region ILogWriter Members

        public void WriteLog(EventLogEntryType messageType, string message)
        {
            Debug.WriteLine(String.Format("{0}: {1}", messageType.ToString(), message));
        }

        #endregion
    }
}
