using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using System.Diagnostics;

using LBCommon;


namespace LBBackuper
{
    public class Scheduler : BaseClass, IScheduler, IDisposable
    {
        // Pause between main thread iteration
        private const int WAIT_INTERVAL = 2000;

        #region ITaskProcessor Members

        public void AddSchedule(ISchedule schedule)
        {
            lock (_schedulesSyncro)
            {
                _schedules.Add(schedule);
            }
        }

        public void AddSchedules(ICollection<ISchedule> schedules)
        {
            lock (_schedulesSyncro)
            {
                foreach(var schedule in schedules)
                    _schedules.Add(schedule);
            }
        }

        public void DeleteSchedule(ISchedule schedule)
        {
            lock (_schedulesSyncro)
            {
                _schedules.Remove(schedule);
            }
        }

        public void Clear()
        {
            lock (_schedulesSyncro)
            {
                _schedules.Clear();
            }
        }

        public void Start()
        {
            _waitEvent.Reset();
            _stoped = false;
            _mainThread = new Thread(new ThreadStart(Run));
            _mainThread.Start();
        }

        public void Stop()
        {
            _stoped = true;
            if (_mainThread != null)
            {
                _mainThread.Join();
                _mainThread = null;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Stop();
        }

        ~Scheduler()
        {
            Stop();
        }
        
        #endregion

        private void Run()
        {
            while (!_stoped)
            {
                try
                {
                    DoProcessTasks();
                    _waitEvent.WaitOne(WAIT_INTERVAL);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (Exception e)
                {
                    Logger.WriteError("Scheduler: Error while processing the schedule\n" + e.Message);
                }
            }
        }

        private void DoProcessTasks()
        {
            lock (_schedulesSyncro)
            {
                foreach (ISchedule sch in _schedules)
                {
                    if (sch.CheckSchedule())
                        Queue.QueueTask(sch.Task);
                }
            }
        }

        protected ITaskQueue Queue = Kernel.Get<ITaskQueue>();
        private List<ISchedule> _schedules = new List<ISchedule>();
        private bool _stoped = false;
        private Object _schedulesSyncro = new Object();
        private Thread _mainThread;
        private ManualResetEvent _waitEvent = new ManualResetEvent(false);
    }
}   


