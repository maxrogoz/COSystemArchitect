using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCommon
{
    public interface IUserDef
    {
        string Login { get; set; }
        string Domain { get; set; }
        string Password { get; set; }
    }
}
