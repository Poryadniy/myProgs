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
    public partial class MainForm : Form
    {
        DataBase DataBase = new DataBase();

        int flag = 0;
        int flag1 = 0;
        int flag2 = 0;
        int flag3 = 0;
        public int data
        {
            get { return flag1; }
            set { flag1 = value; }
        }

        public int data1
        {
            get { return flag2; }
            set { flag2 = value; }
        }

        public int data2
        {
            get { return flag3; }
            set { flag3 = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag3 == 3)
            {
                MessageBox.Show("To use this, you need to register");
                return;
            }

            AddAssets fm4 = new AddAssets();
            fm4.Data = comboBox1.SelectedItem.ToString();
            fm4.Data1 = comboBox1.SelectedItem.ToString();
            fm4.Data2 = 1;
            fm4.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag3 == 3)
            {
                MessageBox.Show("To use this, you need to register");
                return;
            }

            AddAssets fm4 = new AddAssets();
            fm4.Data = comboBox2.SelectedItem.ToString();
            fm4.Data1 = comboBox2.SelectedItem.ToString();
            fm4.Data2 = 2;
            fm4.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag3 == 3)
            {
                MessageBox.Show("To use this, you need to register");
                return;
            }

            AddAssets fm4 = new AddAssets();
            fm4.Data = comboBox3.SelectedItem.ToString();
            fm4.Data1 = comboBox3.SelectedItem.ToString();
            fm4.Data2 = 3;
            fm4.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int flag5 = 0;
            double flag6 = 0;
            if(flag % 2 == 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT SUM(count) FROM assets_in_briefcase", DataBase.Get_connection());

                DataBase.Open();

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    flag5 += Convert.ToInt32(reader[0].ToString());

                }
                DataBase.Close();
                
                MySqlCommand command4 = new MySqlCommand("SELECT SUM(price) FROM assets_in_briefcase", DataBase.Get_connection());

                DataBase.Open();

                MySqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    flag6 += Convert.ToDouble(reader4[0].ToString());

                }
                DataBase.Close();

                label5.Text = flag5.ToString();
                label10.Text = "$ "+(Math.Round(flag6,2)).ToString();

                flag++;
            }
            else
            {
                label5.Text = "*********";
                label10.Text = "*********";
                flag++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "*********";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null )
            {
                MessageBox.Show("Choose any asset");
                return;
            }
            DeleteAssets fm5 = new DeleteAssets();
            fm5.Data = listBox1.SelectedItem.ToString();
            fm5.Show();

            if(flag2 == 1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Choose any asset");
                return;
            }
            Form6 fm6 = new Form6();
            fm6.Data = listBox1.SelectedItem.ToString();
            fm6.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT name FROM assets WHERE type = 'stock'", DataBase.Get_connection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);

            }
            DataBase.Close();

            DataBase.Open();

            MySqlCommand command1 = new MySqlCommand("SELECT name FROM assets WHERE type = 'fund'", DataBase.Get_connection());
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0]);

            }
            DataBase.Close();

            DataBase.Open();

            MySqlCommand command2 = new MySqlCommand("SELECT name FROM assets WHERE type = 'metal'", DataBase.Get_connection());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox3.Items.Add(reader2[0]);

            }
            DataBase.Close();
            
            DataBase.Open();

            if (flag3 == 3)
            {
                Random random = new Random();
                MySqlCommand command3 = new MySqlCommand("SELECT name FROM assets", DataBase.Get_connection());
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    listBox2.Items.Add(reader3[0] + "\t\t\t" + random.Next(1, 11));

                }
                DataBase.Close();
            }
            else
            {
                MySqlCommand command3 = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID);", DataBase.Get_connection());
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    listBox2.Items.Add(reader3[0] + "\t\t\t" + reader3[1]);

                }
                DataBase.Close();
            }

            DataBase.Open();

            if (flag3 == 3)
            {
                MySqlCommand command4 = new MySqlCommand("SELECT name FROM assets", DataBase.Get_connection());
                MySqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    listBox1.Items.Add(reader4[0]);

                }
                DataBase.Close();
            }
            else
            {

                MySqlCommand command6 = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID);", DataBase.Get_connection());
                MySqlDataReader reader6 = command6.ExecuteReader();
                while (reader6.Read())
                {
                    listBox1.Items.Add(reader6[0]);

                }
                DataBase.Close();
            }

            if (flag1 != 2)
            {
                button2.Visible = false;
            }

            if (flag3 == 3)
            {
                button6.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AdminPanel fm8 = new AdminPanel();
            fm8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT assets.name as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID);", DataBase.Get_connection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0]);

            }
            DataBase.Close();

            DataBase.Open();

            MySqlCommand command2 = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID);", DataBase.Get_connection());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                listBox2.Items.Add(reader2[0] + "\t\t\t" + reader2[1]);

            }
            DataBase.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Graph Graph = new Graph();
            Graph.Show();        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string type = "";
            float cost = 0;

            MySqlCommand command = new MySqlCommand("SELECT type,price FROM assets WHERE name = @name ", DataBase.Get_connection());
            command.Parameters.Add("@name", MySqlDbType.String).Value = textBox1.Text;

            DataBase.Open();

            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                type = reader[0].ToString();
                cost = (float)reader[1];
            }

            DataBase.Close();

            MessageBox.Show($"Asset name: {textBox1.Text}\nAsset type: {type}\nAsset price: {cost} $");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID) ORDER BY name;", DataBase.Get_connection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox2.Items.Add(reader[0] + "\t\t\t" + reader[1]);

            }
            DataBase.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT assets.name,assets_in_briefcase.count as asset_name FROM assets INNER JOIN assets_in_briefcase ON (assets.ID = assets_in_briefcase.asset_ID)ORDER BY count DESC;", DataBase.Get_connection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox2.Items.Add(reader[0] + "\t\t\t" + reader[1]);

            }
            DataBase.Close();
        }
    }
}