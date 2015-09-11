using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;

using LBCommon;
using LBLogService;

namespace LBLogger
{
    /// <summary>
    /// Writes application log to the WEB Service in asyncronius mode
    /// </summary>
    public class WebServiceLogger : ILogWriter, IDisposable
    {
        public WebServiceLogger(string applicationName)
        {
            _applicationName = applicationName;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Close();
        }

        ~WebServiceLogger()
        {
            Close();
        }

        #endregion

        public void Close()
        {
            if (_logService != null && _logService.State != CommunicationState.Closed)
                _logService.Close();
            _logService = null;
        }

        public void WriteLog(System.Diagnostics.EventLogEntryType messageType, string message)
        {
            LogService.WriteLogAsync(_applicationName, messageType, message);
        }

        public LogClient LogService
        {
            get
            {
                if (_logService == null)
                    _logService = new LogClient();

                if (_logService.State != System.ServiceModel.CommunicationState.Opened)
                    _logService.Open();

                return _logService;
            }
        }

        private string _applicationName;
        private LogClient _logService;
    }
}
