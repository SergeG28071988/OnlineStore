using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OnlineStore
{
    public partial class Form3 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Интернет-магазин.mdb"; // создали подключение к БД
        private OleDbConnection dbConnection; // дали подключению имя
        public Form3()
        {
            InitializeComponent();
            dbConnection = new OleDbConnection(connectString);
            dbConnection.Open(); // открываем соединение с БД
        }

        private void Form3_Load(object sender, EventArgs e)
        {            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Интернет_магазинDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this._Интернет_магазинDataSet.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Интернет_магазинDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this._Интернет_магазинDataSet.Клиенты);

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConnection.Close(); // закрыли соединение
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Добавление данных в БД
            int kod = Convert.ToInt32(textBox6.Text);
            string surname = textBox7.Text;          
            string name = textBox8.Text;
            string patronymic = textBox12.Text;
            string address = textBox9.Text;
            string phone = textBox10.Text;


            string query = "INSERT INTO Клиенты ([Код клиента], Фамилия, Имя, Адрес, Телефон ) VALUES (" + kod + ", '" + surname + "',  '" + name + "', '" + patronymic + "',  '" + address + "', '" + phone + "')";
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Fill(this._Интернет_магазинDataSet.Клиенты);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Добавление данных в БД
            int kod = Convert.ToInt32(textBox1.Text);
            int kod_2 = Convert.ToInt32(textBox2.Text);
            string name  = textBox3.Text;
            string price = textBox4.Text;
            string count = textBox5.Text;
            string profit = textBox11.Text;

            string query = "INSERT INTO Заказы ([Код клиента], [Код заказа], Наименование, Цена, Количество, Сумма) VALUES (" + kod + ", " + kod_2 + ", '" + name + "',  '" + price + "', '" + count + "', '" + profit + "')";
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.заказыTableAdapter.Fill(this._Интернет_магазинDataSet.Заказы);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                double price;
                double count;

                price = Convert.ToDouble(textBox4.Text);
                count = Convert.ToDouble(textBox5.Text);

                switch (comboBox1.Text)
                {
                    case "*":

                        textBox11.Text = Convert.ToString(price * count);
                        break;
                }
            }
        }
    }
}
