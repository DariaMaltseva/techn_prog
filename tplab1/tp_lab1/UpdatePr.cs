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
    public partial class UpdatePr : Form
    {
        string ConnectionString;
        string tableName;
        string BDName;
        string pk;
        string pkval;
        List<string> param;
        public UpdatePr(string connectionString, string tableName, string BDName, string pk, string pkval)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.BDName = BDName;
            this.pk = pk;
            this.pkval = pkval;
            ConnectionString = connectionString;
            UpdateTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name, Address, Phone;
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Name = textBox1.Text;
                Address = textBox2.Text;
                Phone = textBox3.Text;
                if (Name.Length > 100)
                {
                    MessageBox.Show("Слишком длинное наименование", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Address.Length > 250)
                {
                    MessageBox.Show("Слишком длинный адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Phone.Length > 20)
                {
                    MessageBox.Show("Слишком длинный номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            param.Add(textBox3.Text);
            param.Add(pkval);
            DBProvider.UpdatePr(param);
            DialogResult = DialogResult.OK;
            /*DBProvider.OpenConnection(ConnectionString);
            string sql = String.Format("UPDATE `Производитель` SET `Наименование`='{0}', `Адрес`='{1}', `Телефон`='{2}' where `{3}`='{4}'", textBox1.Text, textBox2.Text, textBox3.Text, pk, pkval);
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
            string sql = String.Format("Select Наименование, Адрес, Телефон FROM Производитель Where {0}={1}", pk, pkval);
            DataTable dt = DBProvider.ExecuteQuery(sql);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            DBProvider.CloseConnection();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;
            if (Convert.ToString(e.KeyChar) == "-") return;
            if (Convert.ToString(e.KeyChar) == "+") return;
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }
    }
}
