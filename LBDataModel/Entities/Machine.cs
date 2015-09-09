using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBDataModel
{
    public partial class Machine
    {
        public Machine()
        {
            this.BackupTasks = new HashSet<BackupTask>();
        }
    
        public int MachineId { get; set; }
        [Display(Name = "IP Adress")]
        public string IpAdress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<BackupTask> BackupTasks { get; set; }
    }
}
