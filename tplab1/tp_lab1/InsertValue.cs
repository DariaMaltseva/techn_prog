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
    public partial class InsertValue : Form
    {
        string ConnectionString;
        List<InsertValueItem> listItems;
        List<string> colsNames;
        List<string> values;
        string tableName;
        string BDName;
        //DataTable data;
        int margin = 30;

        public InsertValue(DataTable dt, string connectionString, string tableName, string BDName)
        {
            InitializeComponent();
            listItems = new List<InsertValueItem>();
            colsNames = new List<string>();
            values = new List<string>();
            this.tableName = tableName;
            this.BDName = BDName;
            ConnectionString = connectionString;
            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                if (i != 0)
                {
                InsertValueItem item = new InsertValueItem();
                item.TableName = dt.Rows[i][0].ToString();
                colsNames.Add(dt.Rows[i][0].ToString());
                item.TypeSize = dt.Rows[i][1].ToString();
                
                    item.Location = new Point(12, 35 + margin * (i-1));
                    listItems.Add(item);
                }
            }
            Controls.AddRange(listItems.ToArray());
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listItems.Count; i++)
            {
                values.Add(listItems[i].InsertValue);
            }

            string sql = String.Format("INSERT INTO `{0}`(`{1}`) VALUES ('{2}')", tableName, String.Join("`,`", colsNames.ToArray()), String.Join("','", values.ToArray()));

            DBProvider.OpenConnection(ConnectionString);
            if (DBProvider.ExecuteNonQuery(sql))
            {
                //MessageBox.Show("Запрос успешно выполнен");
                DBProvider.CloseConnection();
                DialogResult = DialogResult.OK;
            }
            DBProvider.CloseConnection();
        }
    }
}
