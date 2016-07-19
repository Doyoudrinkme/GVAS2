namespace GeoVar.Algorithm.Variance {
    partial class TwoDimVariance {
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
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.VarCal = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.tBoxExportResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImportData = new System.Windows.Forms.Button();
            this.tBoxImportData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxVarOrg = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(92, 209);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(38, 20);
            this.btnDefault.TabIndex = 29;
            this.btnDefault.Text = "默认";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(205, 209);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 20);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // VarCal
            // 
            this.VarCal.Location = new System.Drawing.Point(368, 209);
            this.VarCal.Name = "VarCal";
            this.VarCal.Size = new System.Drawing.Size(43, 20);
            this.VarCal.TabIndex = 27;
            this.VarCal.Text = "计算";
            this.VarCal.UseVisualStyleBackColor = true;
            this.VarCal.Click += new System.EventHandler(this.VarCal_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(368, 132);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(43, 20);
            this.btnSaveResult.TabIndex = 26;
            this.btnSaveResult.Text = "…";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // tBoxExportResult
            // 
            this.tBoxExportResult.Location = new System.Drawing.Point(92, 131);
            this.tBoxExportResult.Name = "tBoxExportResult";
            this.tBoxExportResult.Size = new System.Drawing.Size(248, 21);
            this.tBoxExportResult.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "结果保存";
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(368, 14);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(43, 20);
            this.btnImportData.TabIndex = 18;
            this.btnImportData.Text = "…";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // tBoxImportData
            // 
            this.tBoxImportData.Location = new System.Drawing.Point(92, 13);
            this.tBoxImportData.Name = "tBoxImportData";
            this.tBoxImportData.Size = new System.Drawing.Size(248, 21);
            this.tBoxImportData.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "数据导入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "计算方向";
            // 
            // cbxVarOrg
            // 
            this.cbxVarOrg.FormattingEnabled = true;
            this.cbxVarOrg.Items.AddRange(new object[] {
            "横向",
            "纵向"});
            this.cbxVarOrg.Location = new System.Drawing.Point(262, 71);
            this.cbxVarOrg.Name = "cbxVarOrg";
            this.cbxVarOrg.Size = new System.Drawing.Size(78, 20);
            this.cbxVarOrg.TabIndex = 20;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "全幅计算",
            "逐行计算"});
            this.comboBox1.Location = new System.Drawing.Point(92, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 20);
            this.comboBox1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "计算方式";
            // 
            // TwoDimVariance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 275);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.VarCal);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.tBoxExportResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxVarOrg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.tBoxImportData);
            this.Controls.Add(this.label1);
            this.Name = "TwoDimVariance";
            this.Text = "TwoDimVariance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button VarCal;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.TextBox tBoxExportResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.TextBox tBoxImportData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxVarOrg;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}