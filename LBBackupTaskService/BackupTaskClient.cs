using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LBBackupTaskService
{
    [DebuggerStepThrough]
    public partial class BackupTaskServiceClient : ClientBase<IBackupTaskClient>, IBackupTaskClient
    {
    
        public BackupTaskServiceClient()
        {
        }
    
        public BackupTaskServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
    
        public BackupTaskServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
    
        public BackupTaskServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
    
        public BackupTaskServiceClient(Binding binding, EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
    
        public List<LBCommon.BackupTaskDef> GetBackupTasks()
        {
            return base.Channel.GetBackupTasks();
        }
    
        public System.Threading.Tasks.Task<List<LBCommon.BackupTaskDef>> GetBackupTasksAsync()
        {
            return base.Channel.GetBackupTasksAsync();
        }
    }
}
