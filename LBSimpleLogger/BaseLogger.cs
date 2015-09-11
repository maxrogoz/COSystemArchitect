using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LBCommon
{
    /// <summary>
    /// Base class for logging modules
    /// </summary>
    public class BaseLogger : ILog
    {
        #region ILog Members //-----------------------------------

        public void RegisterLogWriter(ILogWriter logWriter)
        {
            lock (SyncroObject)
            {
                LogWriters.Add(logWriter);
            }
        }

        public void UnregisterLogWriter(ILogWriter logWriter)
        {
            lock (SyncroObject)
            {
                LogWriters.Remove(logWriter);
            }
        }

        public void WriteError(string message)
        {
            Write(EventLogEntryType.Error, message);
        }

        public void WriteWarning(string message)
        {
            Write(EventLogEntryType.Warning, message);
        }

        public void WriteInfo(string message)
        {
            Write(EventLogEntryType.Information, message);
        }

        public virtual void Write(EventLogEntryType logMessageType, string message)
        {
            lock (SyncroObject)
            {
                foreach (var lw in LogWriters)
                    lw.WriteLog(logMessageType, message);
            }
        }

        #endregion

        protected static List<ILogWriter> LogWriters = new List<ILogWriter>();
        protected static object SyncroObject = new Object();

    }
}
