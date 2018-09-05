using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datamanager_Mockup.Models
{
    public class SessionHelper
    {

        public static T Get<T>(string variable)
        {
            object value = HttpContext.Current.Session[variable];
            if (value == null)
                return default(T);
            else
                return ((T)value);
        }

        public static void Set(string variable, object value)
        {
            HttpContext.Current.Session[variable] = value;
        }


    }
}