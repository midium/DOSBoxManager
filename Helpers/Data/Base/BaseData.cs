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
using Helpers.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Data.Base
{
    public class BaseData
    {
        #region "Declaration"
        protected SQLiteConnection _Connection;
        protected String _ConnectionString;
        protected String _DBPath;
        protected FileHelpers _fileHelpers;
        #endregion

        #region "Constructors/Destructors"
        public BaseData()
        {
            _Connection = null;
            _DBPath = String.Empty;
            _ConnectionString = String.Empty;
            _fileHelpers = new FileHelpers();
        }

        public BaseData(String DBPath)
        {
            _Connection = null;
            _DBPath = DBPath;
            _ConnectionString = String.Format("Data Source={0};Version=3;", DBPath);
            _fileHelpers = new FileHelpers();

            //Connection
            _Connection = new SQLiteConnection(_ConnectionString);
            _Connection.Open();

        }

        ~BaseData()
        {
            try
            {
                if (_Connection != null && _Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                    _Connection.Dispose();
                }
            } 
            catch (Exception) 
            {

            }
        }
        #endregion

        #region "Public Methods"
        public bool Connect()
        {
            bool result = true;

            if (_ConnectionString == string.Empty)
                throw new Exception("Empty Connection String");

            try
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection(_ConnectionString);

                }
                else
                {
                    if (_Connection.State == System.Data.ConnectionState.Open)
                        //I raise an error as there is already an open connection
                        throw new Exception("There is another open connection");

                    _Connection.ConnectionString = _ConnectionString;
                    _Connection.Open();


                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Connect(String DBPath)
        {
            bool result = true;

            _DBPath = DBPath;
            _ConnectionString = String.Format("Data Source={0};Version=3;", DBPath);

            try
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection(_ConnectionString);
                    _Connection.Open();

                }
                else
                {
                    if (_Connection.State == System.Data.ConnectionState.Open)
                        //I raise an error as there is already an open connection
                        throw new Exception("There is another open connection");

                    _Connection.ConnectionString = _ConnectionString;
                    _Connection.Open();

                }

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public void Disconnect()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _DBPath = string.Empty;
                _ConnectionString = string.Empty;
            }
        }
        #endregion

        #region "Helpers"
        protected int BoolToInt(bool value)
        {
            return (value) ? 1 : 0;
        }
        #endregion

        #region "Properties"
        public String DBPath
        {
            get
            {
                return _DBPath;
            }
            set
            {
                if (_DBPath != value)
                    _DBPath = value;
            }
        }

        public String DBName
        {
            get { return _fileHelpers.ExtractFileName(_DBPath); }
        }

        public String ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                if (_ConnectionString != value)
                    _ConnectionString = value;
            }
        }

        public System.Data.ConnectionState ConnectionStatus
        {
            get
            {
                if (_Connection == null)
                    return System.Data.ConnectionState.Closed;

                return _Connection.State;
            }
        }
        #endregion
    }
}
