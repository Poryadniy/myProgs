using System;
using System.Windows.Forms;
using static pet.Words;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace pet
{
    public partial class Main : Form
    {
        private int flip_flag = 0;
        private int next_flag = 0;
        private int back_flag = 0;
        private string[] en_words = new string[] {} ; 
        private string[] ru_words = new string[] {} ;

        
        public Main()
        {
            InitializeComponent();
            en(ref en_words);
            ru(ref ru_words);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label1.Text = en_words[0];
            label2.Text = "1/" + en_words.Length;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (en_words.Contains(label1.Text))
            {
                back_flag = Array.IndexOf(en_words, label1.Text);
                if (back_flag - 1 >= 0)
                {
                    label1.Text = en_words[back_flag - 1];
                    next_flag--;
                }
                label2.Text = (next_flag+1) +"/"+ en_words.Length;
            }
            else
            {
                back_flag = Array.IndexOf(ru_words, label1.Text);
                if (back_flag - 1 >= 0)
                {
                    label1.Text = en_words[back_flag - 1];
                    next_flag--;
                }
            }
            
            if (next_flag == 0)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (next_flag + 1 < en_words.Length)
            {
                label1.Text = en_words[next_flag + 1];
                
                next_flag++;
            }
            label2.Text = (next_flag+1) +"/"+  en_words.Length;
            
            if (next_flag == en_words.Length-1)
            {
                button2.Enabled = false;
            }
        }
        private void en(ref string [] en_words)
        {
            string[] words = new string[] { };
            
            Database db = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string query = "SELECT en_word FROM words";
            MySqlCommand command = new MySqlCommand(query, db.get_connection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row  in table.Rows)
            {
                en_words = en_words.Append(row["en_word"].ToString()).ToArray();
            }
        }

        private void ru(ref string [] ru_words)
        {
            string[] words = new string[] { };
            
            Database db = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string query = "SELECT ru_word FROM words";
            MySqlCommand command = new MySqlCommand(query, db.get_connection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row  in table.Rows)
            {
                ru_words = ru_words.Append(row["ru_word"].ToString()).ToArray();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (ru_words.Contains(label1.Text))
            {
                int index = Array.IndexOf(ru_words, label1.Text);
                label1.Text = en_words[index];
            }
            else
            {
                int index = Array.IndexOf(en_words, label1.Text);
                label1.Text = ru_words[index];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
 
            for (int i = en_words.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
 
                string tmp = en_words[j];
                en_words[j] = en_words[i];
                en_words[i] = tmp;
                
                string tmp_1 = ru_words[j];
                ru_words[j] = ru_words[i];
                ru_words[i] = tmp_1;
            }
            
            label1.Text = en_words[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setTest setTest = new setTest();
            setTest.Show();
        }
    }
}