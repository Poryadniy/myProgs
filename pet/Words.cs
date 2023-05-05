using System.Data;
using static pet.Database;
using MySql.Data.MySqlClient;
using System.Linq;

namespace pet
{
    public class Words
    {
        public string[] en_words()
        {
            string[] words = new string[] { };
            
            Database db = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string query = "SELECT en_word FROM words";
            MySqlCommand command = new MySqlCommand(query, db.get_connection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row  in table.Rows)
            {
                words = words.Append(row["en_word"].ToString()).ToArray();
            }

            return en_words();
        }

        public string[] ru_words()
        {
            string[] words = new string[] { };
            
            Database db = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string query = "SELECT ru_word FROM words";
            MySqlCommand command = new MySqlCommand(query, db.get_connection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row  in table.Rows)
            {
                words = words.Append(row["ru_word"].ToString()).ToArray();
            }

            return ru_words();
        }
    }
}