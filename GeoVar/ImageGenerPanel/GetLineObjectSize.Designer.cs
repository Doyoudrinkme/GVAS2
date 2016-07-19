namespace GeoVar.ImageGenerPanel {
    partial class GetLineObjectSize {
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
            this.VarCal = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.tBoxExportResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImportData = new System.Windows.Forms.Button();
            this.tBoxImportData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VarCal
            // 
            this.VarCal.Location = new System.Drawing.Point(393, 140);
            this.VarCal.Name = "VarCal";
            this.VarCal.Size = new System.Drawing.Size(43, 20);
            this.VarCal.TabIndex = 35;
            this.VarCal.Text = "计算";
            this.VarCal.UseVisualStyleBackColor = true;
            this.VarCal.Click += new System.EventHandler(this.VarCal_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(393, 90);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(43, 20);
            this.btnSaveResult.TabIndex = 34;
            this.btnSaveResult.Text = "…";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // tBoxExportResult
            // 
            this.tBoxExportResult.Location = new System.Drawing.Point(101, 89);
            this.tBoxExportResult.Name = "tBoxExportResult";
            this.tBoxExportResult.Size = new System.Drawing.Size(265, 21);
            this.tBoxExportResult.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "结果保存";
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(393, 31);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(43, 20);
            this.btnImportData.TabIndex = 26;
            this.btnImportData.Text = "…";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // tBoxImportData
            // 
            this.tBoxImportData.Location = new System.Drawing.Point(101, 32);
            this.tBoxImportData.Name = "tBoxImportData";
            this.tBoxImportData.Size = new System.Drawing.Size(265, 21);
            this.tBoxImportData.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "数据导入";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(101, 140);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(38, 20);
            this.btnDefault.TabIndex = 45;
            this.btnDefault.Text = "默认";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(236, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 20);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // GetLineObjectSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 192);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.VarCal);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.tBoxExportResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.tBoxImportData);
            this.Controls.Add(this.label1);
            this.Name = "GetLineObjectSize";
            this.Text = "逐行方差均值计算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button VarCal;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.TextBox tBoxExportResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.TextBox tBoxImportData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClear;
    }
}