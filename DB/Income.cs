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
    public partial class Income : Form
    {
        DataBase DataBase = new DataBase();

        public Income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int exists = 0;
            int count = 0;
            DateTime first_date;
            DateTime second_date;
            DateTime From = DateTime.Parse(textBox1.Text);
            DateTime To = DateTime.Parse(textBox2.Text);

            MySqlCommand command = new MySqlCommand("SELECT MIN(date_change) FROM history", DataBase.Get_connection());
            MySqlCommand command1 = new MySqlCommand("SELECT MAX(date_change) FROM history", DataBase.Get_connection());
            MySqlCommand command5 = new MySqlCommand("SELECT COUNT(*) FROM history", DataBase.Get_connection());

            DataBase.Open();

            first_date = Convert.ToDateTime(command.ExecuteScalar().ToString());
            second_date = Convert.ToDateTime(command1.ExecuteScalar().ToString());
            count = Convert.ToInt32(command5.ExecuteScalar());


            if(From < first_date)
            {
                From = first_date;
            }

            if (To > second_date)
            {
                To = second_date;
            }

            for (int i = 0; i < count; i++)
            {
                MySqlCommand command2 = new MySqlCommand("SELECT EXISTS(SELECT id FROM history WHERE date_change = @date)", DataBase.Get_connection());
                command2.Parameters.Add("@date", MySqlDbType.Date).Value = From;

                exists = Convert.ToInt32(command2.ExecuteScalar());

                if (exists == 0)
                {
                    From = From + new TimeSpan(-24, 0, 0);
                }

                else
                {
                    break;
                }
            }


            for (int i = 0; i < count; i++)
            {
                MySqlCommand command3 = new MySqlCommand("SELECT EXISTS(SELECT id FROM history WHERE date_change = @date)", DataBase.Get_connection());
                command3.Parameters.Add("@date", MySqlDbType.Date).Value = To;

                exists = Convert.ToInt32(command3.ExecuteScalar());

                if (exists == 0)
                {
                    To = To + new TimeSpan(-24, 0, 0);
                }

                else
                {
                    break;
                }
            }


            MySqlCommand command4 = new MySqlCommand("income", DataBase.Get_connection());
            command4.CommandType = CommandType.StoredProcedure;
            MySqlParameter parameter = new MySqlParameter();

            command4.Parameters.AddWithValue("f", From);
            command4.Parameters.AddWithValue("t", To);
            //command.Parameters.AddWithValue("income", income);

            DataBase.Open();
            float income = (float)command4.ExecuteScalar();
            DataBase.Close();

            label4.Text = $"{income.ToString()} $";
        }
    }
}
