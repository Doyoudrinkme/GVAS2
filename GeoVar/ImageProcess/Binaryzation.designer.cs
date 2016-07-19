namespace GeoVar {
    partial class FrmNormalizeNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtBox = new System.Windows.Forms.TextBox();
            this.DlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.BtnOutput = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DlgSave = new System.Windows.Forms.SaveFileDialog();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnInput = new System.Windows.Forms.Button();
            this.ComboBoxInLayer = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtBox
            // 
            this.TxtBox.Location = new System.Drawing.Point(85, 170);
            this.TxtBox.Name = "TxtBox";
            this.TxtBox.Size = new System.Drawing.Size(132, 21);
            this.TxtBox.TabIndex = 31;
            this.TxtBox.Text = "c:\\";
            // 
            // DlgOpen
            // 
            this.DlgOpen.FileName = "OpenFileDialog1";
            // 
            // BtnOutput
            // 
            this.BtnOutput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BtnOutput.ForeColor = System.Drawing.Color.Magenta;
            this.BtnOutput.Location = new System.Drawing.Point(236, 170);
            this.BtnOutput.Name = "BtnOutput";
            this.BtnOutput.Size = new System.Drawing.Size(51, 20);
            this.BtnOutput.TabIndex = 30;
            this.BtnOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOutput.UseVisualStyleBackColor = false;
            this.BtnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(16, 173);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 12);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "输出路径：";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(160, 211);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(44, 23);
            this.BtnCancel.TabIndex = 28;
            this.BtnCancel.Text = "关闭";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(58, 211);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(44, 23);
            this.BtnOK.TabIndex = 27;
            this.BtnOK.Text = "确定";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnInput
            // 
            this.BtnInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BtnInput.ForeColor = System.Drawing.Color.Magenta;
            this.BtnInput.Location = new System.Drawing.Point(236, 20);
            this.BtnInput.Name = "BtnInput";
            this.BtnInput.Size = new System.Drawing.Size(51, 20);
            this.BtnInput.TabIndex = 26;
            this.BtnInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnInput.UseVisualStyleBackColor = false;
            this.BtnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // ComboBoxInLayer
            // 
            this.ComboBoxInLayer.FormattingEnabled = true;
            this.ComboBoxInLayer.Location = new System.Drawing.Point(85, 21);
            this.ComboBoxInLayer.Name = "ComboBoxInLayer";
            this.ComboBoxInLayer.Size = new System.Drawing.Size(132, 20);
            this.ComboBoxInLayer.TabIndex = 25;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 12);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "输入数据：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "输入阈值：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 21);
            this.textBox1.TabIndex = 33;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Invert";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 36);
            this.label4.TabIndex = 35;
            this.label4.Text = "注：二值化运算为大于阈值的栅格值赋值为1，\r\n反之则为0；如果勾选Invert则为大于阈值栅格\r\n值赋值为0，反之赋值为1";
            // 
            // FrmNormalizeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 251);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBox);
            this.Controls.Add(this.BtnOutput);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnInput);
            this.Controls.Add(this.ComboBoxInLayer);
            this.Controls.Add(this.Label1);
            this.Name = "FrmNormalizeNew";
            this.Text = "数据二值化";
            this.Load += new System.EventHandler(this.FrmNormalizeNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TxtBox;
        internal System.Windows.Forms.OpenFileDialog DlgOpen;
        internal System.Windows.Forms.Button BtnOutput;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.SaveFileDialog DlgSave;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.Button BtnInput;
        internal System.Windows.Forms.ComboBox ComboBoxInLayer;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
    }
}