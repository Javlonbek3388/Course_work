using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futbol_liga
{
    internal class ConnectDB
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;
        protected string sqlString;

        public ConnectDB()
        {
            string connectionString = "Server=*;Database=FUTBOL;Trusted_Connection=True;";
            this.conn = new SqlConnection(connectionString);
            this.conn.Open();
        }
        ~ConnectDB()
        {
            this.conn = null;
        }
    }

}
