using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LBCommon;

namespace LBBackuper
{
    public interface ITask
    {
        void Execute();
        object Params { get; set; }
    }
}
