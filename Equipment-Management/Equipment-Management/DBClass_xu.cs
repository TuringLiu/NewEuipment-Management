using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Equipment_Management
{
    class DBClass_xu
    {
        public static string strConn = "Server=25.24.20.180;Initial Catalog=Equipment Management Information System;uid=xujiahao;pwd=201608";
        public static SqlConnection conn = new SqlConnection(strConn);
    }
}
