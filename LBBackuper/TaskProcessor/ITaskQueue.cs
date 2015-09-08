using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBBackuper
{
    public interface ITaskQueue
    {
        void QueueTask(ITask task);
    }
}
