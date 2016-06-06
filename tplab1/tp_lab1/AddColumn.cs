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
    public partial class AddColumn : Form
    {
        string ConnectionString;
        string tableName;
        AddColumnItem item;

        public AddColumn(string connectionString, string tableName)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            this.tableName = tableName;
            item = new AddColumnItem();
            item.Location = new Point(12, 48);
            Controls.Add(item);
        }

        private void AddColButton_Click(object sender, EventArgs e)
        {
            string sql = String.Format("ALTER TABLE `{0}` ADD COLUMN {1}", tableName, item.ToString());
            DBProvider.OpenConnection(ConnectionString);
            if (DBProvider.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Запрос успешно выполнен");
                DBProvider.CloseConnection();
                DialogResult = DialogResult.OK;
            }
            DBProvider.CloseConnection();
        }
    }
}
