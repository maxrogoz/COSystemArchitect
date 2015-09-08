using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;

using LBCommon;
using LBBackuper;
using LBSimpleLogger;

namespace LBBackuperTest
{
    public class IoC : NinjectModule
    {
        public override void Load()
        {
            SimpleLog.DefaultApplicationName = "LBBackuperTest";

            this.Bind<ILog>().To<SimpleLog>();
            this.Bind<IFileProcessor>().To<FileProcessor>();
            this.Bind<ITask>().To<BackupTask>();
            this.Bind<ITaskQueue>().To<TaskQueue>();
            this.Bind<ITaskProcessor>().To<TaskProcessor>();
            this.Bind<ISchedule>().To<BackupSchedule>();
        }
    }
}
