namespace tp_lab1
{
    partial class InsertValueItem
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColNameLabel = new System.Windows.Forms.Label();
            this.TypeSizeLabel = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ColNameLabel
            // 
            this.ColNameLabel.AutoSize = true;
            this.ColNameLabel.Location = new System.Drawing.Point(13, 8);
            this.ColNameLabel.Name = "ColNameLabel";
            this.ColNameLabel.Size = new System.Drawing.Size(35, 13);
            this.ColNameLabel.TabIndex = 0;
            this.ColNameLabel.Text = "label1";
            // 
            // TypeSizeLabel
            // 
            this.TypeSizeLabel.AutoSize = true;
            this.TypeSizeLabel.Location = new System.Drawing.Point(128, 8);
            this.TypeSizeLabel.Name = "TypeSizeLabel";
            this.TypeSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.TypeSizeLabel.TabIndex = 1;
            this.TypeSizeLabel.Text = "label1";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(225, 5);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(108, 20);
            this.ValueTextBox.TabIndex = 2;
            // 
            // InsertValueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.TypeSizeLabel);
            this.Controls.Add(this.ColNameLabel);
            this.Name = "InsertValueItem";
            this.Size = new System.Drawing.Size(349, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ColNameLabel;
        private System.Windows.Forms.Label TypeSizeLabel;
        private System.Windows.Forms.TextBox ValueTextBox;
    }
}
