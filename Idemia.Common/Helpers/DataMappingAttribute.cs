﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.Common.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataMappingAttribute : System.Attribute
    {
        #region Private Variables
        private string _dataFieldName;
        private object _nullValue;
        #endregion
        #region Constructors
        public DataMappingAttribute(string dataFieldName, object nullValue)
            : base()
        {
            _dataFieldName = dataFieldName;
            _nullValue = nullValue;
        }
        public DataMappingAttribute(object nullValue) : this(string.Empty, nullValue) { }
        #endregion
        #region Public Properties
        public string DataFieldName
        {
            get { return _dataFieldName; }
        }
        public object NullValue
        {
            get { return _nullValue; }
        }
        #endregion
    }//end class
}//end namespace