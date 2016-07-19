using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace GeoVar {
    public partial class ImageRandom : Form {
        public ImageRandom() {
            InitializeComponent();
        }

        private void saveFileDir_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "保存到……";
            savefile.Filter = "BMP文件(*.bmp)|*.bmp|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";

            if (savefile.ShowDialog() == DialogResult.OK) {
                textBoxDir.Text = savefile.FileName;
            }
        }
   
        private void btnGen_Click(object sender, EventArgs e) {
            int width = Convert.ToInt32(combWidth.Text);
            int height = Convert.ToInt32(combHeight.Text);
            int rad = 30;       //生成圆的大小
            string savePath = textBoxDir.Text;        //文件保存路径

            Graphics g =this.CreateGraphics();
            Random r = new Random();
            Bitmap bmp = new Bitmap(width, height);   //内存里创建位图
            Graphics gBmp = Graphics.FromImage(bmp);

            gBmp.FillRectangle(Brushes.White, 0,0,width,height);    //绘制背景
            int num = (height*width) / (rad*rad);//数量
            //图像绘制
            for (int i = 0; i < num; i++) {
                gBmp.FillEllipse(Brushes.Black, r.Next(width- rad), r.Next(height- rad), rad, rad);
            }

            //保存
            if (true) {//确定参数选项不为空
                bmp.Save(savePath, ImageFormat.Bmp);
            }
         
            bmp.Dispose();
            MessageBox.Show("图像生成成功！","生成");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
