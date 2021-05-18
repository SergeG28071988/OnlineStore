using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OnlineStore
{
    public partial class Form2 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Интернет-магазин.mdb"; // создали подключение к БД
        private OleDbConnection dbConnection; // дали подключению имя
        public Form2()
        {
            InitializeComponent();
            dbConnection = new OleDbConnection(connectString);
            dbConnection.Open(); // открываем соединение с БД

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Интернет_магазинDataSet.Игры". При необходимости она может быть перемещена или удалена.
            this.игрыTableAdapter.Fill(this._Интернет_магазинDataSet.Игры);

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConnection.Close(); // закрыли соединение
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // реализуем возможность удаления товаров

            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Игры WHERE [Код товара] =" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // реализуем возможность изменять данные. Изменение наименования

            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Игры SET Наименование ='" + textBox3.Text + "' WHERE [Код товара] =" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Игры SET Цена ='" + textBox4.Text + "' WHERE [Код товара] =" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Возврат к главному меню
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Обновление данных
            this.игрыTableAdapter.Fill(this._Интернет_магазинDataSet.Игры);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox5.Text);
            string name = textBox6.Text;
            string price = textBox7.Text;

            string query = "INSERT INTO Игры ([Код товара], Наименование, Цена ) VALUES (" + kod + ", '" + name + "', '" + price + "')";
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Данные о товарах добавлены");
        }
    }
}
