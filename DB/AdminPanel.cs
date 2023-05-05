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
    public partial class AdminPanel : Form
    {
        DataBase DataBase = new DataBase();
        MySqlCommand command;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(textBox1.Text, DataBase.Get_connection());

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand(textBox1.Text, DataBase.Get_connection());

            DataBase.Open();

            command.ExecuteNonQuery();

            DataBase.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand(textBox1.Text, DataBase.Get_connection());

            DataBase.Open();

            command.ExecuteNonQuery();

            DataBase.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand(textBox1.Text, DataBase.Get_connection());

            DataBase.Open();

            command.ExecuteNonQuery();

            DataBase.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + textBox2.Text, DataBase.Get_connection());

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdatePrice UpdatePrice = new UpdatePrice();
            UpdatePrice.Show();
        }
    }
}
