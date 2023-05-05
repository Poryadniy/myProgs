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
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace DB
{
    public partial class Graph : Form
    {
        DataBase DataBase = new DataBase();
        public Graph()
        {
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            DataBase.Open();

            MySqlCommand command = new MySqlCommand("SELECT date_change FROM history", DataBase.Get_connection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);

            }
            DataBase.Close();

            DataBase.Open();

            MySqlCommand command1 = new MySqlCommand("SELECT date_change FROM history", DataBase.Get_connection());
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0]);

            }
            DataBase.Close();

            ChartValues<int> price = new ChartValues<int>();
            
            List<string> name = new List<string>();

            DataBase.Open();

            MySqlCommand command3 = new MySqlCommand("SELECT date_change, cost  FROM history", DataBase.Get_connection());

            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                name.Add(reader3[0].ToString());
                price.Add(Convert.ToInt32(reader3[1]));
            }

  
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = price,
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(107,185,79)),
                Fill = Brushes.Transparent,
                LineSmoothness = 0,
                PointGeometrySize = 15,
                PointForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(34,22,27))
            }
                );

            cartesianChart1.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(55, 32, 49));
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = name,
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection(2),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64,79,86)),

                }
            }
                );

            cartesianChart1.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(4),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),

                }
            }
                );

            DataBase.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.Series.Clear();


            DataBase.Open();

            ChartValues<int> price = new ChartValues<int>();

            List<string> name = new List<string>();

            DataBase.Open();

            MySqlCommand command3 = new MySqlCommand("SELECT date_change, cost FROM history WHERE date_change >= @first_date AND date_change <= @second_date ", DataBase.Get_connection());
            command3.Parameters.Add("@first_date", MySqlDbType.DateTime).Value = comboBox1.SelectedItem;
            command3.Parameters.Add("@second_date", MySqlDbType.DateTime).Value = comboBox2.SelectedItem;

            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                name.Add(reader3[0].ToString());
                price.Add(Convert.ToInt32(reader3[1]));
            }


            cartesianChart1.Series.Add(new LineSeries
            {
                Values = price,
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 79)),
                Fill = Brushes.Transparent,
                LineSmoothness = 0,
                PointGeometrySize = 15,
                PointForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 22, 27))
            }
                );

            cartesianChart1.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(55, 32, 49));
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = name,
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection(2),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),

                }
            }
                );

            cartesianChart1.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(4),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),

                }
            }
                );

            DataBase.Close();
        }
    }
}