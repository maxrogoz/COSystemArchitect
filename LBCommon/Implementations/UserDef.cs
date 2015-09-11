using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LBCommon
{
    [DataContract]
    public class UserDef : IUserDef
    {
        public UserDef()
        {
        }

        public UserDef(IUserDef def)
        {
            if (def == null)
                return;
            Login = def.Login;
            Domain = def.Domain;
            Password = def.Password;
        }

        [DataMember]
        public string Login { get; set; }
        
        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
