using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using LBCommon;

namespace LBBackuper
{
    public abstract class BaseTask: BaseClass, ITask
    {
        public BaseTask(object taskParams)
        {
            Params = taskParams;
        }

        #region ITask Members

        public void Execute()
        {
            try
            {
                Logger.WriteInfo("Start " + ToString());

                DoExecute();

                Logger.WriteInfo("Finish " + ToString());
            }
            catch (Exception e)
            {
                Logger.WriteError("Error " + ToString() + "\n" + e.Message);
            }
        }

        public object Params { get; set; }

        #endregion

        protected abstract void DoExecute();
    }
}
