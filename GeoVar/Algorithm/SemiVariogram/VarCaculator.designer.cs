namespace GeoVar {
    partial class VarCaculator {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxImportData = new System.Windows.Forms.TextBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBLag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.tBoxExportResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VarCal = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.cbBMaxLag = new System.Windows.Forms.ComboBox();
            this.btnBinMapSaveDir = new System.Windows.Forms.Button();
            this.tBoxBinMap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxVarOrg = new System.Windows.Forms.ComboBox();
            this.cbxVarMapOrLine = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxSmoothWindowSize = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据导入";
            // 
            // tBoxImportData
            // 
            this.tBoxImportData.Location = new System.Drawing.Point(95, 25);
            this.tBoxImportData.Name = "tBoxImportData";
            this.tBoxImportData.Size = new System.Drawing.Size(265, 21);
            this.tBoxImportData.TabIndex = 1;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(387, 24);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(43, 20);
            this.btnImportData.TabIndex = 2;
            this.btnImportData.Text = "…";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "最大滞距";
            // 
            // tBLag
            // 
            this.tBLag.Location = new System.Drawing.Point(282, 83);
            this.tBLag.Name = "tBLag";
            this.tBLag.Size = new System.Drawing.Size(78, 21);
            this.tBLag.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "变距步长";
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(387, 343);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(43, 20);
            this.btnSaveResult.TabIndex = 11;
            this.btnSaveResult.Text = "…";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // tBoxExportResult
            // 
            this.tBoxExportResult.Location = new System.Drawing.Point(95, 342);
            this.tBoxExportResult.Name = "tBoxExportResult";
            this.tBoxExportResult.Size = new System.Drawing.Size(265, 21);
            this.tBoxExportResult.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "结果保存";
            // 
            // VarCal
            // 
            this.VarCal.Location = new System.Drawing.Point(387, 393);
            this.VarCal.Name = "VarCal";
            this.VarCal.Size = new System.Drawing.Size(43, 20);
            this.VarCal.TabIndex = 12;
            this.VarCal.Text = "计算";
            this.VarCal.UseVisualStyleBackColor = true;
            this.VarCal.Click += new System.EventHandler(this.VarCal_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(225, 393);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 20);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(95, 393);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(38, 20);
            this.btnDefault.TabIndex = 14;
            this.btnDefault.Text = "默认";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // cbBMaxLag
            // 
            this.cbBMaxLag.FormattingEnabled = true;
            this.cbBMaxLag.Items.AddRange(new object[] {
            "1/2图幅",
            "1/3图幅",
            "1/4图幅",
            "1/5图幅",
            "1/6图幅",
            "1/8图幅"});
            this.cbBMaxLag.Location = new System.Drawing.Point(95, 83);
            this.cbBMaxLag.Name = "cbBMaxLag";
            this.cbBMaxLag.Size = new System.Drawing.Size(78, 20);
            this.cbBMaxLag.TabIndex = 15;
            // 
            // btnBinMapSaveDir
            // 
            this.btnBinMapSaveDir.Location = new System.Drawing.Point(387, 288);
            this.btnBinMapSaveDir.Name = "btnBinMapSaveDir";
            this.btnBinMapSaveDir.Size = new System.Drawing.Size(43, 20);
            this.btnBinMapSaveDir.TabIndex = 18;
            this.btnBinMapSaveDir.Text = "…";
            this.btnBinMapSaveDir.UseVisualStyleBackColor = true;
            this.btnBinMapSaveDir.Click += new System.EventHandler(this.btnBinMapSaveDir_Click);
            // 
            // tBoxBinMap
            // 
            this.tBoxBinMap.Location = new System.Drawing.Point(95, 287);
            this.tBoxBinMap.Name = "tBoxBinMap";
            this.tBoxBinMap.Size = new System.Drawing.Size(265, 21);
            this.tBoxBinMap.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "二值保存";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "变异方向";
            // 
            // cbxVarOrg
            // 
            this.cbxVarOrg.FormattingEnabled = true;
            this.cbxVarOrg.Items.AddRange(new object[] {
            "W-->E",
            "N-->S",
            "WS-->EN",
            "WN-->ES"});
            this.cbxVarOrg.Location = new System.Drawing.Point(282, 140);
            this.cbxVarOrg.Name = "cbxVarOrg";
            this.cbxVarOrg.Size = new System.Drawing.Size(78, 20);
            this.cbxVarOrg.TabIndex = 4;
            // 
            // cbxVarMapOrLine
            // 
            this.cbxVarMapOrLine.FormattingEnabled = true;
            this.cbxVarMapOrLine.Items.AddRange(new object[] {
            "全幅",
            "单行"});
            this.cbxVarMapOrLine.Location = new System.Drawing.Point(95, 140);
            this.cbxVarMapOrLine.Name = "cbxVarMapOrLine";
            this.cbxVarMapOrLine.Size = new System.Drawing.Size(78, 20);
            this.cbxVarMapOrLine.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "变异方式";
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(95, 192);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(35, 16);
            this.radioButtonYes.TabIndex = 21;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "是";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            this.radioButtonYes.CheckedChanged += new System.EventHandler(this.radioButtonYes_CheckedChanged);
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(138, 192);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(35, 16);
            this.radioButtonNo.TabIndex = 22;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "否";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.CheckedChanged += new System.EventHandler(this.radioButtonNo_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "保存二值";
            // 
            // cbxSmoothWindowSize
            // 
            this.cbxSmoothWindowSize.FormattingEnabled = true;
            this.cbxSmoothWindowSize.Items.AddRange(new object[] {
            "0",
            "3",
            "5",
            "7"});
            this.cbxSmoothWindowSize.Location = new System.Drawing.Point(95, 236);
            this.cbxSmoothWindowSize.Name = "cbxSmoothWindowSize";
            this.cbxSmoothWindowSize.Size = new System.Drawing.Size(78, 20);
            this.cbxSmoothWindowSize.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "平滑窗口";
            // 
            // VarCaculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 477);
            this.Controls.Add(this.cbxSmoothWindowSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radioButtonNo);
            this.Controls.Add(this.radioButtonYes);
            this.Controls.Add(this.cbxVarMapOrLine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBinMapSaveDir);
            this.Controls.Add(this.tBoxBinMap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbBMaxLag);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.VarCal);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.tBoxExportResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBLag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxVarOrg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.tBoxImportData);
            this.Controls.Add(this.label1);
            this.Name = "VarCaculator";
            this.Text = "逐行变异";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxImportData;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBLag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.TextBox tBoxExportResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button VarCal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.ComboBox cbBMaxLag;
        private System.Windows.Forms.Button btnBinMapSaveDir;
        private System.Windows.Forms.TextBox tBoxBinMap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxVarOrg;
        private System.Windows.Forms.ComboBox cbxVarMapOrLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSmoothWindowSize;
        private System.Windows.Forms.Label label9;
    }
}