using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pet.Database;
using MySql.Data.MySqlClient;

namespace pet
{
    public partial class Form1 : Form
    {
        private Database _db = new Database();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string query = "SELECT * FROM users WHERE login = @ul and password = @up";
            MySqlCommand command = new MySqlCommand(query, _db.get_connection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = autho_log_tbox.Text;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = autho_pass_tbox.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Successful authorization");
            }
        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            Form _register = new Register();
            _register.Show();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}