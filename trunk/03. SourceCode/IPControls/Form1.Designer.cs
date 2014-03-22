namespace IP.Core.IPControls {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            IP.Core.IPControls.CheckBoxProperties checkBoxProperties1 = new IP.Core.IPControls.CheckBoxProperties();
            IP.Core.IPControls.CheckBoxProperties checkBoxProperties2 = new IP.Core.IPControls.CheckBoxProperties();
            this.checkBoxComboBox1 = new IP.Core.IPControls.CheckBoxComboBox();
            this.checkBoxComboBox2 = new IP.Core.IPControls.CheckBoxComboBox();
            this.SuspendLayout();
            // 
            // checkBoxComboBox1
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties1;
            this.checkBoxComboBox1.DisplayMemberSingleItem = "";
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.Location = new System.Drawing.Point(282, 102);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(121, 22);
            this.checkBoxComboBox1.TabIndex = 1;
            this.checkBoxComboBox1.Text = "Hiển thị cột...";
            // 
            // checkBoxComboBox2
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox2.CheckBoxProperties = checkBoxProperties2;
            this.checkBoxComboBox2.DisplayMemberSingleItem = "";
            this.checkBoxComboBox2.FormattingEnabled = true;
            this.checkBoxComboBox2.Location = new System.Drawing.Point(421, 26);
            this.checkBoxComboBox2.Name = "checkBoxComboBox2";
            this.checkBoxComboBox2.Size = new System.Drawing.Size(121, 22);
            this.checkBoxComboBox2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 462);
            this.Controls.Add(this.checkBoxComboBox2);
            this.Controls.Add(this.checkBoxComboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private IP.Core.IPControls.CheckBoxComboBox checkBoxComboBox1;
        private CheckBoxComboBox checkBoxComboBox2;
    }
}

