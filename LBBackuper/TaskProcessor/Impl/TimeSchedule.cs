using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBBackuper
{
    /// <summary>
    /// Schedule execution in specified time of day
    /// </summary>
    public class TimeSchedule: BaseSchedule
    {
        private const int ACCURANCY = 1;

        public TimeSchedule(TimeSpan time, ITask task): base(task)
        {
            _time = time;
        }

        protected override bool DoCheckSchedule(DateTime now)
        {
            return Math.Abs((now.TimeOfDay - _time).TotalSeconds) < ACCURANCY;
        }

        private TimeSpan _time;
    }
}
