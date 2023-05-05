using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DB
{
    public partial class UpdatePrice : Form
    {
        DataBase DataBase = new DataBase();
        public UpdatePrice()
        {
            InitializeComponent();
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {
            DataBase.Open();

            MySqlCommand command3 = new MySqlCommand("SELECT name from assets;", DataBase.Get_connection());
            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                listBox1.Items.Add(reader3[0]);

            }
            DataBase.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Open();


            MySqlCommand command = new MySqlCommand("UPDATE assets SET price = @price WHERE ID = @ID", DataBase.Get_connection());
            command.Parameters.Add("@price", MySqlDbType.Double).Value = Convert.ToDouble(textBox1.Text);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = listBox1.SelectedIndex + 1;

            command.ExecuteNonQuery();

            DataBase.Close();

            DataBase.Open();

            MySqlCommand command1 = new MySqlCommand("changes", DataBase.Get_connection());
            command1.CommandType = CommandType.StoredProcedure;
            MySqlParameter parameter = new MySqlParameter();
            command1.Parameters.AddWithValue("a", 1);
            command1.Parameters.AddWithValue("b", 2000);

            command1.ExecuteNonQuery();

            DataBase.Close();


        }
    }
}
