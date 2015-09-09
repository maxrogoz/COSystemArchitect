using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBDataModel
{
    
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int BackupTaskId { get; set; }
        public System.TimeSpan Time { get; set; }
    
        public virtual BackupTask BackupTask { get; set; }
    }
}
