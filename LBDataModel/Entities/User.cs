using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LBCommon;

namespace LBDataModel
{
    public partial class User : IUserDef
    {
        public User()
        {
            this.DestBackupTasks = new HashSet<BackupTask>();
            this.SourceBackupTasks = new HashSet<BackupTask>();
        }

        public User(IUserDef def)
            : this()
        {
            Login = def.Login;
            Domain = def.Domain;
            Password = def.Password;
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
