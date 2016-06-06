namespace tp_lab1
{
    partial class AddColumnItem
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.NullCheckBox = new System.Windows.Forms.CheckBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.AICheckBox = new System.Windows.Forms.CheckBox();
            this.PrimaryKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(3, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "INT",
            "VARCHAR",
            "TEXT",
            "FLOAT"});
            this.TypeComboBox.Location = new System.Drawing.Point(109, 3);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeComboBox.TabIndex = 1;
            // 
            // NullCheckBox
            // 
            this.NullCheckBox.AutoSize = true;
            this.NullCheckBox.Location = new System.Drawing.Point(310, 6);
            this.NullCheckBox.Name = "NullCheckBox";
            this.NullCheckBox.Size = new System.Drawing.Size(15, 14);
            this.NullCheckBox.TabIndex = 2;
            this.NullCheckBox.UseVisualStyleBackColor = true;
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(236, 3);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(57, 20);
            this.LengthTextBox.TabIndex = 3;
            // 
            // AICheckBox
            // 
            this.AICheckBox.AutoSize = true;
            this.AICheckBox.Location = new System.Drawing.Point(370, 6);
            this.AICheckBox.Name = "AICheckBox";
            this.AICheckBox.Size = new System.Drawing.Size(15, 14);
            this.AICheckBox.TabIndex = 5;
            this.AICheckBox.UseVisualStyleBackColor = true;
            // 
            // PrimaryKeyCheckBox
            // 
            this.PrimaryKeyCheckBox.AutoSize = true;
            this.PrimaryKeyCheckBox.Location = new System.Drawing.Point(340, 6);
            this.PrimaryKeyCheckBox.Name = "PrimaryKeyCheckBox";
            this.PrimaryKeyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.PrimaryKeyCheckBox.TabIndex = 6;
            this.PrimaryKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddColumnItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PrimaryKeyCheckBox);
            this.Controls.Add(this.AICheckBox);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.NullCheckBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.NameTextBox);
            this.Name = "AddColumnItem";
            this.Size = new System.Drawing.Size(400, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.CheckBox NullCheckBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.CheckBox AICheckBox;
        private System.Windows.Forms.CheckBox PrimaryKeyCheckBox;
    }
}
