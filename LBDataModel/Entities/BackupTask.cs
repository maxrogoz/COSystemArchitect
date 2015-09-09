using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBDataModel
{
    public partial class BackupTask
    {
        public BackupTask()
        {
            this.Schedules = new HashSet<Schedule>();
        }
    
        public int BackupTaskId { get; set; }
        
        public int MachineId { get; set; }

        [Display(Name = "Source folder")]
        public string SourceFolder { get; set; }
        
        public int? SourceUserId { get; set; }
        
        [Display(Name = "Destination folder")]
        public string DestFolder { get; set; }
        
        public int? DestUserId { get; set; }
        
        public bool Disabled { get; set; }
    
        public virtual Machine Machine { get; set; }

        [Display(Name = "User to access dest. folder")]
        public virtual User DestUser { get; set; }

        [Display(Name = "User to access source folder")]
        public virtual User SourceUser { get; set; }
        
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
