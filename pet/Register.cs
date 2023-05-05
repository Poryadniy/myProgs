using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static pet.Database;

namespace pet
{
    public partial class Register : Form
    {
        Database _db = new Database();

        public Register()
        {
            InitializeComponent();
        }

        private void Reg_button_Click(object sender, EventArgs e)
        {
            if (Reg_login_tbox.Text == "" || Reg_password_tbox.Text == "" || Reg_country_tbox.Text == "")
            {
                MessageBox.Show("Enter the correct data, please");
                return;
            }
            
            
            if (isUserExists())
            {
                return;
            }
            
            string query = "INSERT users (login, password, country) VALUES(@ul,@up,@uc)";
            
            _db.open();

            MySqlCommand _com = new MySqlCommand(query, _db.get_connection());
            _com.Parameters.Add("@ul", MySqlDbType.VarChar).Value = Reg_login_tbox.Text;
            _com.Parameters.Add("@up", MySqlDbType.VarChar).Value = Reg_password_tbox.Text;
            _com.Parameters.Add("@uc", MySqlDbType.VarChar).Value = Reg_country_tbox.Text;

            if (_com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Your account has been successfuly created");
            }
            else
            {
                MessageBox.Show("Your account hasn't been created, try again, please");
            }

            _db.close();

            Form1 frm1 = new Form1();
            
            frm1.Show();
            this.Hide();
        }

        private Boolean isUserExists()
        {
            DataTable _table = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            string query = "SELECT * FROM users WHERE login = @ul";
            MySqlCommand _command = new MySqlCommand(query,_db.get_connection());
            _command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = Reg_login_tbox.Text;
            _adapter.SelectCommand = _command;
            _adapter.Fill(_table);

            if (_table.Rows.Count > 0)
            {
                MessageBox.Show("This login already uses, enter a new login, please");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Pass_gen_button_Click(object sender, EventArgs e)
        {
            string symbols = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890!@#$%^&*()_+-=[];',./";
            string res = "";

            Random _rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                res += symbols[_rnd.Next(symbols.Length - 1)];
            }

            Reg_password_tbox.Text = res;
        }
    }
}