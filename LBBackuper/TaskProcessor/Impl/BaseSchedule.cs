using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using LBCommon;

namespace LBBackuper
{
    public abstract class BaseSchedule : BaseClass, ISchedule
    {
        /// <summary>
        /// Minimum interval to repeat the schedule
        /// </summary>
        private readonly TimeSpan CHECK_INTERVAL = new TimeSpan(0, 1, 0);

        public BaseSchedule(ITask task)
        {
            Task = task;
        }

        #region ISchedule Members

        public bool CheckSchedule()
        {
            return CheckScheduleInternal();
        }

        public ITask Task { get; set; }

        #endregion

        protected virtual bool CheckScheduleInternal()
        {
            DateTime now = DateTime.Now;
            if (Math.Abs((now - LastDateTime).TotalSeconds) <= CheckInterval.TotalSeconds)
                return false;

            if (DoCheckSchedule(now))
            {
                LastDateTime = now;
                return true;
            }
            else
                return false;
        }

        protected virtual TimeSpan CheckInterval
        {
            get
            {
                return CHECK_INTERVAL;
            }
        }

        protected abstract bool DoCheckSchedule(DateTime now);

        protected DateTime LastDateTime = new DateTime();
    }
}
