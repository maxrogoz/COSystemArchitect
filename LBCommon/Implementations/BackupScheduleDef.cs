using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LBCommon
{
    [DataContract]
    public class BackupScheduleDef : IBackupScheduleDef
    {
        public BackupScheduleDef()
        {
        }

        public BackupScheduleDef(IBackupScheduleDef def) 
        {
            if (def == null)
                return;
            Time = def.Time;
        }

        [DataMember]
        public TimeSpan Time { get; set; }
    }
}
