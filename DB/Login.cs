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
    public partial class Login : Form
    {
        DataBase DataBase = new DataBase();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.Open();
                MessageBox.Show("Successfully connection to the DB");
            }
            catch
            {
                MessageBox.Show("Wrong connection to the DB");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string User_login = textBox1.Text;
            string User_password = textBox2.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @ul AND password = @up",DataBase.Get_connection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = User_login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = User_password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int flag = 0;
            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Successfully");
                flag++;

                MySqlCommand command1 = new MySqlCommand("SELECT status from users where login = @ul", DataBase.Get_connection());
                command1.Parameters.Add("@ul", MySqlDbType.VarChar).Value = User_login;

                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == "admin")
                    {
                        flag++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Unsuccessfully");
            }

            if(flag == 1)
            {
                MainForm fm3 = new MainForm();
                this.Hide();
                fm3.Show();
            }
            if( flag == 2)
            {
                MainForm fm3 = new MainForm();
                fm3.data = flag;
                this.Hide();
                fm3.Show();
            }

            DataBase.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register fm2 = new Register();
            this.Hide();
            fm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.data2 = 3;
            this.Hide();
            MainForm.Show();
        }
    }
}