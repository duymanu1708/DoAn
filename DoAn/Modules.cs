using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DoAn
{
    class Modules
    {
        public static string cnnStr = "Data Source=.;Initial Catalog=QLNHASCH;Integrated Security=True";
        public static SqlConnection cnn = new SqlConnection(cnnStr);
    }
}
