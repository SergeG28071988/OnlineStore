using System;
using System.Windows.Forms;
using System.Data.OleDb;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;

namespace OnlineStore
{
    public partial class Form4 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Интернет-магазин.mdb"; // создали подключение к БД
        private OleDbConnection dbConnection; // дали подключению имя
        public Form4()
        {
            InitializeComponent();
            dbConnection = new OleDbConnection(connectString);
            dbConnection.Open(); // открываем соединение с БД
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Интернет_магазинDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this._Интернет_магазинDataSet.Продажи);
            cartesianChart1.LegendLocation = LegendLocation.Bottom;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.продажиTableAdapter.Fill(this._Интернет_магазинDataSet.Продажи);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            ChartValues<int> directValues = new ChartValues<int>();

            List<string> dates = new List<string>();

            foreach (var directRow in _Интернет_магазинDataSet.Продажи)
            {
                directValues.Add(directRow.Прибыль);

                dates.Add(directRow.Дата.ToShortDateString());
            }
            cartesianChart1.AxisX.Clear();

            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });

            LineSeries directLine = new LineSeries
            {
                Title = "Продажи",

                Values = directValues
            };

            series.Add(directLine);

            cartesianChart1.Series = series;
        }
    }
}

