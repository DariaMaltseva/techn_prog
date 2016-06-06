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
    public partial class InsertValueItem : UserControl
    {
        public InsertValueItem()
        {
            InitializeComponent();
        }

        public string TableName { set { ColNameLabel.Text = value; } }

        public string TypeSize { set { TypeSizeLabel.Text = value; } }

        public string InsertValue { get { return ValueTextBox.Text; } }
    }
}
