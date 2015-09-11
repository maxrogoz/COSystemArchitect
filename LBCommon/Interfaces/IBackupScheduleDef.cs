using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCommon
{
    public interface IBackupScheduleDef
    {
        TimeSpan Time { get; set; }
    }
}
