using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCommon
{
    public interface IBackupTaskDef
    {
        string SourceFolder { get; set; }
        IUserDef SourceUser { get; set; }
        string DestFolder { get; set; }
        IUserDef DestUser { get; set; }
        ICollection<IBackupScheduleDef> Schedules { get; set; }
    }
}
