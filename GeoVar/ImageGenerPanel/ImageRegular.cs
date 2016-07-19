using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace GeoVar {
    public partial class ImageRegular : Form {
        public ImageRegular() {
            InitializeComponent();
        }
        static int count = 0;  //生成图像的序列
        private void saveFileDir_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "保存到……";
            savefile.Filter = "BMP文件(*.bmp)|*.bmp|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";

            if (savefile.ShowDialog() == DialogResult.OK) {
                textBoxDir.Text = savefile.FileName;
            }
        }
        //默认参数
        private void btnParDefault_Click(object sender, EventArgs e) {
            combWidth.Text ="800";
            combHeight.Text = "800";
            cbBEleShape.Text = "圆形";
            cbBEleSize.Text = "1/8分块大小";
            cbBPartNum.Text = "8";
            cbBCenterDistance.Text = "块内随机";
            cbBEleNum.Text = "1";
            textBoxDir.Text = "D:\\MyDesktop\\Image";
        }
        //参数重置
        private void btnReset_Click(object sender, EventArgs e) {
            combWidth.Text = "";
            combHeight.Text = "";
            cbBEleShape.Text = "";
            cbBEleSize.Text = "";
            cbBPartNum.Text = "";
            cbBCenterDistance.Text = "";
            cbBEleNum.Text = "";
            textBoxDir.Text = "";
        }

        //图像生成
        private void btnGen_Click(object sender, EventArgs e) {   
            int pWidth = Convert.ToInt32(combWidth.Text);   //2000
            int pHeight = Convert.ToInt32(combHeight.Text);

            Bitmap bmp = new Bitmap(pWidth, pHeight);     //内存里创建位图
            Graphics gBmp = Graphics.FromImage(bmp);
            gBmp.FillRectangle(Brushes.White, 0, 0, pWidth, pHeight);//背景设为白色

            int part = Convert.ToInt32(cbBPartNum.Text);      //划分的块数  4 6 8 10 12

            int bWidth  = pWidth /part;     //小块的宽  200
            int bHeight = pHeight/part;    //小块的高


            int eDiameter;  //画圆的半径
            switch (cbBEleSize.Text) {
                case "1/4分块大小":
                    eDiameter = bWidth / 4;           
                    break;
                case "1/8分块大小":
                    eDiameter = bWidth / 8;           
                    break;
                case "1/16分块大小":
                    eDiameter = bWidth / 16;           
                    break;
                default:
                    eDiameter = bWidth / 2;           
                    break;
            }
            
            //每个小块内圆的个数
            double angle =360/Convert.ToInt32(cbBEleNum.Text);  //角度 cbBEleNum

            int radius;      //极坐标的半径  cbBCenterDistance
            switch (cbBCenterDistance.Text) {

                case "1/2分块":
                    radius = bWidth / 2;
                    break;
                case "1/3分块":
                    radius = bWidth / 3;
                    break;
                case "1/4分块":
                    radius = bWidth / 4;
                    break;
                case "1/5分块":
                    radius = bWidth / 5;
                    break;
                case "1/8分块":
                    radius = bWidth / 8;
                    break;
                case "块内随机":
                    radius = bWidth;
                    break;
                default:
                    radius = bWidth / 2;
                    break;
            }
            int ox = bWidth / 2;          //第一块小块的中心
            int oy = bHeight /2;

            Random r = new Random();
            for (int x = 0; x <part; x++) {
                for (int y = 0; y <part; y++) {
                    int oox = ox * x * 2 + ox;      //其他小块的中心
                    int ooy = oy * y * 2 + oy;      //其他小块的中心
                    gBmp.FillEllipse(Brushes.Red, oox, ooy, eDiameter, eDiameter);//小块中心的圆

                    for (int i = 0; i < 8; i++) {  //画8个圆
                        int rd = r.Next(radius);
                        float pX = (float)(rd * Math.Cos(i * angle * Math.PI / 180) + oox);
                        float pY = (float)(rd * Math.Sin(i * angle * Math.PI / 180) + ooy);
                        gBmp.FillEllipse(Brushes.Black, pX, pY, eDiameter, eDiameter);
                    }
                }
            } 
            //保存文件
            bmp.Save(textBoxDir.Text + Convert.ToString(count++) + ".bmp", ImageFormat.Bmp);
            bmp.Dispose();
            MessageBox.Show("图像生成成功！");
            this.Dispose();
        }
    }

}
