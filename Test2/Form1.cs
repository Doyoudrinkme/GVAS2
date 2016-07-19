using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2 {
    public partial class Form1 : Form {
        private int x=0;
        private Brush brush;
        private object y;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {


            
            // FillTriangle();
            FillTriangle(Brush brush, int x, int y, int width, int height);
        }

        private void FillTriangle(Brush brush, int x, int y, int pWidth, int pHeight) {
            Bitmap bmp = new Bitmap(pWidth, pHeight);     //内存里创建位图
            Graphics g = Graphics.FromImage(bmp);
            GraphicsPath gp = new GraphicsPath();

            //gp.AddLine(20, 0, 40, 40);
            //gp.AddLine(40, 40, 0, 40);
            //gp.AddLine(0, 40, 20, 0);

            gp.AddLine(pWidth/2, 0, pWidth, pHeight);
            gp.AddLine(pWidth, pHeight, 0, pHeight);
            gp.AddLine(0, pHeight, pWidth / 2, 0);

            //以上面勾画的轮廓画图
            Region reg = new Region(gp);
            g.FillRegion(Brushes.Green, reg);
            //  g.DrawPath(Pens.Black, gp);
            reg.Dispose();
            gp.Dispose();
        }
    }
}
