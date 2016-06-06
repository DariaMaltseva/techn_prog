using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_lab1
{
    public partial class AddT : Form
    {
        string ConnectionString;
        string tableName;
        string BDName;
        List<string> TNames;
        List<string> param;
        public AddT(string connectionString, string tableName, string BDName)
        {
            InitializeComponent();            
            this.tableName = tableName;
            this.BDName = BDName;
            TNames = new List<string>();  
            ConnectionString = connectionString;
            UpdateComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name;
            int Cost, Shelf_life;
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Name = textBox1.Text;
                Cost = Convert.ToInt32(textBox2.Text);
                Shelf_life = Convert.ToInt32(textBox4.Text);
                if (Cost > 10000)
                {
                    MessageBox.Show("Неверно введена стоимость", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Shelf_life > 1000)
                {
                    MessageBox.Show("Неверно введен срок годности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Name.Length > 100)
                {
                    MessageBox.Show("Слишком длинное наименование", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка формата ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            param = new List<string>();
            param.Add(textBox1.Text);
            param.Add(textBox2.Text);
            param.Add(textBox4.Text);
            string a = ""+comboBox1.SelectedValue+"";
            param.Add(a);
            DBProvider.InsertT(param);
            DialogResult = DialogResult.OK;
            //string sql = String.Format("INSERT INTO `Товар`(`Идентификатор`, `Наименование`, `Стоимость`, `Срок_годности`, `ИД_Производителя`, `Удален`) VALUES ('','{0}','{1}','{2}','{3}','0')", textBox1.Text, textBox2.Text, /*textBox3.Text,*/ textBox4.Text, comboBox1.SelectedValue);            
           /* DBProvider.OpenConnection(ConnectionString);
            if (DBProvider.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Запрос успешно выполнен");
                DBProvider.CloseConnection();                
            }*/            
        }

        private void UpdateComboBox()
        {
            comboBox1.Items.Clear();
            DBProvider.OpenConnection(ConnectionString);
            string sql = "Select Идентификатор, Наименование FROM Производитель Where Удален=0";
            comboBox1.DataSource = DBProvider.ExecuteQuery(sql);
            comboBox1.DisplayMember = "Наименование";
            comboBox1.ValueMember = "Идентификатор";
            DBProvider.CloseConnection();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }
    }
}
