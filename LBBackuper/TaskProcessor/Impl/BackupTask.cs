using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Ninject;

using LBCommon;

namespace LBBackuper
{
    public class BackupTask : ITask
    {
        #region ITask Members

        public void Execute()
        {
            try
            {
                Logger.Write(EventLogEntryType.Information, "Starting backup task " + ToString());

                FileProcessor.CopyPathWithUserRights(SourceFolder, SourceUser, DestFolder, DestUser);

                Logger.Write(EventLogEntryType.Information, "Backup task " + ToString() + " sucessfuly finished");
            }
            catch (Exception e)
            {
                Logger.Write(System.Diagnostics.EventLogEntryType.Error, "Error executing backup task " + ToString() + "\n" + e.Message);
            }
        }

        #endregion

        public string SourceFolder { get; set; }

        public IUser SourceUser { get; set; }

        public string DestFolder { get; set; }

        public IUser DestUser { get; set; }

        public override string ToString()
        {
            return String.Format("{0}{1} -> {2}{3}", SourceFolder, SourceUser == null ? "" : "(" + SourceUser.ToString() + ")",
                DestFolder, DestUser == null ? "" : "(" + DestUser.ToString() + ")");
        }

        [Inject]
        public IFileProcessor FileProcessor { get; set; }

        [Inject]
        public ILog Logger { get; set; }
    }
}
