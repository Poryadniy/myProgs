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
    public partial class AddAssets : Form
    {
        DataBase DataBase = new DataBase();
        string asset_name = "";
        int flag = 0;

        public string Data 
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        public string Data1
        {
            get { return asset_name; }
            set { asset_name = value; }
        }

        public int Data2
        {
            get { return flag; }
            set { flag = value; }
        }

        public AddAssets()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int ID = 0;
                float price = 0;

                DataBase.Open();
                MySqlCommand command1 = new MySqlCommand($"SELECT ID,price FROM assets WHERE name = @name ", DataBase.Get_connection());
                command1.Parameters.Add("@name", MySqlDbType.String).Value = asset_name;


                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ID = (int)reader1[0];
                    price = (float)reader1[1];

                }

                DataBase.Close();

                MySqlCommand command = new MySqlCommand("INSERT INTO assets_in_briefcase(asset_ID,count,price)VALUES(@ID,@count,@price)", DataBase.Get_connection());

                DataBase.Open();

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                command.Parameters.Add("@count", MySqlDbType.Int32).Value = textBox1.Text;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = (float)(price * Convert.ToDouble(textBox1.Text));

                command.ExecuteNonQuery();

                DataBase.Close();

                Hide();
            }

            if(flag == 2)
            {
                int ID = 0;
                float price = 0;

                DataBase.Open();
                MySqlCommand command1 = new MySqlCommand($"SELECT ID,price FROM assets WHERE name = @name ", DataBase.Get_connection());
                command1.Parameters.Add("@name", MySqlDbType.String).Value = asset_name;


                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ID = (int)reader1[0];
                    price = (float)reader1[1];

                }

                DataBase.Close();

                MySqlCommand command = new MySqlCommand("INSERT INTO assets_in_briefcase(asset_ID,count,price)VALUES(@ID,@count,@price)", DataBase.Get_connection());

                DataBase.Open();

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                command.Parameters.Add("@count", MySqlDbType.Int32).Value = textBox1.Text;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = (float)(price * Convert.ToDouble(textBox1.Text));

                command.ExecuteNonQuery();

                DataBase.Close();

                Hide();
            }

            if(flag == 3)
            {
                int ID = 0;
                float price = 0;

                DataBase.Open();
                MySqlCommand command1 = new MySqlCommand($"SELECT ID,price FROM assets WHERE name = @name ", DataBase.Get_connection());
                command1.Parameters.Add("@name", MySqlDbType.String).Value = asset_name;


                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ID = (int)reader1[0];
                    price = (float)reader1[1];

                }

                DataBase.Close();

                MySqlCommand command = new MySqlCommand("INSERT INTO assets_in_briefcase(asset_ID,count,price)VALUES(@ID,@count,@price)", DataBase.Get_connection());

                DataBase.Open();

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = ID;
                command.Parameters.Add("@count", MySqlDbType.Int32).Value = textBox1.Text;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = (float)(price * Convert.ToDouble(textBox1.Text));

                command.ExecuteNonQuery();

                DataBase.Close();

                Hide();
            }
        }
    }
}
