using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoOS
{
    public static class Extensions
    {

        public static string ToStrinX(this object value)
        {
            string retvalue = "";

            if (value != null)
                retvalue = value.ToString();

            return retvalue;


        }

        public static int ToInt(this object value)
        {
            int number = 0;

            if (value != null)
                int.TryParse(value.ToString(), out number);

            return number;
        }
    }
}
