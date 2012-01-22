using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleLibrary
{
    public static class Extensions
    {
        //private bool result = false;
        public static bool IsNotNull(this object obj)
        {
            return obj.IsNull() ? false : true;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null ? true : false;
        }
    }
}
