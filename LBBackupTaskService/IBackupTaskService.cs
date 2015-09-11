using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

using LBCommon;

namespace LBBackupTaskService
{
    [ServiceContract]
    public interface IBackupTaskService
    {

        [OperationContract]
        Task<List<BackupTaskDef>> GetBackupTasks();
    }
}
