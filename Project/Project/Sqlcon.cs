using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project
{
    class Sqlcon
    {
        public static SqlConnection cn = new SqlConnection("server = MUHAMMED-PC ; DataBase = mohamed12 ; Integrated Security = true ");
        public static SqlDataAdapter da;
        public static SqlCommand cmd;
    }
}
