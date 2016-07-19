namespace GeoVar {
    partial class frmInterpolationKridging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterpolationKridging));
            this.RadioButtonUniveral = new System.Windows.Forms.RadioButton();
            this.groupBoxFixed = new System.Windows.Forms.GroupBox();
            this.txtMaxPointNums = new System.Windows.Forms.TextBox();
            this.txtDisValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RadioOrdinary = new System.Windows.Forms.RadioButton();
            this.ComboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnSaveRasterPath = new System.Windows.Forms.Button();
            this.comboBoxSearchRadius = new System.Windows.Forms.ComboBox();
            this.txtOutputRasterPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxVariable = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPointNumbers = new System.Windows.Forms.TextBox();
            this.txtDisMaxValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.comboBoxZValueField = new System.Windows.Forms.ComboBox();
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxInPoint = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenSourceData = new System.Windows.Forms.Button();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxFixed.SuspendLayout();
            this.groupBoxVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // RadioButtonUniveral
            // 
            this.RadioButtonUniveral.AutoSize = true;
            this.RadioButtonUniveral.Location = new System.Drawing.Point(193, 70);
            this.RadioButtonUniveral.Name = "RadioButtonUniveral";
            this.RadioButtonUniveral.Size = new System.Drawing.Size(77, 16);
            this.RadioButtonUniveral.TabIndex = 103;
            this.RadioButtonUniveral.TabStop = true;
            this.RadioButtonUniveral.Text = "Universal";
            this.RadioButtonUniveral.UseVisualStyleBackColor = true;
            this.RadioButtonUniveral.CheckedChanged += new System.EventHandler(this.RadioButtonUniveral_CheckedChanged);
            // 
            // groupBoxFixed
            // 
            this.groupBoxFixed.Controls.Add(this.txtMaxPointNums);
            this.groupBoxFixed.Controls.Add(this.txtDisValue);
            this.groupBoxFixed.Controls.Add(this.label10);
            this.groupBoxFixed.Controls.Add(this.label9);
            this.groupBoxFixed.Location = new System.Drawing.Point(18, 157);
            this.groupBoxFixed.Name = "groupBoxFixed";
            this.groupBoxFixed.Size = new System.Drawing.Size(270, 82);
            this.groupBoxFixed.TabIndex = 101;
            this.groupBoxFixed.TabStop = false;
            this.groupBoxFixed.Text = "搜索半径设置";
            // 
            // txtMaxPointNums
            // 
            this.txtMaxPointNums.Location = new System.Drawing.Point(94, 46);
            this.txtMaxPointNums.Name = "txtMaxPointNums";
            this.txtMaxPointNums.Size = new System.Drawing.Size(144, 21);
            this.txtMaxPointNums.TabIndex = 3;
            // 
            // txtDisValue
            // 
            this.txtDisValue.Location = new System.Drawing.Point(94, 22);
            this.txtDisValue.Name = "txtDisValue";
            this.txtDisValue.Size = new System.Drawing.Size(144, 21);
            this.txtDisValue.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "最大点数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "距离：";
            // 
            // RadioOrdinary
            // 
            this.RadioOrdinary.AutoSize = true;
            this.RadioOrdinary.Location = new System.Drawing.Point(108, 70);
            this.RadioOrdinary.Name = "RadioOrdinary";
            this.RadioOrdinary.Size = new System.Drawing.Size(71, 16);
            this.RadioOrdinary.TabIndex = 104;
            this.RadioOrdinary.TabStop = true;
            this.RadioOrdinary.Text = "Ordinary";
            this.RadioOrdinary.UseVisualStyleBackColor = true;
            this.RadioOrdinary.CheckedChanged += new System.EventHandler(this.RadioOrdinary_CheckedChanged);
            // 
            // ComboBoxMethod
            // 
            this.ComboBoxMethod.FormattingEnabled = true;
            this.ComboBoxMethod.Location = new System.Drawing.Point(110, 101);
            this.ComboBoxMethod.Name = "ComboBoxMethod";
            this.ComboBoxMethod.Size = new System.Drawing.Size(174, 20);
            this.ComboBoxMethod.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 19);
            this.label7.TabIndex = 94;
            this.label7.Text = "象素大小：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(49, 321);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(88, 24);
            this.btnGO.TabIndex = 99;
            this.btnGO.Text = "开始插值";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnSaveRasterPath
            // 
            this.btnSaveRasterPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRasterPath.Image")));
            this.btnSaveRasterPath.Location = new System.Drawing.Point(260, 284);
            this.btnSaveRasterPath.Name = "btnSaveRasterPath";
            this.btnSaveRasterPath.Size = new System.Drawing.Size(24, 24);
            this.btnSaveRasterPath.TabIndex = 98;
            this.btnSaveRasterPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveRasterPath.Click += new System.EventHandler(this.btnSaveRasterPath_Click);
            // 
            // comboBoxSearchRadius
            // 
            this.comboBoxSearchRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchRadius.Location = new System.Drawing.Point(110, 131);
            this.comboBoxSearchRadius.Name = "comboBoxSearchRadius";
            this.comboBoxSearchRadius.Size = new System.Drawing.Size(174, 20);
            this.comboBoxSearchRadius.TabIndex = 93;
            this.comboBoxSearchRadius.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchRadius_SelectedIndexChanged);
            // 
            // txtOutputRasterPath
            // 
            this.txtOutputRasterPath.Location = new System.Drawing.Point(110, 287);
            this.txtOutputRasterPath.Name = "txtOutputRasterPath";
            this.txtOutputRasterPath.Size = new System.Drawing.Size(144, 21);
            this.txtOutputRasterPath.TabIndex = 97;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 18);
            this.label8.TabIndex = 96;
            this.label8.Text = "输出栅格位置：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 92;
            this.label5.Text = "搜索半径类型：";
            // 
            // groupBoxVariable
            // 
            this.groupBoxVariable.Controls.Add(this.label6);
            this.groupBoxVariable.Controls.Add(this.label4);
            this.groupBoxVariable.Controls.Add(this.txtPointNumbers);
            this.groupBoxVariable.Controls.Add(this.txtDisMaxValue);
            this.groupBoxVariable.Location = new System.Drawing.Point(18, 157);
            this.groupBoxVariable.Name = "groupBoxVariable";
            this.groupBoxVariable.Size = new System.Drawing.Size(270, 82);
            this.groupBoxVariable.TabIndex = 91;
            this.groupBoxVariable.TabStop = false;
            this.groupBoxVariable.Text = "搜索半径设置";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "距离极值：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "点数：";
            // 
            // txtPointNumbers
            // 
            this.txtPointNumbers.Location = new System.Drawing.Point(94, 21);
            this.txtPointNumbers.Name = "txtPointNumbers";
            this.txtPointNumbers.Size = new System.Drawing.Size(144, 21);
            this.txtPointNumbers.TabIndex = 4;
            // 
            // txtDisMaxValue
            // 
            this.txtDisMaxValue.Location = new System.Drawing.Point(94, 48);
            this.txtDisMaxValue.Name = "txtDisMaxValue";
            this.txtDisMaxValue.Size = new System.Drawing.Size(144, 21);
            this.txtDisMaxValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 88;
            this.label2.Text = "Z值字段：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(113, 253);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(144, 21);
            this.txtCellSize.TabIndex = 95;
            // 
            // comboBoxZValueField
            // 
            this.comboBoxZValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZValueField.Location = new System.Drawing.Point(110, 42);
            this.comboBoxZValueField.Name = "comboBoxZValueField";
            this.comboBoxZValueField.Size = new System.Drawing.Size(144, 20);
            this.comboBoxZValueField.TabIndex = 89;
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 90;
            this.label3.Text = "克里格方法：";
            // 
            // comboBoxInPoint
            // 
            this.comboBoxInPoint.Location = new System.Drawing.Point(110, 14);
            this.comboBoxInPoint.Name = "comboBoxInPoint";
            this.comboBoxInPoint.Size = new System.Drawing.Size(144, 20);
            this.comboBoxInPoint.TabIndex = 86;
            this.comboBoxInPoint.SelectedIndexChanged += new System.EventHandler(this.comboBoxInPoint_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "输入点数据：";
            // 
            // btnOpenSourceData
            // 
            this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
            this.btnOpenSourceData.Location = new System.Drawing.Point(260, 11);
            this.btnOpenSourceData.Name = "btnOpenSourceData";
            this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
            this.btnOpenSourceData.TabIndex = 87;
            this.btnOpenSourceData.Click += new System.EventHandler(this.btnOpenSourceData_Click);
            // 
            // frmInterpolationKridging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 353);
            this.Controls.Add(this.RadioButtonUniveral);
            this.Controls.Add(this.groupBoxFixed);
            this.Controls.Add(this.RadioOrdinary);
            this.Controls.Add(this.ComboBoxMethod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnSaveRasterPath);
            this.Controls.Add(this.comboBoxSearchRadius);
            this.Controls.Add(this.txtOutputRasterPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBoxVariable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.comboBoxZValueField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxInPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenSourceData);
            this.Name = "frmInterpolationKridging";
            this.Text = "克里格插值";
            this.Load += new System.EventHandler(this.frmInterpolationKridging_Load);
            this.groupBoxFixed.ResumeLayout(false);
            this.groupBoxFixed.PerformLayout();
            this.groupBoxVariable.ResumeLayout(false);
            this.groupBoxVariable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton RadioButtonUniveral;
        private System.Windows.Forms.GroupBox groupBoxFixed;
        private System.Windows.Forms.TextBox txtMaxPointNums;
        private System.Windows.Forms.TextBox txtDisValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.RadioButton RadioOrdinary;
        internal System.Windows.Forms.ComboBox ComboBoxMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnSaveRasterPath;
        private System.Windows.Forms.ComboBox comboBoxSearchRadius;
        private System.Windows.Forms.TextBox txtOutputRasterPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxVariable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPointNumbers;
        private System.Windows.Forms.TextBox txtDisMaxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.ComboBox comboBoxZValueField;
        private System.Windows.Forms.OpenFileDialog OpenFileDlg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxInPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenSourceData;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
    }
}