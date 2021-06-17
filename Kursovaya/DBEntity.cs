using System;
using System.Reflection;

namespace MainProgram
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