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
    public partial class MainForm : Form
    {
        string SelectedDBName;
        string ConnectionString;
        List<string> TablesNames;
        int page = 1;
        int p = 0;
        int page_count;
        public MainForm(string name, string connectionStringBase)
        {
            InitializeComponent();
            SelectedDBName = name;
            TablesNames = new List<string>();            
            ConnectionString = String.Format("{0}Database={1};", connectionStringBase, SelectedDBName);
            UpdateTableComboBox();
        }

        private void UpdateTableComboBox()
        {
            TableComboBox.Items.Clear();
            TablesNames.Clear();

            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                DataTable tables = con.GetSchema("Tables");

                foreach (DataRow row in tables.Rows)
                {
                    TablesNames.Add(row[2].ToString());
                }
                con.Close();
            }

            if (TablesNames.Count != 0)
            {
                foreach (string name in TablesNames)
                    TableComboBox.Items.Add(name);

                TableComboBox.SelectedIndex = 0;
            }
        }

        private int Page() 
        {
            string sql;
            string count_p;
            double count;
            DBProvider.OpenConnection(ConnectionString);
            if (TableComboBox.Text == "Производитель")
                sql = "SELECT COUNT(Наименование) FROM Производитель  WHERE Удален=0";
            else
                sql = "SELECT COUNT(Наименование) FROM Товар  WHERE Удален=0";
            DataTable dt = DBProvider.ExecuteQuery(sql);
            count_p = dt.Rows[0][0].ToString();
            count = Convert.ToDouble(count_p);
            if (count % 10 == 0)
                page_count = Convert.ToInt32(count / 10);
            else
            {
                count = Math.Floor(count/10);
                page_count = Convert.ToInt32(count);
                page_count++;
            }
            DBProvider.CloseConnection();
            return page_count;
        }
        private void TableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page();
            p = 0;
            page = 1;
            string sql;
            DBProvider.OpenConnection(ConnectionString);
            if (TableComboBox.Text == "Производитель")
            {
                sql = String.Format("SELECT Производитель.Идентификатор, Производитель.Наименование, Производитель.Адрес, Производитель.Телефон FROM Производитель WHERE Удален=0 ORDER BY Идентификатор LIMIT {0},10", p);
            }
            else
                sql = "SELECT Товар.Идентификатор, Товар.Наименование, Товар.Стоимость, Товар.Срок_годности, Производитель.Наименование AS Производитель FROM Товар, Производитель WHERE Товар.ИД_Производителя=Производитель.Идентификатор AND Товар.Удален=0 ORDER BY Товар.Идентификатор LIMIT 0,10";          
            DataGridView.DataSource = DBProvider.ExecuteQuery(sql);
            DataGridView.Columns[0].Visible = false;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;        
            DBProvider.CloseConnection();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            /*DBProvider.OpenConnection(ConnectionString);
            string sql = "DESCRIBE " + TableComboBox.Text;
            DataTable dt = DBProvider.ExecuteQuery(sql);
            DBProvider.CloseConnection();*/
            if (TableComboBox.Text == "Производитель")
            {
                if ((new AddPr(ConnectionString, TableComboBox.Text, SelectedDBName)).ShowDialog() == DialogResult.OK)
                {
                    TableComboBox_SelectedIndexChanged(this, new EventArgs());                        
                }
            }
            else
            {
                if ((new AddT(ConnectionString, TableComboBox.Text, SelectedDBName)).ShowDialog() == DialogResult.OK)
                {
                    TableComboBox_SelectedIndexChanged(this, new EventArgs());
                }
            }
        }      

        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            string pk;
            string pkval;

            try
            {
                pk = "Идентификатор";
                pkval = (string)DataGridView.SelectedRows[0].Cells[pk].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DBProvider.OpenConnection(ConnectionString);
            string sql = String.Format("UPDATE {0} SET `Удален`=1 where {1}={2}", TableComboBox.Text, pk, pkval);

            if (DBProvider.ExecuteNonQuery(sql))
                MessageBox.Show("Запрос успешно выполнен");           
            DBProvider.CloseConnection();
            TableComboBox_SelectedIndexChanged(this, new EventArgs());
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string pk;
            string pkval;

            try
            {
                pk = "Идентификатор";
                pkval = (string)DataGridView.SelectedRows[0].Cells[pk].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            /*DBProvider.OpenConnection(ConnectionString);
            string sql = "DESCRIBE " + TableComboBox.Text;
            DataTable dt = DBProvider.ExecuteQuery(sql);*/
            if (TableComboBox.Text == "Производитель")
            {
                if ((new UpdatePr(ConnectionString, TableComboBox.Text, SelectedDBName, pk, pkval)).ShowDialog() == DialogResult.OK)
                {
                    TableComboBox_SelectedIndexChanged(this, new EventArgs());
                }
            }
            else
            {
                if ((new UpdateT(ConnectionString, TableComboBox.Text, SelectedDBName, pk, pkval)).ShowDialog() == DialogResult.OK)
                {
                    TableComboBox_SelectedIndexChanged(this, new EventArgs());
                }
            }
         //   DBProvider.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page < page_count)
            {
                p += 10;
                page++;
                string sql;
                DBProvider.OpenConnection(ConnectionString);
                if (TableComboBox.Text == "Производитель")
                {
                    sql = String.Format("SELECT Производитель.Идентификатор, Производитель.Наименование, Производитель.Адрес, Производитель.Телефон FROM Производитель WHERE Удален=0 ORDER BY Идентификатор LIMIT {0},10", p);
                }
                else
                    sql = String.Format("SELECT Товар.Идентификатор, Товар.Наименование, Товар.Стоимость, Товар.Срок_годности, Производитель.Наименование AS Производитель FROM Товар, Производитель WHERE Товар.ИД_Производителя=Производитель.Идентификатор AND Товар.Удален=0 ORDER BY Товар.Идентификатор LIMIT {0},10", p);
                DataGridView.DataSource = DBProvider.ExecuteQuery(sql);
                DataGridView.Columns[0].Visible = false;
                DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DBProvider.CloseConnection();
            }
            else
                MessageBox.Show("Записей больше нет");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                p -= 10;
                page--;
                string sql;
                DBProvider.OpenConnection(ConnectionString);
                if (TableComboBox.Text == "Производитель")
                {
                    sql = String.Format("SELECT Производитель.Идентификатор, Производитель.Наименование, Производитель.Адрес, Производитель.Телефон FROM Производитель WHERE Удален=0 ORDER BY Идентификатор LIMIT {0},10", p);
                }
                else
                    sql = String.Format("SELECT Товар.Идентификатор, Товар.Наименование, Товар.Стоимость, Товар.Срок_годности, Производитель.Наименование AS Производитель FROM Товар, Производитель WHERE Товар.ИД_Производителя=Производитель.Идентификатор AND Товар.Удален=0 ORDER BY Товар.Идентификатор LIMIT {0},10", p);
                DataGridView.DataSource = DBProvider.ExecuteQuery(sql);
                DataGridView.Columns[0].Visible = false;
                DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DBProvider.CloseConnection();
            }
            else
                MessageBox.Show("Записей больше нет");
        }
    }
}
