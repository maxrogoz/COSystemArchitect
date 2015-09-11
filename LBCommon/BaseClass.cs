using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using LBCommon;

namespace LBCommon
{
    public class BaseClass
    {
        public static IKernel Kernel;// = new StandardKernel();
        protected ILog Logger = Kernel.Get<ILog>();
    }
}
