using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;

using LBCommon;
using LBBackuper;
using LBLogger;
using LBBackupTaskService;

namespace LBBackuperTest
{
    public class IoC : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILog>().To<BaseLogger>();
            this.Bind<IFileProcessor>().To<FileProcessor>();
            this.Bind<ITaskQueue>().To<TaskQueue>();
            this.Bind<IScheduler>().To<Scheduler>();
            this.Bind<IConfigReader>().To<WebServiceBackupConfigReader>();
        }

    }
}
