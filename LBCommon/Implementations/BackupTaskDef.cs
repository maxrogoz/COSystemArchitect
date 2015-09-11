using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LBCommon
{
    [DataContract]
    public class BackupTaskDef : IBackupTaskDef
    {
        public BackupTaskDef()
        {
            Schedules = new List<IBackupScheduleDef>();
        }

        public BackupTaskDef(IBackupTaskDef def)
            : this()
        {
            if (def == null)
                return;
            SourceFolder = def.SourceFolder;
            SourceUser = def.SourceUser;
            DestFolder = def.DestFolder;
            DestUser = def.DestUser;
            Schedules = def.Schedules;
        }

        #region IBackupTask Members

        [DataMember]
        public string SourceFolder { get; set; }

        public IUserDef SourceUser
        {
            get
            {
                return _sourceUser;
            }
            set
            {
                _sourceUser = new UserDef(value);
            }
        }

        [DataMember]
        public string DestFolder { get; set; }

        public IUserDef DestUser
        {
            get
            {
                return _destUser;
            }
            set
            {
                _destUser = new UserDef(value);
            }
        }

        public ICollection<IBackupScheduleDef> Schedules
        {
            get
            {
                var list = new List<IBackupScheduleDef>(_schedules.Count);
                foreach (var sch in _schedules)
                    list.Add(sch);
                return list;
            }
            set
            {
                SchedulesDef.Clear();
                foreach(var sch in value)
                {
                    _schedules.Add(new BackupScheduleDef(sch));
                }
            }
        }

        #endregion

        [DataMember(Name = "SourceUser")]
        public UserDef SourceUserImpl 
        {
            get
            {
                return _sourceUser;
            }
            set
            {
                _sourceUser = value;
            }
        }

        [DataMember(Name = "DestUser")]
        public UserDef DestUserImpl
        {
            get
            {
                return _destUser;
            }
            set
            {
                _destUser = value;
            }
        }

        [DataMember(Name = "Schedules")]
        public List<BackupScheduleDef> SchedulesDef
        {
            get
            {
                if (_schedules == null)
                    _schedules = new List<BackupScheduleDef>();
                return _schedules;
            }
            set
            {
                _schedules = value;
            }
        }

        private UserDef _sourceUser;
        private UserDef _destUser;
        private List<BackupScheduleDef> _schedules;
    }
}
