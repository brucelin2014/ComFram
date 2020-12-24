// 2020-12-24, Bruce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ComFram
{
    public class DBHelper
    {
        public static string ConnStrng 
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            }
        }

    }

}
