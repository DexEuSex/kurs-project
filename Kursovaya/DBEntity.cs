using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace PraktZavd1
{
    abstract class DbEntity<T>
    {
        public PropertyInfo[] GetObjProperties()
        {
            Type serviceType = typeof(T);
            PropertyInfo[] myPropertyInfo = serviceType.GetProperties();
            return myPropertyInfo;
        }
    }

}