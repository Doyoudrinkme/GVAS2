namespace GeoVar {
    partial class ImageRandom {
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
            this.btnGen = new System.Windows.Forms.Button();
            this.labelwidth = new System.Windows.Forms.Label();
            this.labelheight = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDir = new System.Windows.Forms.Button();
            this.combWidth = new System.Windows.Forms.ComboBox();
            this.combHeight = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(294, 184);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(49, 28);
            this.btnGen.TabIndex = 0;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(12, 35);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(29, 12);
            this.labelwidth.TabIndex = 1;
            this.labelwidth.Text = "宽度";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(155, 35);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(29, 12);
            this.labelheight.TabIndex = 3;
            this.labelheight.Text = "高度";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(61, 135);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(201, 21);
            this.textBoxDir.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "保存";
            // 
            // saveFileDir
            // 
            this.saveFileDir.Location = new System.Drawing.Point(294, 135);
            this.saveFileDir.Name = "saveFileDir";
            this.saveFileDir.Size = new System.Drawing.Size(49, 24);
            this.saveFileDir.TabIndex = 7;
            this.saveFileDir.Text = "…";
            this.saveFileDir.UseVisualStyleBackColor = true;
            this.saveFileDir.Click += new System.EventHandler(this.saveFileDir_Click);
            // 
            // combWidth
            // 
            this.combWidth.FormattingEnabled = true;
            this.combWidth.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1000",
            "2000"});
            this.combWidth.Location = new System.Drawing.Point(61, 35);
            this.combWidth.Name = "combWidth";
            this.combWidth.Size = new System.Drawing.Size(57, 20);
            this.combWidth.TabIndex = 8;
            // 
            // combHeight
            // 
            this.combHeight.FormattingEnabled = true;
            this.combHeight.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1000",
            "2000"});
            this.combHeight.Location = new System.Drawing.Point(205, 35);
            this.combHeight.Name = "combHeight";
            this.combHeight.Size = new System.Drawing.Size(57, 20);
            this.combHeight.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "圆形",
            "三角形",
            "正方形",
            "六边形",
            "随机"});
            this.comboBox1.Location = new System.Drawing.Point(61, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "形状";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "相等",
            "随机",
            "正态分布",
            "偏态分布"});
            this.comboBox2.Location = new System.Drawing.Point(204, 80);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(57, 20);
            this.comboBox2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "大小";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 254);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combHeight);
            this.Controls.Add(this.combWidth);
            this.Controls.Add(this.saveFileDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelheight);
            this.Controls.Add(this.labelwidth);
            this.Controls.Add(this.btnGen);
            this.Name = "ImageRandom";
            this.Text = "ImageGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveFileDir;
        private System.Windows.Forms.ComboBox combWidth;
        private System.Windows.Forms.ComboBox combHeight;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}