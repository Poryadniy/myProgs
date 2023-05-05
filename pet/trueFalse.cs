using System;
using System.Drawing;
using System.Windows.Forms;
using static pet.Words;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace pet
{
    public partial class trueFalse : Form
    {
        private string[] en_words = new string[] {} ; 
        private string[] ru_words = new string[] {} ;
        private int _value = 0;
        public int val
        {
            get { return _value;}
            set { _value = value; }
        }
        
        public trueFalse()
        {
            Words words = new Words();
            InitializeComponent();
            en(ref en_words);
            ru(ref ru_words);
        }

        private void Test_Load(object sender, EventArgs e)
        {
            int dy = 0;
            
            Random rand = new Random();
 
            for (int i = ru_words.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                
                string tmp_1 = ru_words[j];
                ru_words[j] = ru_words[i];
                ru_words[i] = tmp_1;
            }
            
            for (int i = en_words.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                
                string tmp = en_words[j];
                en_words[j] = en_words[i];
                en_words[i] = tmp;
                
            }
            
            for (int i = 0; i < _value; i++)
            {
                Label label = new Label();
                label.Location = new Point(25, 25+dy);
                label.Text = en_words[i];
                label.Name = "label" + i;
                this.Controls.Add(label);
                
                Label label1 = new Label();
                label1.Location = new Point(150, 25+dy);
                label1.Text = ru_words[i];
                label1.Name = "label1" + i;
                this.Controls.Add(label1);

                CheckBox checkBox = new CheckBox();
                checkBox.Location = new Point(300, 25+dy);
                checkBox.Text = "True";
                checkBox.Name = "checkBox" + i;
                this.Controls.Add(checkBox);
                

                CheckBox checkBox1 = new CheckBox();
                checkBox1.Location = new Point(425, 25+dy);
                checkBox1.Text = "False";
                checkBox1.Name = "checkBox1" + i;
                this.Controls.Add(checkBox1);
                
                dy += 25;
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

        void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] en_words_ = new string[] {} ; 
            string[] ru_words_ = new string[] {} ;
            
            en(ref en_words_);
            ru(ref ru_words_);
            int right = 0;
            int wrong = 0;

            for (int i = 0; i < _value; i++)
            {
                if (Array.IndexOf(en_words_, this.Controls["label" + i].Text) ==
                    Array.IndexOf(ru_words_, this.Controls["label1" + i].Text))
                {
                    if ((this.Controls["checkBox" + i.ToString()] as CheckBox).Checked == true )
                    {
                       right++;;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                else
                {
                    if ((this.Controls["checkBox1" + i.ToString()] as CheckBox).Checked == true )
                    {
                        right++;;
                    }
                    else
                    {
                        wrong++;
                    }
                }
            }

            MessageBox.Show($"Right answers : {right} " +
                            $"Wrong Answers: {wrong}");

        }
    }
}