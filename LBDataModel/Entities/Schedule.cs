using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LBCommon;

namespace LBDataModel
{
    
    public partial class Schedule : IBackupScheduleDef
    {
        public Schedule()
        {
        }

        public Schedule(IBackupScheduleDef bsd)
        {
            this.Time = bsd.Time;
        }

        public int ScheduleId { get; set; }
        public int BackupTaskId { get; set; }
        public TimeSpan Time { get; set; }
    
        public virtual BackupTask BackupTask { get; set; }
    }
}
