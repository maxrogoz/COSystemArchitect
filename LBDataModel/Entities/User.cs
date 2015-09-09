using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBDataModel
{
    public partial class User
    {
        public User()
        {
            this.DestBackupTasks = new HashSet<BackupTask>();
            this.SourceBackupTasks = new HashSet<BackupTask>();
        }
    
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        
        [Required]
        public string Login { get; set; }

        public string Domain { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }
    
        public virtual ICollection<BackupTask> DestBackupTasks { get; set; }
        public virtual ICollection<BackupTask> SourceBackupTasks { get; set; }
    }
}
