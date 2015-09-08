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
    public class TaskProcessor : ITaskProcessor, IDisposable
    {
        // Pause between main thread iteration
        private const int WAIT_INTERVAL = 2000;

        #region ITaskProcessor Members

        public void AddSchedule(ISchedule schedule)
        {
            lock (_schedulesSyncro)
            {
                _schedules.Add(schedule, new DateTimeBox());
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

        [Inject]
        public ITaskQueue Queue { get; set; }

        [Inject]
        public ILog Logger { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            Stop();
        }

        ~TaskProcessor()
        {
            Stop();
        }
        
        #endregion

        private void Run()
        {
            Logger.Write(EventLogEntryType.Information, "Worker thread started");
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
                    Logger.Write(EventLogEntryType.Error, "Error while processing the schedule\n" + e.Message);
                }
            }
            Logger.Write(EventLogEntryType.Information, "Worker thread stoped");
        }

        private void DoProcessTasks()
        {
            lock (_schedulesSyncro)
            {
                DateTime now = DateTime.Now;
                foreach (ISchedule sch in _schedules.Keys)
                {
                    if (sch.Time.Hours == now.Hour && sch.Time.Minutes == now.Minute)
                    {
                        DateTimeBox dtb = _schedules[sch];
                        if (Math.Abs((now - dtb.date).TotalMinutes) > 1)
                        {
                            dtb.date = now;
                            Queue.QueueTask(sch.Task);
                        }
                    }
                }
            }
        }

        private class DateTimeBox { public DateTime date = new DateTime(); }
        private Dictionary<ISchedule, DateTimeBox> _schedules = new Dictionary<ISchedule, DateTimeBox>();
        private bool _stoped = false;
        private Object _schedulesSyncro = new Object();
        private Thread _mainThread;
        private ManualResetEvent _waitEvent = new ManualResetEvent(false);
    }
}   


