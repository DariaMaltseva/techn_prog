using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_lab1
{
    public partial class AddColumnItem : UserControl
    {
        public AddColumnItem()
        {
            InitializeComponent();
        }

        //public bool IsEnabledPrimaryKey { set { PrimaryKeyCheckBox.Enabled = value; } }

        public override string ToString()
        {
            string isNull = NullCheckBox.Checked ? "NULL": "NOT NULL";
            string isAI = AICheckBox.Checked ? " AUTO_INCREMENT": String.Empty;
            string isPK = PrimaryKeyCheckBox.Checked ? " PRIMARY KEY" : String.Empty;
            return String.Format("`{0}` {1}({2}) {3}{4}{5}", NameTextBox.Text, TypeComboBox.Text, LengthTextBox.Text, isNull, isAI, isPK);
        }
    }
}
