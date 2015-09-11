using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LBCommon;

namespace LBDataModel
{
    public partial class BackupTask : IBackupTaskDef
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
        
        
        
        [NotMapped]
        ICollection<IBackupScheduleDef> IBackupTaskDef.Schedules 
        {
            get
            {
                var list = new List<IBackupScheduleDef>();
                foreach (var sch in Schedules)
                    list.Add(sch);
                return list;
            }
            set
            {
                ICollection<Schedule> schcol = new List<Schedule>();
                foreach(var sch in value)
                {
                    var ns = new Schedule(sch);
                    ns.BackupTaskId = this.BackupTaskId;
                    schcol.Add(ns);
                }
                Schedules = schcol;
            }
        }

        [NotMapped]
        IUserDef IBackupTaskDef.SourceUser
        {
            get
            {
                return SourceUser;
            }
            set
            {
                SourceUser = new User(value);
            }
        }

        [NotMapped]
        IUserDef IBackupTaskDef.DestUser
        {
            get
            {
                return DestUser;
            }
            set
            {
                DestUser = new User(value);
            }
        }
    }
}
