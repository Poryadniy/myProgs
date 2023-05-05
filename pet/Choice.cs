using System.Windows.Forms;
using System;
using System.Drawing;
using static pet.Words;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace pet
{
    public partial class Choice : Form
    {
        private string[] en_words = new string[] {} ; 
        private string[] ru_words = new string[] {} ;
        private int _value = 0;

        public int val
        {
            get { return _value;}
            set { _value = value; }
        }
        
        public Choice()
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

        private void Choice_Load(object sender, EventArgs e)
        {
            int label_dy = 0;
            int radioButton_dy = 25;
            int radioButton_dx = 150;
            Random rand = new Random();
            
            for (int i = 0; i < _value; i++)
            {
                string[] str = en_words.OrderBy(x => rand.Next()).ToArray();
 
                Array.Resize( ref str, 4);
                
                Label label = new Label();
                label.Location = new Point(25, 25+label_dy);
                label.Text = en_words[i];
                this.Controls.Add(label);

                RadioButton radioButton1 = new RadioButton();
                radioButton1.Location = new Point(25, label.Location.Y + radioButton_dy);
                radioButton1.Text = str[0];
                this.Controls.Add(radioButton1);
                
                RadioButton radioButton2 = new RadioButton();
                radioButton2.Location = new Point(25+radioButton_dx, label.Location.Y + radioButton_dy);
                radioButton2.Text = str[1];
                this.Controls.Add(radioButton2);
                
                RadioButton radioButton3 = new RadioButton();
                radioButton3.Location = new Point(25, label.Location.Y + radioButton_dy + 2*radioButton_dy);
                radioButton3.Text = str[2];
                this.Controls.Add(radioButton3);
                
                RadioButton radioButton4 = new RadioButton();
                radioButton4.Location = new Point(25+radioButton_dx, label.Location.Y + radioButton_dy + 2*radioButton_dy);
                radioButton4.Text = str[3];
                this.Controls.Add(radioButton4);

                label_dy += 100;
            }
        }
    }
}