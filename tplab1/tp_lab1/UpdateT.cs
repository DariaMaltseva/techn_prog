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
    public partial class UpdateT : Form
    {
        string ConnectionString;
        string tableName;
        string BDName;
        string pk;
        string pkval;
        List<string> param;
        public UpdateT(string connectionString, string tableName, string BDName, string pk, string pkval)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.BDName = BDName;
            this.pk = pk;
            this.pkval = pkval;
            ConnectionString = connectionString;
            UpdateTextBox();
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
            string a = "" + comboBox1.SelectedValue + "";
            param.Add(a);
            string b = "" + pkval + "";
            param.Add(b);
            DBProvider.UpdateT(param);
            DialogResult = DialogResult.OK;
           /* DBProvider.OpenConnection(ConnectionString);
            string sql = String.Format("UPDATE `Товар` SET `Наименование`='{0}', `Стоимость`='{1}', `Срок_годности`='{2}', `ИД_Производителя`='{3}' where `Идентификатор`='{4}'", textBox1.Text, textBox2.Text, textBox4.Text, comboBox1.SelectedValue, pkval);
            if (DBProvider.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Запрос успешно выполнен");
                DBProvider.CloseConnection();
                DialogResult = DialogResult.OK;
            }
            DBProvider.CloseConnection();*/
        }
        private void UpdateTextBox()
        {
            DBProvider.OpenConnection(ConnectionString);
            string sql = String.Format("Select Наименование, Стоимость, Срок_годности FROM Товар Where {0}={1}", pk, pkval);
            DataTable dt = DBProvider.ExecuteQuery(sql);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox4.Text = dt.Rows[0][2].ToString();
            DBProvider.CloseConnection();
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
