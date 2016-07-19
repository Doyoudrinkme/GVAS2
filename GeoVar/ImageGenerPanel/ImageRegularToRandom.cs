using GeoVar.cElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoVar.ImageGenerPanel {
    public partial class ImageRegularToRandom : Form {
        public ImageRegularToRandom() {
            InitializeComponent();
        }
        int eDiameter;  //画圆的半径
        int radius;      //极坐标的半径  cbBCenterDistance
        ElemShape eleshp = new ElemShape();//生成不同形状的元素

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
            combWidth.Text = "2000";
            combHeight.Text = "2000";
            cbBEleShape.Text = "圆形";
            cbBEleSize.Text = "1/8分块大小";
            cbBPartNum.Text = "8";
            cbBCenterDistance.Text = "1/8分块";
            textBoxDir.Text = "D:\\MyDesktop\\Mapdata\\image.bmp";
        }
        //参数重置
        private void btnReset_Click(object sender, EventArgs e) {
            combWidth.Text = "";
            combHeight.Text = "";
            cbBEleShape.Text = "";
            cbBEleSize.Text = "";
            cbBPartNum.Text = "";
            cbBCenterDistance.Text = "";
            textBoxDir.Text = "";
        }
        //图像生成
        private void btnGen_Click(object sender, EventArgs e) {
            if (combWidth.Text==null||combHeight.Text== null || cbBEleShape.Text==""||
                cbBPartNum.Text==""||cbBCenterDistance.Text==""||textBoxDir.Text==""){
                MessageBox.Show("请将参数输入完整", "参数输入");
            }
            else {
                int pWidth = Convert.ToInt32(combWidth.Text);   //2000
                int pHeight = Convert.ToInt32(combHeight.Text);
                Bitmap bmp = new Bitmap(pWidth, pHeight);     //内存里创建位图
                Graphics gBmp = Graphics.FromImage(bmp);
                gBmp.FillRectangle(Brushes.White, 0, 0, pWidth, pHeight);//背景设为白色
                int part = Convert.ToInt32(cbBPartNum.Text);      //划分的块数  4 6 8 10 12
                int bWidth = pWidth / part;     //小块的宽  200
                int bHeight = pHeight / part;    //小块的高

                Random r = new Random();  
                switch (cbBEleSize.Text) {
                    case "1/2分块大小":
                        eDiameter = bWidth / 2;
                        break;
                    case "1/3分块大小":
                        eDiameter = bWidth / 3;
                        break;
                    case "1/4分块大小":
                        eDiameter = bWidth / 4;
                        break;
                    case "1/5分块大小":
                        eDiameter = bWidth / 5;
                        break;
                    case "1/6分块大小":
                        eDiameter = bWidth / 6;
                        break;
                    case "1/7分块大小":
                        eDiameter = bWidth / 7;
                        break;
                    case "1/8分块大小":
                        eDiameter = bWidth / 8;
                        break;
                    case "随机大小":
                        eDiameter = bWidth/2;//分块内循环随机决定大小
                        break;
                    default:
                        eDiameter = bWidth / 2;
                        break;
                }
                //角度 cbBEleNum
                double angle = 30;  //角度 cbBEleNum
                switch (cbBCenterDistance.Text) {
                    case "分块中心":
                        radius = 0;
                        break;
                    case "1 /8分块":
                        radius =1* bWidth / 8;
                        break;
                    case "2 /8分块":
                        radius =2 * bWidth / 8;
                        break;
                    case "3 /8分块":
                        radius =3 * bWidth / 8;
                        break;
                    case "4 /8分块":
                        radius =4 * bWidth / 8;        
                        break;
                    default:
                        radius = bWidth / 8;
                        break;
                }
                int ox = bWidth / 2;          //第一块小块的中心
                int oy = bHeight/ 2;
                for (int x = 0; x <part; x++) {
                    for (int y = 0; y <part; y++) {
                        int oox = ox * x * 2 + ox;      //其他小块的中心
                        int ooy = oy * y * 2 + oy;      //其他小块的中心
                        //做一个判断，生成规则分布
                        //gBmp.FillEllipse(Brushes.Red, oox-25, ooy-25, 50, 50);//小块中心的圆

                        // int rd = r.Next(radius- rdeDiameter);//画圆半径大小随机
                        int rd = radius/r.Next(1,6);//画圆极坐标半径大小随机
                        int rd2 = r.Next(13);//随机角度 随机数不取上限 12保证取30为间隔 的圆周分布

                        float pX = (float)(rd * Math.Cos(rd2 * angle) + oox);
                        float pY = (float)(rd * Math.Sin(rd2 * angle) + ooy);

                        if (cbBEleSize.Text == "随机大小") {//元素圆半径随机 通过除以 3，4，5实现 除数过大过小都不好         
                            int rdeDiameter = eDiameter / r.Next(1, 4);//yuan随机 3 4 5

                            if (cbBEleShape.Text == "圆形") {
                                gBmp.FillEllipse(Brushes.Black, pX - rdeDiameter/2, pY - rdeDiameter/2, rdeDiameter, rdeDiameter);
                            }
                            if (cbBEleShape.Text == "六边形") {
                                eleshp.FillHexagon(Brushes.Black, bmp, gBmp, pX - rdeDiameter/2, pY - rdeDiameter/2, rdeDiameter, rdeDiameter);
                            }
                            if (cbBEleShape.Text == "正方形") {
                                eleshp.FillSquare(Brushes.Black, bmp, gBmp, pX - rdeDiameter / 2, pY - rdeDiameter / 2, rdeDiameter, rdeDiameter);
                            }
                            if (cbBEleShape.Text == "三角形") {
                                eleshp.FillTriangle(Brushes.Black, bmp, gBmp, pX - rdeDiameter / 2, pY - rdeDiameter / 2, rdeDiameter, rdeDiameter);
                            }
                        }
                       else {
                            if (cbBEleShape.Text == "圆形") {
                                gBmp.FillEllipse(Brushes.Black, pX - eDiameter / 2, pY - eDiameter / 2, eDiameter, eDiameter);
                            }
                            if (cbBEleShape.Text == "六边形") {
                                eleshp.FillHexagon(Brushes.Black, bmp, gBmp, pX - eDiameter / 2, pY - eDiameter / 2, eDiameter, eDiameter);
                            }
                            if (cbBEleShape.Text == "正方形") {
                                eleshp.FillSquare(Brushes.Black, bmp, gBmp, pX- eDiameter / 2, pY - eDiameter / 2, eDiameter, eDiameter);
                            }
                            if (cbBEleShape.Text == "三角形") {
                                eleshp.FillTriangle(Brushes.Black, bmp, gBmp, pX - eDiameter / 2, pY - eDiameter / 2, eDiameter, eDiameter);
                            }
                        }
                    }
                }
                //保存文件
                //if (!File.Exists(textBoxDir.Text)) {
                //   File.Create(textBoxDir.Text);
                //}
                string filePath = textBoxDir.Text;
                string fileName = "直径(" + Convert.ToString(eDiameter) + ")离心距("
                                                + Convert.ToString(radius) + ").bmp";
                string meteDataName = "直径(" + Convert.ToString(eDiameter) + ")离心距("
                                                + Convert.ToString(radius) + ").txt";
                bmp.Save(filePath + fileName, ImageFormat.Bmp);

                //输出元数据
                string datapath = filePath+ meteDataName;        //存储路径
                meteDataOut(datapath);//元数据输出   
                bmp.Dispose();
                MessageBox.Show("图像生成成功！");
              //  this.Dispose();
            }
        }
        //元数据写出
        private void meteDataOut(String datapath) {
            try {
                FileStream aFile = new FileStream(datapath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                //写出数据
                sw.WriteLine("行    数："+ combHeight.Text );
                sw.WriteLine("列    数："+ combWidth.Text );
                sw.WriteLine("元素形状："+ cbBEleShape.Text);

                sw.WriteLine("元素直径：" + Convert.ToString(eDiameter));
                sw.WriteLine("分块数量：" + cbBPartNum.Text+"×"+ cbBPartNum.Text);
                sw.WriteLine("块心距离：" + Convert.ToString(radius));

                sw.WriteLine();
                sw.Close();
            }
            catch (IOException) {
                MessageBox.Show("元数据生成失败！");
            }         
        }
      


    }
}
