using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBBackuper
{
    /// <summary>
    /// Schedule execution in specified period
    /// </summary>
    public class IntervalSchedule : BaseSchedule
    {
        public IntervalSchedule(TimeSpan interval, ITask task)
            : base(task)
        {
            _interval = interval;
        }

        protected override bool DoCheckSchedule(DateTime now)
        {
            return true;
        }
        
        protected override TimeSpan CheckInterval
        {
            get
            {
                return _interval;
            }
        }

        private TimeSpan _interval;
    }
}
