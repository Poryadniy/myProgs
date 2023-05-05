using System;
using System.Windows.Forms;

namespace pet
{
    public partial class setTest : Form
    {
        public setTest()
        {
            InitializeComponent();
        }

        private void setTest_Load(object sender, EventArgs e)
        {
            string[] languages = new string[] {"English","Russian","Both" };
            comboBox1.Items.AddRange(languages);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                trueFalse trueFalse = new trueFalse();
                trueFalse.val = Convert.ToInt32(textBox1.Text);
                trueFalse.Show();
            }
            
            if (radioButton2.Checked == true)
            {
                Choice choice = new Choice();
                choice.val = Convert.ToInt32(textBox1.Text);
                choice.Show();
            }
            
            if (radioButton3.Checked == true)
            {
                Selection selection = new Selection();
                selection.val = Convert.ToInt32(textBox1.Text);
                selection.Show();
            }
            
            if (radioButton4.Checked == true)
            {
                writtenQuestions writtenQuestions = new writtenQuestions();
                writtenQuestions.val = Convert.ToInt32(textBox1.Text);
                writtenQuestions.Show();
            }
        }
    }
}