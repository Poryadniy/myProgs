using System;
using System.Drawing;
using System.Windows.Forms;
using static pet.Words;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace pet
{
    public partial class writtenQuestions : Form
    {
        private string[] en_words = new string[] {} ; 
        private string[] ru_words = new string[] {} ;
        private int _value = 0;
        public int val
        {
            get { return _value;}
            set { _value = value; }
        }
        public writtenQuestions()
        {
            InitializeComponent();
            en(ref en_words);
            ru(ref ru_words);
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

        private void writtenQuestions_Load(object sender, EventArgs e)
        {
            int dy = 0;
            
            for (int i = 0; i < _value; i++)
            {
                Label label = new Label();
                label.Location = new Point(25, 25+dy);
                label.Text = en_words[i];
                label.Name = "label" + i;
                this.Controls.Add(label);
                
                TextBox textBox = new TextBox();
                textBox.Location = new Point(125, 25+dy);
                textBox.Name = "textBox" + i;
                this.Controls.Add(textBox);
                
                dy += 40;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rights = 0;
            int wrongs = 0;
            for (int i = 0; i < _value; i++)
            {
                if (Array.IndexOf(en_words, this.Controls["label" + i].Text) ==
                    Array.IndexOf(ru_words, this.Controls["textBox" + i].Text))
                {
                    rights++;
                }

                else
                {
                    wrongs++;
                }
            }

            MessageBox.Show($"Right answers: {rights},   Wrong answers: {wrongs}");
        }
    }
}