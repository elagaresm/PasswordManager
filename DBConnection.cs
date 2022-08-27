using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManger
{
    class DBConnection
    {
        public SqlConnection getConn()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Enmanuel\\source\\repos\\PasswordManger\\myDatabase.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            return con;
        }
    }
}
