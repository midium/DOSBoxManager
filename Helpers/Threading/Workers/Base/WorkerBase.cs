/*
 * DOSBox Manager : .NET front-end for DOSBox
 * Copyright (C) 2015 MiDiUm Software
 * 
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program.
 * If not, see <http://www.gnu.org/licenses/>.
 */
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
