using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LBBackupTaskService
{
    [ServiceContractAttribute(ConfigurationName = "IBackupTaskService")]
    public interface IBackupTaskClient
    {
        [OperationContractAttribute(Action = "http://tempuri.org/IBackupTaskService/GetBackupTasks", ReplyAction = "http://tempuri.org/IBackupTaskService/GetBackupTasksResponse")]
        List<LBCommon.BackupTaskDef> GetBackupTasks();

        [OperationContractAttribute(Action = "http://tempuri.org/IBackupTaskService/GetBackupTasks", ReplyAction = "http://tempuri.org/IBackupTaskService/GetBackupTasksResponse")]
        System.Threading.Tasks.Task<List<LBCommon.BackupTaskDef>> GetBackupTasksAsync();
    }
}
