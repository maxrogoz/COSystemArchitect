using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LBCommon;

namespace LBLogger
{
    /// <summary>
    /// Writes application log to the console
    /// </summary>
    public class ConsoleLogger: ILogWriter
    {
        #region ILogWriter Members

        public void WriteLog(System.Diagnostics.EventLogEntryType messageType, string message)
        {
            Console.WriteLine(String.Format("{0:HH:mm:ss.ff}: {1} - {2}", DateTime.Now, messageType.ToString(), message));
        }

        #endregion
    }
}
