namespace GeoVar.ImageGenerPanel {
    partial class ImageRegularToRandom {
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
            this.btnParDefault = new System.Windows.Forms.Button();
            this.cbBCenterDistance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBPartNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btnParDefault
            // 
            this.btnParDefault.Location = new System.Drawing.Point(83, 252);
            this.btnParDefault.Name = "btnParDefault";
            this.btnParDefault.Size = new System.Drawing.Size(49, 28);
            this.btnParDefault.TabIndex = 56;
            this.btnParDefault.Text = "默认";
            this.btnParDefault.UseVisualStyleBackColor = true;
            this.btnParDefault.Click += new System.EventHandler(this.btnParDefault_Click);
            // 
            // cbBCenterDistance
            // 
            this.cbBCenterDistance.FormattingEnabled = true;
            this.cbBCenterDistance.Items.AddRange(new object[] {
            "分块中心",
            "1 /8分块",
            "2 /8分块",
            "3 /8分块",
            "4 /8分块"});
            this.cbBCenterDistance.Location = new System.Drawing.Point(264, 116);
            this.cbBCenterDistance.Name = "cbBCenterDistance";
            this.cbBCenterDistance.Size = new System.Drawing.Size(112, 20);
            this.cbBCenterDistance.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 52;
            this.label6.Text = "圆心距离";
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
            this.cbBPartNum.Location = new System.Drawing.Point(93, 113);
            this.cbBPartNum.Name = "cbBPartNum";
            this.cbBPartNum.Size = new System.Drawing.Size(57, 20);
            this.cbBPartNum.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "整幅分块";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(209, 252);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(49, 28);
            this.btnReset.TabIndex = 49;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbBEleSize
            // 
            this.cbBEleSize.FormattingEnabled = true;
            this.cbBEleSize.Items.AddRange(new object[] {
            "1/2分块大小",
            "1/3分块大小",
            "1/4分块大小",
            "1/5分块大小",
            "1/6分块大小",
            "1/7分块大小",
            "1/8分块大小",
            "随机大小"});
            this.cbBEleSize.Location = new System.Drawing.Point(264, 68);
            this.cbBEleSize.Name = "cbBEleSize";
            this.cbBEleSize.Size = new System.Drawing.Size(112, 20);
            this.cbBEleSize.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "元素大小";
            // 
            // cbBEleShape
            // 
            this.cbBEleShape.FormattingEnabled = true;
            this.cbBEleShape.Items.AddRange(new object[] {
            "圆形",
            "三角形",
            "正方形",
            "六边形"});
            this.cbBEleShape.Location = new System.Drawing.Point(93, 68);
            this.cbBEleShape.Name = "cbBEleShape";
            this.cbBEleShape.Size = new System.Drawing.Size(57, 20);
            this.cbBEleShape.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 45;
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
            this.combHeight.Location = new System.Drawing.Point(264, 20);
            this.combHeight.Name = "combHeight";
            this.combHeight.Size = new System.Drawing.Size(112, 20);
            this.combHeight.TabIndex = 44;
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
            this.combWidth.Location = new System.Drawing.Point(93, 20);
            this.combWidth.Name = "combWidth";
            this.combWidth.Size = new System.Drawing.Size(57, 20);
            this.combWidth.TabIndex = 43;
            // 
            // saveFileDir
            // 
            this.saveFileDir.Location = new System.Drawing.Point(316, 203);
            this.saveFileDir.Name = "saveFileDir";
            this.saveFileDir.Size = new System.Drawing.Size(49, 24);
            this.saveFileDir.TabIndex = 42;
            this.saveFileDir.Text = "…";
            this.saveFileDir.UseVisualStyleBackColor = true;
            this.saveFileDir.Click += new System.EventHandler(this.saveFileDir_Click);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(83, 203);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(201, 21);
            this.textBoxDir.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "保存";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(205, 23);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(53, 12);
            this.labelheight.TabIndex = 39;
            this.labelheight.Text = "图幅高度";
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(34, 23);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(53, 12);
            this.labelwidth.TabIndex = 38;
            this.labelwidth.Text = "图幅宽度";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(316, 252);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(49, 28);
            this.btnGen.TabIndex = 37;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // ImageRegularToRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 352);
            this.Controls.Add(this.btnParDefault);
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
            this.Name = "ImageRegularToRandom";
            this.Text = "ImageRegularToRandom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParDefault;
        private System.Windows.Forms.ComboBox cbBCenterDistance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBPartNum;
        private System.Windows.Forms.Label label5;
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
    }
}