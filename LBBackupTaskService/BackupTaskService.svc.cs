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

using LBCommon;
using LBDataModel;

namespace LBBackupTaskService
{
    public class BackupTaskService : IBackupTaskService
    {
        #region IBackupTaskService Members

        public async Task<List<BackupTaskDef>> GetBackupTasks()
        {
            string ipAddress = WcfHelper.GetClientIP();
            return await Task.Factory.StartNew<List<BackupTaskDef>>(delegate()
            {
                return InternalGetBackupTasks(ipAddress);
            });
        }

        #endregion

        private LBDataModelContext db = new LBDataModelContext();

        public List<BackupTaskDef> InternalGetBackupTasks(string ipAddress)
        {
            var tasks =
                from bt in db.BackupTasks
                where bt.Machine != null
                    && bt.Machine.IpAdress == ipAddress
                    && (bt.Disabled == null || bt.Disabled == false)
                    && bt.Schedules.Count > 0
                select
                    bt;
            
            List<BackupTaskDef> result = new List<BackupTaskDef>();
            foreach (var bt in tasks.ToList())
            {
                result.Add(new BackupTaskDef(bt));
            }

            return result;
        }
    }
}
