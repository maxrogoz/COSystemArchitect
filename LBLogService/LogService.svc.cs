using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;

using LBCommon;
using LBDataModel;

namespace LBLogService
{
    public class LogService : ILogService
    {
        #region ILogService Members

        public async Task WriteLog(string applicationName, EventLogEntryType messageType, string message)
        {
            string ipAddress = WcfHelper.GetClientIP();
            await Task.Factory.StartNew(delegate()
            {
                InternalTaskWriteLog(ipAddress, applicationName, messageType, message);
            });
        }

        #endregion

        private LBDataModelContext db = new LBDataModelContext();

        public void InternalTaskWriteLog(string ipAddress, string applicationName, EventLogEntryType messageType, string message)
        {
            db.Logs.Add(new Log() {
                LogDateTime = DateTime.Now,
                IpAddress = ipAddress,
                Service = applicationName,
                MessageType = messageType,
                Message = message
            });
            db.SaveChanges();
        }
    }
}
