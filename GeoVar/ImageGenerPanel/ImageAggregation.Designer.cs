namespace GeoVar {
    partial class ImageAggregation {
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
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combHeight = new System.Windows.Forms.ComboBox();
            this.combWidth = new System.Windows.Forms.ComboBox();
            this.saveFileDir = new System.Windows.Forms.Button();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelheight = new System.Windows.Forms.Label();
            this.labelwidth = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "相等",
            "随机",
            "正态分布",
            "偏态分布"});
            this.comboBox2.Location = new System.Drawing.Point(219, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(57, 20);
            this.comboBox2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "大小";
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
            this.comboBox1.Location = new System.Drawing.Point(76, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 20);
            this.comboBox1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "形状";
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
            this.combHeight.Location = new System.Drawing.Point(220, 33);
            this.combHeight.Name = "combHeight";
            this.combHeight.Size = new System.Drawing.Size(57, 20);
            this.combHeight.TabIndex = 22;
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
            this.combWidth.Location = new System.Drawing.Point(76, 33);
            this.combWidth.Name = "combWidth";
            this.combWidth.Size = new System.Drawing.Size(57, 20);
            this.combWidth.TabIndex = 21;
            // 
            // saveFileDir
            // 
            this.saveFileDir.Location = new System.Drawing.Point(309, 133);
            this.saveFileDir.Name = "saveFileDir";
            this.saveFileDir.Size = new System.Drawing.Size(49, 24);
            this.saveFileDir.TabIndex = 20;
            this.saveFileDir.Text = "…";
            this.saveFileDir.UseVisualStyleBackColor = true;

            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(76, 133);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(201, 21);
            this.textBoxDir.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "保存";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(170, 33);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(29, 12);
            this.labelheight.TabIndex = 17;
            this.labelheight.Text = "高度";
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(27, 33);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(29, 12);
            this.labelwidth.TabIndex = 16;
            this.labelwidth.Text = "宽度";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(309, 182);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(49, 28);
            this.btnGen.TabIndex = 15;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            // 
            // ImageAggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 358);
            this.Controls.Add(this.button2);
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
            this.Name = "ImageAggregation";
            this.Text = "ImageAggregation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combHeight;
        private System.Windows.Forms.ComboBox combWidth;
        private System.Windows.Forms.Button saveFileDir;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Button btnGen;
    }
}