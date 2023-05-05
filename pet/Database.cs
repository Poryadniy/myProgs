using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pet
{
    public class Database
    {
        static string connection = "server = localhost; user = root; database = book; password = 24121999Artem";
        private MySqlConnection conn = new MySqlConnection(connection);

        public void open()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ce)
                {
                    Console.WriteLine("Error");
                    throw;
                }
            }
        }

        public void close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public MySqlConnection get_connection()
        {
            return conn;
        }
    }
}