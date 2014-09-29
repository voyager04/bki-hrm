using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Utils
{
    public class Helper
    {
        public static string GetDisplayName(string ip_first_name, string ip_last_name)
        {
            return string.Format("{0} {1}", ip_first_name, ip_last_name);
        }

        public static string BsCLS = "45AD7B06-A08E-4286-A20A-653487F56D2A";
    }
}
