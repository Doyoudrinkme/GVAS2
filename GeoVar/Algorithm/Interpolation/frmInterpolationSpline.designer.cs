namespace GeoVar {
    partial class frmInterpolationSpline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterpolationSpline));
            this.btnSaveRasterPath = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCellSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPointNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeightValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSplineType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxZValueField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenSourceData = new System.Windows.Forms.Button();
            this.comboBoxInputData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveRasterPath
            // 
            this.btnSaveRasterPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRasterPath.Image")));
            this.btnSaveRasterPath.Location = new System.Drawing.Point(256, 204);
            this.btnSaveRasterPath.Name = "btnSaveRasterPath";
            this.btnSaveRasterPath.Size = new System.Drawing.Size(24, 24);
            this.btnSaveRasterPath.TabIndex = 49;
            this.btnSaveRasterPath.Click += new System.EventHandler(this.btnSaveRasterPath_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnSaveRasterPath);
            this.GroupBox1.Controls.Add(this.txtOutputPath);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.txtCellSize);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.txtPointNum);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.txtWeightValue);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.comboBoxSplineType);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.comboBoxZValueField);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.btnOpenSourceData);
            this.GroupBox1.Controls.Add(this.comboBoxInputData);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Location = new System.Drawing.Point(-3, -2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(290, 234);
            this.GroupBox1.TabIndex = 42;
            this.GroupBox1.TabStop = false;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(120, 206);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(120, 21);
            this.txtOutputPath.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "输出栅格位置：";
            // 
            // txtCellSize
            // 
            this.txtCellSize.Location = new System.Drawing.Point(120, 176);
            this.txtCellSize.Name = "txtCellSize";
            this.txtCellSize.Size = new System.Drawing.Size(120, 21);
            this.txtCellSize.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "象素大小：";
            // 
            // txtPointNum
            // 
            this.txtPointNum.Location = new System.Drawing.Point(120, 146);
            this.txtPointNum.Name = "txtPointNum";
            this.txtPointNum.Size = new System.Drawing.Size(120, 21);
            this.txtPointNum.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "点数：";
            // 
            // txtWeightValue
            // 
            this.txtWeightValue.Location = new System.Drawing.Point(120, 116);
            this.txtWeightValue.Name = "txtWeightValue";
            this.txtWeightValue.Size = new System.Drawing.Size(120, 21);
            this.txtWeightValue.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "权重：";
            // 
            // comboBoxSplineType
            // 
            this.comboBoxSplineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSplineType.Location = new System.Drawing.Point(120, 86);
            this.comboBoxSplineType.Name = "comboBoxSplineType";
            this.comboBoxSplineType.Size = new System.Drawing.Size(120, 20);
            this.comboBoxSplineType.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "样条类型：";
            // 
            // comboBoxZValueField
            // 
            this.comboBoxZValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZValueField.Location = new System.Drawing.Point(120, 56);
            this.comboBoxZValueField.Name = "comboBoxZValueField";
            this.comboBoxZValueField.Size = new System.Drawing.Size(120, 20);
            this.comboBoxZValueField.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Z值字段：";
            // 
            // btnOpenSourceData
            // 
            this.btnOpenSourceData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceData.Image")));
            this.btnOpenSourceData.Location = new System.Drawing.Point(256, 24);
            this.btnOpenSourceData.Name = "btnOpenSourceData";
            this.btnOpenSourceData.Size = new System.Drawing.Size(24, 24);
            this.btnOpenSourceData.TabIndex = 36;
            this.btnOpenSourceData.Click += new System.EventHandler(this.btnOpenSourceData_Click);
            // 
            // comboBoxInputData
            // 
            this.comboBoxInputData.Location = new System.Drawing.Point(120, 26);
            this.comboBoxInputData.Name = "comboBoxInputData";
            this.comboBoxInputData.Size = new System.Drawing.Size(120, 20);
            this.comboBoxInputData.TabIndex = 35;
            this.comboBoxInputData.SelectedIndexChanged += new System.EventHandler(this.comboBoxInputData_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "输入点数据：";
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(50, 238);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(80, 24);
            this.btnGO.TabIndex = 40;
            this.btnGO.Text = "开始插值";
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.FileName = "OpenFileDialog1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmInterpolationSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 267);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmInterpolationSpline";
            this.Text = "样条插值";
            this.Load += new System.EventHandler(this.frmInterpolationSpline_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveRasterPath;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCellSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPointNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWeightValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSplineType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxZValueField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenSourceData;
        private System.Windows.Forms.ComboBox comboBoxInputData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGO;
        internal System.Windows.Forms.OpenFileDialog OpenFileDlg;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
    }
}