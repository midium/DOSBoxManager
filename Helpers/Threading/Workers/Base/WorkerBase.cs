using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers.Threading.Workers.Base
{
    public abstract class WorkerBase : IDisposable
    {
        #region "Declarations"
        protected ManualResetEvent _eventX;
        private bool _isDisposed = false;
        #endregion

        #region "Declaration"
        public WorkerBase()
        {
        }
        #endregion

        #region "Must Override Methods"
        public abstract void DoWork();
        public abstract void Download();
        #endregion

        #region "Properties"
        public ManualResetEvent eventX
        {
            get { return _eventX; }
            set { _eventX = value; }
        }
        #endregion

        #region "IDisposable Implementation"
        public virtual void Dispose()
        {
            _isDisposed = true;
            if(_eventX != null)
                _eventX.Dispose();
        }

        public virtual bool IsDisposed
        {
            get { return _isDisposed; }
        }
        #endregion
    }
}
