using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBBackuper
{
    public interface ITaskProcessor
    {
        void AddSchedule(ISchedule schedule);
        void Start();
        void Stop();
    }
}
