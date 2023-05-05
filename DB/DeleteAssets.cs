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
    public partial class DeleteAssets : Form
    {
        DataBase DataBase = new DataBase();

        string name_to_delete;
        public string Data
        {
            get { return name_to_delete; }
            set { name_to_delete = value; }
        }
        
        public DeleteAssets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int asset_ID = 0;
            int asset_count = 0;
            double price = 0;

            MySqlCommand command = new MySqlCommand("SELECT ID FROM assets WHERE name = @name;", DataBase.Get_connection());
            command.Parameters.Add("@name", MySqlDbType.String).Value = name_to_delete;

            DataBase.Open();

            asset_ID = Convert.ToInt32(command.ExecuteScalar());

            MySqlCommand command1 = new MySqlCommand("SELECT count FROM assets_in_briefcase WHERE asset_ID = @ID ;", DataBase.Get_connection());
            command1.Parameters.Add("@ID", MySqlDbType.String).Value = asset_ID;

            asset_count = Convert.ToInt32(command1.ExecuteScalar());

            MySqlCommand command2 = new MySqlCommand("SELECT price FROM assets WHERE ID = @ID ;", DataBase.Get_connection());
            command2.Parameters.Add("@ID", MySqlDbType.String).Value = asset_ID;
            price = Convert.ToDouble(command2.ExecuteScalar());

            DataBase.Close();

            if (asset_count >= 1)
            {
                asset_count--;
                MySqlCommand command3 = new MySqlCommand("UPDATE assets_in_briefcase SET count = @count, price = @price WHERE asset_ID = @ID", DataBase.Get_connection());

                command3.Parameters.Add("@count", MySqlDbType.Int32).Value = asset_count;
                command3.Parameters.Add("@ID", MySqlDbType.Int32).Value = asset_ID;
                command3.Parameters.Add("@price", MySqlDbType.Double).Value = price * asset_count;

                DataBase.Open();

                command3.ExecuteNonQuery();

                DataBase.Close();
            }

            if(asset_count == 0)
            {
                MySqlCommand command4 = new MySqlCommand("DELETE FROM assets_in_briefcase WHERE asset_ID = @ID", DataBase.Get_connection());
                command4.Parameters.Add("@ID", MySqlDbType.Int32).Value = asset_ID;

                DataBase.Open();

                command2.ExecuteNonQuery();

                DataBase.Close();

                MainForm mf = new MainForm();
                mf.data1 = 1;

                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int asset_ID = 0;


            MySqlCommand command = new MySqlCommand("SELECT ID FROM assets WHERE name = @name;", DataBase.Get_connection());
            command.Parameters.Add("@name", MySqlDbType.String).Value = name_to_delete;

            DataBase.Open();

            asset_ID = Convert.ToInt32(command.ExecuteScalar());


            MySqlCommand command1 = new MySqlCommand("DELETE FROM assets_in_briefcase WHERE asset_ID = @ID", DataBase.Get_connection());
            command1.Parameters.Add("@ID", MySqlDbType.VarChar).Value = asset_ID;

            command1.ExecuteNonQuery();

            DataBase.Close();

            Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
