using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB
{
    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("server = localhost;database = volsu;user = root;password = 24121999Artem");

        public void Open()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void Close()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public MySqlConnection Get_connection()
        {
            return connection;
        }
    }
}
