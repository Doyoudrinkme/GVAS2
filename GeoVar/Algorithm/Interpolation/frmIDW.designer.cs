﻿namespace GeoVar {
    partial class frmInterpolationIDW {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterpolationIDW));
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFixed = new System.Windows.Forms.GroupBox();
            this.txtMaxPointNums = new System.Windows.Forms.TextBox();
            this.txtDisValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBarrier = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxInPoint = new System.Windows.Forms.ComboBox();
            this.comboBoxZValueField = new System.Windows.Forms.ComboBox();
            this.btnSaveRasterPath = new System.Windows.Forms.Button();
            this.btnOpenBarrier = new System.Windows.Forms.Button();
            this.chkBarrier = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.txtOutputRasterPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.comboBoxSearchRadius = new System.Windows.Forms.ComboBox();
            this.groupBoxVariable = new System.Windows.Forms.GroupBox();
            this.txtDisMaxValue = new System.Windows.Forms.TextBox();
            this.txtPointNumbers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeightValue = new System.Windows.Forms.TextBox();
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenSourceData = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.groupBoxFixed.SuspendLayout();
            this.groupBoxVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "点数：";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 19);
            this.label7.TabIndex = 76;
            this.label7.Text = "象素大小：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "输入点数据：";
            // 
            // groupBoxFixed
            // 
            this.groupBoxFixed.Controls.Add(this.txtMaxPointNums);
            this.groupBoxFixed.Controls.Add(this.txtDisValue);
            this.groupBoxFixed.Controls.Add(this.label10);
            this.groupBoxFixed.Controls.Add(this.label9);
            this.groupBoxFixed.Controls.Add(this.axLicenseControl1);
            this.groupBoxFixed.Location = new System.Drawing.Point(13, 125);
            this.groupBoxFixed.Name = "groupBoxFixed";
            this.groupBoxFixed.Size = new System.Drawing.Size(284, 82);
            this.groupBoxFixed.TabIndex = 83;
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "权重值：";
            // 
            // comboBoxBarrier
            // 
            this.comboBoxBarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBarrier.Location = new System.Drawing.Point(133, 220);
            this.comboBoxBarrier.Name = "comboBoxBarrier";
            this.comboBoxBarrier.Size = new System.Drawing.Size(128, 20);
            this.comboBoxBarrier.TabIndex = 74;
            this.comboBoxBarrier.SelectedIndexChanged += new System.EventHandler(this.comboBoxBarrier_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 66;
            this.label2.Text = "Z值字段：";
            // 
            // comboBoxInPoint
            // 
            this.comboBoxInPoint.Location = new System.Drawing.Point(107, 11);
            this.comboBoxInPoint.Name = "comboBoxInPoint";
            this.comboBoxInPoint.Size = new System.Drawing.Size(144, 20);
            this.comboBoxInPoint.TabIndex = 64;
            // 
            // comboBoxZValueField
            // 
            this.comboBoxZValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZValueField.Location = new System.Drawing.Point(107, 39);
            this.comboBoxZValueField.Name = "comboBoxZValueField";
            this.comboBoxZValueField.Size = new System.Drawing.Size(144, 20);
            this.comboBoxZValueField.TabIndex = 67;
            // 
            // btnSaveRasterPath
            // 
            this.btnSaveRasterPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRasterPath.Image")));
            this.btnSaveRasterPath.Location = new System.Drawing.Point(267, 275);
            this.btnSaveRasterPath.Name = "btnSaveRasterPath";
            this.btnSaveRasterPath.Size = new System.Drawing.Size(24, 24);
            this.btnSaveRasterPath.TabIndex = 80;
            this.btnSaveRasterPath.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveRasterPath.Click += new System.EventHandler(this.btnSaveRasterPath_Click);
            // 
            // btnOpenBarrier
            // 
            this.btnOpenBarrier.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenBarrier.Image")));
            this.btnOpenBarrier.Location = new System.Drawing.Point(267, 216);
            this.btnOpenBarrier.Name = "btnOpenBarrier";
            this.btnOpenBarrier.Size = new System.Drawing.Size(24, 24);
            this.btnOpenBarrier.TabIndex = 75;
            this.btnOpenBarrier.Click += new System.EventHandler(this.btnOpenBarrier_Click);
            // 
            // chkBarrier
            // 
            this.chkBarrier.Location = new System.Drawing.Point(13, 215);
            this.chkBarrier.Name = "chkBarrier";
            this.chkBarrier.Size = new System.Drawing.Size(128, 25);
            this.chkBarrier.TabIndex = 73;
            this.chkBarrier.Text = "是否使用障碍线：";
            this.chkBarrier.CheckedChanged += new System.EventHandler(this.chkBarrier_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(173, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(53, 314);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(88, 24);
            this.btnGO.TabIndex = 81;
            this.btnGO.Text = "开始插值";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // txtOutputRasterPath
            // 
            this.txtOutputRasterPath.Location = new System.Drawing.Point(107, 278);
            this.txtOutputRasterPath.Name = "txtOutputRasterPath";
            this.txtOutputRasterPath.Size = new System.Drawing.Size(144, 21);
            this.txtOutputRasterPath.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "距离极值：";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "输出栅格位置：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(107, 250);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(144, 21);
            this.txtCellSize.TabIndex = 77;
            // 
            // comboBoxSearchRadius
            // 
            this.comboBoxSearchRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchRadius.Location = new System.Drawing.Point(107, 95);
            this.comboBoxSearchRadius.Name = "comboBoxSearchRadius";
            this.comboBoxSearchRadius.Size = new System.Drawing.Size(144, 20);
            this.comboBoxSearchRadius.TabIndex = 72;
            // 
            // groupBoxVariable
            // 
            this.groupBoxVariable.Controls.Add(this.txtDisMaxValue);
            this.groupBoxVariable.Controls.Add(this.label6);
            this.groupBoxVariable.Controls.Add(this.txtPointNumbers);
            this.groupBoxVariable.Controls.Add(this.label4);
            this.groupBoxVariable.Location = new System.Drawing.Point(13, 125);
            this.groupBoxVariable.Name = "groupBoxVariable";
            this.groupBoxVariable.Size = new System.Drawing.Size(284, 82);
            this.groupBoxVariable.TabIndex = 70;
            this.groupBoxVariable.TabStop = false;
            this.groupBoxVariable.Text = "搜索半径设置";
            // 
            // txtDisMaxValue
            // 
            this.txtDisMaxValue.Location = new System.Drawing.Point(94, 44);
            this.txtDisMaxValue.Name = "txtDisMaxValue";
            this.txtDisMaxValue.Size = new System.Drawing.Size(144, 21);
            this.txtDisMaxValue.TabIndex = 3;
            // 
            // txtPointNumbers
            // 
            this.txtPointNumbers.Location = new System.Drawing.Point(94, 20);
            this.txtPointNumbers.Name = "txtPointNumbers";
            this.txtPointNumbers.Size = new System.Drawing.Size(144, 21);
            this.txtPointNumbers.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 71;
            this.label5.Text = "搜索半径类型：";
            // 
            // txtWeightValue
            // 
            this.txtWeightValue.Location = new System.Drawing.Point(107, 67);
            this.txtWeightValue.Name = "txtWeightValue";
            this.txtWeightValue.Size = new System.Drawing.Size(144, 21);
            this.txtWeightValue.TabIndex = 69;
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.FileName = "openFileDialog1";
            // 
            // btnOpenSourceData
            // 
            this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
            this.btnOpenSourceData.Location = new System.Drawing.Point(267, 7);
            this.btnOpenSourceData.Name = "btnOpenSourceData";
            this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
            this.btnOpenSourceData.TabIndex = 65;
            this.btnOpenSourceData.Click += new System.EventHandler(this.btnOpenSourceData_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(244, 11);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 84;
            // 
            // frmInterpolationIDW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 343);
            this.Controls.Add(this.groupBoxVariable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxBarrier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxInPoint);
            this.Controls.Add(this.comboBoxZValueField);
            this.Controls.Add(this.btnSaveRasterPath);
            this.Controls.Add(this.btnOpenBarrier);
            this.Controls.Add(this.chkBarrier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.txtOutputRasterPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCellSize);
            this.Controls.Add(this.comboBoxSearchRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWeightValue);
            this.Controls.Add(this.btnOpenSourceData);
            this.Controls.Add(this.groupBoxFixed);
            this.Name = "frmInterpolationIDW";
            this.Text = "IDW插值";
            this.Load += new System.EventHandler(this.frmInterpolationIDW_Load);
            this.groupBoxFixed.ResumeLayout(false);
            this.groupBoxFixed.PerformLayout();
            this.groupBoxVariable.ResumeLayout(false);
            this.groupBoxVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxFixed;
        private System.Windows.Forms.TextBox txtMaxPointNums;
        private System.Windows.Forms.TextBox txtDisValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBarrier;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxInPoint;
        private System.Windows.Forms.ComboBox comboBoxZValueField;
        private System.Windows.Forms.Button btnSaveRasterPath;
        private System.Windows.Forms.Button btnOpenBarrier;
        private System.Windows.Forms.CheckBox chkBarrier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.TextBox txtOutputRasterPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.ComboBox comboBoxSearchRadius;
        private System.Windows.Forms.GroupBox groupBoxVariable;
        private System.Windows.Forms.TextBox txtDisMaxValue;
        private System.Windows.Forms.TextBox txtPointNumbers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWeightValue;
        private System.Windows.Forms.OpenFileDialog OpenFileDlg;
        private System.Windows.Forms.Button btnOpenSourceData;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
    }
}