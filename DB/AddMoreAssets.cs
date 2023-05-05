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
    public partial class Form6 : Form
    {
        DataBase DataBase = new DataBase();

        string name_to_enlarge;
        public string Data
        {
        
            get {return name_to_enlarge; }
            set { name_to_enlarge = value; }
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int asset_ID = 0;
            int asset_count = 0;
            double price = 0;

            MySqlCommand command = new MySqlCommand("SELECT ID FROM assets WHERE name = @name;", DataBase.Get_connection());
            command.Parameters.Add("@name", MySqlDbType.String).Value = name_to_enlarge;

            DataBase.Open();

            asset_ID = Convert.ToInt32(command.ExecuteScalar());


            MySqlCommand command1 = new MySqlCommand("SELECT count FROM assets_in_briefcase WHERE asset_ID = @ID ;", DataBase.Get_connection());
            command1.Parameters.Add("@ID", MySqlDbType.String).Value = asset_ID;

            asset_count = Convert.ToInt32(command1.ExecuteScalar());

            MySqlCommand command2 = new MySqlCommand("SELECT price FROM assets WHERE ID = @ID ;", DataBase.Get_connection());
            command2.Parameters.Add("@ID", MySqlDbType.String).Value = asset_ID;
            price = Convert.ToDouble(command2.ExecuteScalar());

            //MySqlCommand command = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID) WHERE asset_ID = @ID", DataBase.Get_connection());
            //command.Parameters.Add("@ID", MySqlDbType.Int32).Value = name_to_enlarge;

            //DataBase.Open();

            //MySqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    name_to_enlarge = Convert.ToInt32(reader[1]);
            //}

            MySqlCommand command3 = new MySqlCommand("UPDATE assets_in_briefcase SET count = @count, price = @price WHERE asset_ID = @ID", DataBase.Get_connection());
 
            command3.Parameters.Add("@count", MySqlDbType.Int32).Value = asset_count + Convert.ToInt32(textBox1.Text);
            command3.Parameters.Add("@ID", MySqlDbType.Int32).Value = asset_ID;
            command3.Parameters.Add("@price", MySqlDbType.Double).Value = price * (asset_count + Convert.ToInt32(textBox1.Text));

            command3.ExecuteNonQuery();

            DataBase.Close();

            this.Hide();
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
