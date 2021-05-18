using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OnlineStore
{
    public partial class Form5 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Интернет-магазин.mdb"; // создали подключение к БД
        private OleDbConnection dbConnection; // дали подключению имя
        public Form5()
        {
            InitializeComponent();
            dbConnection = new OleDbConnection(connectString);
            dbConnection.Open(); // открываем соединение с БД
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string date = textBox2.Text;           
            string name  = textBox3.Text;
            string profit = textBox4.Text;
            string query = "INSERT INTO Продажи ([Код ], Дата, Наименование, Прибыль ) VALUES (" + kod + ", '" + date + "', '" + name + "', '" + profit + "' )";
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Данные о продажах добавлены");
        }
    }
}
 