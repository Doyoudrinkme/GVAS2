namespace GeoVar {
    partial class ImageRegular {
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
            this.btnReset = new System.Windows.Forms.Button();
            this.cbBEleSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBEleShape = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combHeight = new System.Windows.Forms.ComboBox();
            this.combWidth = new System.Windows.Forms.ComboBox();
            this.saveFileDir = new System.Windows.Forms.Button();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelheight = new System.Windows.Forms.Label();
            this.labelwidth = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.cbBPartNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBCenterDistance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBEleNum = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnParDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(217, 288);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(49, 28);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbBEleSize
            // 
            this.cbBEleSize.FormattingEnabled = true;
            this.cbBEleSize.Items.AddRange(new object[] {
            "1/4分块大小",
            "1/8分块大小",
            "1/16分块大小"});
            this.cbBEleSize.Location = new System.Drawing.Point(272, 104);
            this.cbBEleSize.Name = "cbBEleSize";
            this.cbBEleSize.Size = new System.Drawing.Size(112, 20);
            this.cbBEleSize.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "元素大小";
            // 
            // cbBEleShape
            // 
            this.cbBEleShape.FormattingEnabled = true;
            this.cbBEleShape.Items.AddRange(new object[] {
            "圆形",
            "三角形",
            "正方形",
            "六边形",
            "随机"});
            this.cbBEleShape.Location = new System.Drawing.Point(101, 104);
            this.cbBEleShape.Name = "cbBEleShape";
            this.cbBEleShape.Size = new System.Drawing.Size(57, 20);
            this.cbBEleShape.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "元素形状";
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
            this.combHeight.Location = new System.Drawing.Point(272, 56);
            this.combHeight.Name = "combHeight";
            this.combHeight.Size = new System.Drawing.Size(112, 20);
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
            this.combWidth.Location = new System.Drawing.Point(101, 56);
            this.combWidth.Name = "combWidth";
            this.combWidth.Size = new System.Drawing.Size(57, 20);
            this.combWidth.TabIndex = 21;
            // 
            // saveFileDir
            // 
            this.saveFileDir.Location = new System.Drawing.Point(324, 239);
            this.saveFileDir.Name = "saveFileDir";
            this.saveFileDir.Size = new System.Drawing.Size(49, 24);
            this.saveFileDir.TabIndex = 20;
            this.saveFileDir.Text = "…";
            this.saveFileDir.UseVisualStyleBackColor = true;
            this.saveFileDir.Click += new System.EventHandler(this.saveFileDir_Click);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(91, 239);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(201, 21);
            this.textBoxDir.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "保存";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(213, 59);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(53, 12);
            this.labelheight.TabIndex = 17;
            this.labelheight.Text = "图幅高度";
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(42, 59);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(53, 12);
            this.labelwidth.TabIndex = 16;
            this.labelwidth.Text = "图幅宽度";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(324, 288);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(49, 28);
            this.btnGen.TabIndex = 15;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // cbBPartNum
            // 
            this.cbBPartNum.FormattingEnabled = true;
            this.cbBPartNum.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cbBPartNum.Location = new System.Drawing.Point(101, 149);
            this.cbBPartNum.Name = "cbBPartNum";
            this.cbBPartNum.Size = new System.Drawing.Size(57, 20);
            this.cbBPartNum.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "整幅分块";
            // 
            // cbBCenterDistance
            // 
            this.cbBCenterDistance.FormattingEnabled = true;
            this.cbBCenterDistance.Items.AddRange(new object[] {
            "1/2分块",
            "1/3分块",
            "1/4分块",
            "1/5分块",
            "1/8分块",
            "块内随机"});
            this.cbBCenterDistance.Location = new System.Drawing.Point(272, 152);
            this.cbBCenterDistance.Name = "cbBCenterDistance";
            this.cbBCenterDistance.Size = new System.Drawing.Size(112, 20);
            this.cbBCenterDistance.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "圆心距离";
            // 
            // cbBEleNum
            // 
            this.cbBEleNum.FormattingEnabled = true;
            this.cbBEleNum.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.cbBEleNum.Location = new System.Drawing.Point(272, 197);
            this.cbBEleNum.Name = "cbBEleNum";
            this.cbBEleNum.Size = new System.Drawing.Size(112, 20);
            this.cbBEleNum.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "块内个数";
            // 
            // btnParDefault
            // 
            this.btnParDefault.Location = new System.Drawing.Point(91, 288);
            this.btnParDefault.Name = "btnParDefault";
            this.btnParDefault.Size = new System.Drawing.Size(49, 28);
            this.btnParDefault.TabIndex = 36;
            this.btnParDefault.Text = "默认";
            this.btnParDefault.UseVisualStyleBackColor = true;
            this.btnParDefault.Click += new System.EventHandler(this.btnParDefault_Click);
            // 
            // ImageRegular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(454, 375);
            this.Controls.Add(this.btnParDefault);
            this.Controls.Add(this.cbBEleNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBCenterDistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbBPartNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbBEleSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBEleShape);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combHeight);
            this.Controls.Add(this.combWidth);
            this.Controls.Add(this.saveFileDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelheight);
            this.Controls.Add(this.labelwidth);
            this.Controls.Add(this.btnGen);
            this.Name = "ImageRegular";
            this.Text = "ImageRegular";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbBEleSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBEleShape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combHeight;
        private System.Windows.Forms.ComboBox combWidth;
        private System.Windows.Forms.Button saveFileDir;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.ComboBox cbBPartNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBCenterDistance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBEleNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnParDefault;
    }
}