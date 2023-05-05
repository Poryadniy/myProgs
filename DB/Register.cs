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
    public partial class Register : Form
    {
        DataBase DataBase = new DataBase();
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUserExists())
            {
                return;
            }


            //MySqlConnection connection = new MySqlConnection("server = localhost;database = volsu;user = root; password = 24121999Artem");

            MySqlCommand command = new MySqlCommand("INSERT INTO users(login,password,status)VALUES(@login,@password,@status)", DataBase.Get_connection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "user";

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("login or password field's empty");
                return;
            }

            DataBase.Open();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account successfully created");
            }
            else
            {
                MessageBox.Show("Error when creating an account");
            }

            Login fm1 = new Login();
            fm1.Show();
            this.Hide();

            DataBase.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login fm1 = new Login();
            this.Hide();
            fm1.Show();
        }

        public Boolean isUserExists()
        {
            //MySqlConnection connection = new MySqlConnection("server = localhost;database = volsu;user = root; password = 24121999Artem");
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @ul", DataBase.Get_connection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This login already exists, please enter new login");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}