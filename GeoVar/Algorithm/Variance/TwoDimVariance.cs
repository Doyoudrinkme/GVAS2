using GeoVar.pTool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoVar.Algorithm.Variance {
    public partial class TwoDimVariance : Form {
        public TwoDimVariance() {
            InitializeComponent();
        }
        double[] var2;//逐行方差
        double[] avg;//逐行均值
        private void btnImportData_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\MyDesktop\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "BMP文件(*.bmp)|*.bmp|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                tBoxImportData.Text = openFileDialog.FileName;
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "计算结果保存到……";
            savefile.Filter = "txt文件(*.txt)|*.txt|xlsx文件(*.xlsx)|*.xlsx";
            if (savefile.ShowDialog() == DialogResult.OK) {
                tBoxExportResult.Text = savefile.FileName;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e) {
            tBoxImportData.Text = "D:\\MyDesktop\\";
            cbxVarOrg.Text = "横向";
            //tBoxExportResult.Text = "D:\\MyDesktop\\VarResult.txt";
            tBoxExportResult.Text = tBoxImportData.Text;
        }

        private void btnClear_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text != null || cbxVarOrg.Text != null
               || tBoxExportResult.Text != null) {
                tBoxImportData.Text = "";
                cbxVarOrg.Text = "";
                tBoxExportResult.Text = "";
            }
        }
       
        Bitmap image;
        private void VarCal_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text == "" || cbxVarOrg.Text == "" || tBoxExportResult.Text == "") {
                MessageBox.Show("请输入完整的参数和存储路径！", "逐行方差计算");
                return;         //退出函数
            }
            image = new Bitmap(tBoxImportData.Text, true);     //读入图片
            int x, y;
            int[,] idata = new int[image.Width, image.Height];      //存储像元值，用于计算
            string[,] sdata = new string[image.Width, image.Height];//存储像元值，用于写出

            InterpreProBar iterprePB = new InterpreProBar(0, image.Width);//数据解析进度
            iterprePB.Show();
            // 二值化
            for (x = 0; x < image.Width; x++) {
                iterprePB.SetProgressValue(x);
                for (y = 0; y < image.Height; y++) {
                    Color pixelColor = image.GetPixel(x, y);
                    idata[x, y] = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    if (idata[x, y] != 0) {
                        idata[x, y] = 0;
                    }
                    else {
                        idata[x, y] = 1;
                    }
                }
            }
            iterprePB.Close();
            avg = new double[idata.GetLength(1)];
            var2 = new double[idata.Length];//存储每行的方差
            //逐行方差计算
            for (int line = 0; line < idata.GetLength(0); line++) {             
                double sum = 0;//均值与数组元素值得差的平方和
                avg[line] = average2D(idata, line);
                for (int j = 0; j < idata.GetLength(1); j++) {
                    sum += Math.Pow(idata[line, j] - avg[line], 2);
                }
                var2[line] = sum / idata.GetLength(1);
            }
            //结果输出变异结果
            string path = tBoxExportResult.Text;        //存储路径
            using (FileStream fs = File.Create(path)) {
                AddText(fs, "行号    均值     方差  \r\n");
                for (int i = 0; i < idata.GetLength(0); i++) {
                    AddText(fs, String.Format("{0,6:D6}", i) + "  " +
                                String.Format("{0:N6}", avg[i]) + "  " +
                                String.Format("{0:N6}", var2[i]) + "\r\n ");
                }
            }
            MessageBox.Show("逐行方差计算完成！", "方差计算");
            this.Dispose();
        }
        private static void AddText(FileStream fs, string value) {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private static double average2D(int[,] arr, int line) {
            double sum = 0;
            double avg = 0;
            for (int j = 0; j < arr.GetLength(1); j++) {
                sum += arr[line, j];
            }
            avg = sum / arr.GetLength(1);
            return avg;
        }
    }
}
