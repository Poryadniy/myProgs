using System.Windows.Forms;
using System;
using System.Drawing;
using static pet.Words;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace pet
{
    public partial class Selection : Form
    {
        private string[] en_words = new string[] {} ; 
        private string[] ru_words = new string[] {} ;
        private int _value = 0;

        public int val
        {
            get { return _value;}
            set { _value = value; }
        }
        public Selection()
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

        private void Selection_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            
            int dy = 0;
            string[] str = ru_words.OrderBy(x => rand.Next()).ToArray();
            
            
            for (int i = 0; i < _value; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Location = new Point(25, 25+dy);
                this.Controls.Add(textBox);

                Label label = new Label();
                label.Location = new Point(125, 25+dy);
                label.Text = en_words[i];
                this.Controls.Add(label);
                
                Label label1 = new Label();
                label1.Location = new Point(400, 25+dy);
                label1.Text = (i+1) + ") " + str[i];
                this.Controls.Add(label1);

                dy += 40;
            }
        }
    }
}