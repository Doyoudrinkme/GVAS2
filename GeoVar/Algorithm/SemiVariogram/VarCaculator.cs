using GeoVar.pTool;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GeoVar {
    public partial class VarCaculator : Form {
        public VarCaculator() {
            InitializeComponent();
        }

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
        //选择保存计算结果的位置
        private void btnSaveResult_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "计算结果保存到……";
            savefile.Filter = "txt文件(*.txt)|*.txt|xlsx文件(*.xlsx)|*.xlsx";
            if (savefile.ShowDialog() == DialogResult.OK) {
                tBoxExportResult.Text = savefile.FileName;
            }
        }
        //默认参数
        private void btnDefault_Click(object sender, EventArgs e) {
            tBoxImportData.Text = "D:\\MyDesktop\\";
            cbxVarOrg.Text = "W-->E";
            cbBMaxLag.Text = "1/8图幅";
            radioButtonYes.Checked = true;
            cbxVarMapOrLine.Text = "逐行";
            cbxSmoothWindowSize.Text = "0";
            tBLag.Text = "1";
            tBoxExportResult.Text = "D:\\MyDesktop\\semivar.txt";
            tBoxBinMap.Text = "D:\\MyDesktop\\bina.txt";
        }

        //设置二值数据存储路径
        private void btnBinMapSaveDir_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "图像二值保存到……";
            savefile.Filter = "txt文件(*.txt)|*.txt|xlsx文件(*.xlsx)|*.xlsx";
            if (savefile.ShowDialog() == DialogResult.OK) {
                tBoxBinMap.Text = savefile.FileName;
            }
        }
        //重置参数
        private void btnClear_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text != null || cbxVarOrg.Text != null ||
                cbBMaxLag.Text != null || tBLag.Text != null || tBoxExportResult.Text != null) {
                tBoxImportData.Text = "";
                cbxVarOrg.Text = "";
                cbBMaxLag.Text = "";
                tBLag.Text = "";
                tBoxExportResult.Text = "";
                tBoxBinMap.Text = "";
            }
        }

        //变异计算
        Bitmap image;
        int maxlag;        //最大变异距离
        private void VarCal_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text == "" || cbxVarOrg.Text == "" ||
                cbBMaxLag.Text == "" || tBLag.Text == "" || tBoxExportResult.Text == "") {
                MessageBox.Show("请输入完整的参数和存储路径！", "逐行变异计算");
                return;         //退出函数
            }
            image = new Bitmap(tBoxImportData.Text, true);     //读入图片
            int[,] idata = new int[image.Width, image.Height];      //存储像元值，用于计算

            switch (cbBMaxLag.Text) {
                case "1/2图幅":
                    maxlag = image.Width / 2;           //参数lag  为变异距离
                    break;
                case "1/4图幅":
                    maxlag = image.Width / 4;           //参数lag  为变异距离
                    break;
                case "1/8图幅":
                    maxlag = image.Width / 8;           //参数lag  为变异距离
                    break;
                default:
                    maxlag = image.Width / 2;           //参数lag  为变异距离
                    break;
            }
            //存储逐行变异值
            double[,] dResult = new double[image.Height, maxlag];
            string[,] sResult = new string[image.Height, maxlag];

            //存储全幅变异值
            double []dMResult = new double[maxlag];

            InterpreProBar iterprePB = new InterpreProBar(0, image.Width);//数据解析进度
            idata = BinMap(image, iterprePB);     // 二值化  

            //输出二值图像二值数据
            string datapath = tBoxBinMap.Text;        //存储路径
            if (radioButtonYes.Checked) {
                saveBinMap(idata,datapath, image);
            }

            //变异计算
            CacuProBar progressForm = new CacuProBar("变异计算", 0, maxlag); //变异计算进度              
            progressForm.Show();//开始显示计算进度
        
            for (int h = 1; h < maxlag; h++) {           //变异滞后距离
                progressForm.SetProgressValue(h);
                //全幅计算
                int cn = 0;     //记录运算次数
                double sum = 0; //滞后距离差的平方和

                if (cbxVarMapOrLine.Text.Trim() == "全幅") {
                    if (cbxVarOrg.Text == "W-->E") {
                        for (int row = 0; row < image.Height; row++) {////窗口大小与图像行列数关系               
                            for (int col = 0; col < image.Width - h; col++) {////窗口大小与图像行列数关系
                                sum += Math.Pow((idata[row, col] - idata[row, col + h]), 2);
                                cn = cn + 1;
                            }
                        }
                    }
                  
                    if (cbxVarOrg.Text == "N-->S") {

                    }

                    if (cbxVarOrg.Text == "WS-->EN") {

                    }
                    if (cbxVarOrg.Text == "WN-->ES") {

                    }
                    dMResult[h] = sum / (2 * cn);

               }
               else if (cbxVarMapOrLine.Text == "逐行") {                //单行横向计算
                    if (cbxVarOrg.Text == "W-->E") {
                        double n = 0;           //计算次数         
                        ArrayList p = new ArrayList();         //以h为滞后距离的差的平方                         
                        for (int j = 0; j < image.Height; ++j) {       //每行变异   
                            double pp = 0;                     //差的平方的和
                            for (int i= 0; i < image.Width - h;i++) { //最大变异宽幅
                                p.Add(Math.Pow(idata[i, j] - idata[i+ h, j ], 2));
                                pp += (Double)p[i];      //将h为滞后距离的差的平方相加
                            }
                            p.Clear();
                            n = image.Width - h;
                            dResult[j, h] = pp / (2 * n);
                        }
                    }

                    if (cbxVarOrg.Text == "N-->S") {

                    }

                    if (cbxVarOrg.Text == "WS-->EN") {

                    }
                    if (cbxVarOrg.Text == "WN-->ES") {

                    }
                }
              
            }
            progressForm.Close();

            //写出计算结果
            if (cbxVarMapOrLine.Text == "逐行") {

                //平滑消除小波动
                smoothSemiVar(dResult, Convert.ToInt32(cbxSmoothWindowSize.Text));

                //提取变异前5个峰值和谷值
                double[,] semiPeekMax = new double[image.Height, 5];
                double[,] semiPeekMin = new double[image.Height, 5];
                //提取峰值所在的索引
                int[,] semiPeekMaxIndex = new int[image.Height, 5];
                int[,] semiPeekMinIndex = new int[image.Height, 5];

                semiPeekMax =getSemiVarPeekMax(dResult);
                semiPeekMin=getSemiVarPeekMin(dResult);

                semiPeekMaxIndex = getSemiVarPeekMaxIndex(dResult);
                semiPeekMinIndex = getSemiVarPeekMinIndex(dResult);

              

                saveLineCacuResultAsText(tBoxExportResult.Text, dResult, semiPeekMaxIndex, semiPeekMinIndex, semiPeekMax, semiPeekMin);
            }
            else if (cbxVarMapOrLine.Text == "全幅") {
                saveMapCacuResultAsText(tBoxExportResult.Text, dMResult);
            }
            MessageBox.Show("变异计算完成！", "变异计算");
            this.Dispose();
        }
        
        private void smoothSemiVar(double[,] dResult, int v) {
            if (v == 0) {
                return;
            }
            if (v==3) {
                for (int x = 0; x < image.Height; x++) {
                    for (int y = 1; y < maxlag - 1; y++) {
                        dResult[x, y] = (dResult[x, y - 1] + dResult[x, y] + dResult[x, y + 1]) / 3;
                    }
                } 
            }
         

        }

        //输出逐行变异值
        private void saveLineCacuResultAsText(string path, double[,] dResult, int[,] semiPeekMaxIndex, int[,] semiPeekMinIndex, double[,] semiPeekMax, double[,] semiPeekMin) {
            using (FileStream fs = File.Create(path)) {
               //添加行号后，变异值和变异距离错位，添加空格是为了对齐
                for (int x = 1; x < maxlag; x++) {
                    AddText(fs, "  ");
                }
                for (int x = 1; x < maxlag; x++) {
                    AddText(fs, "变距"+x + "  ");
                }
                for (int x = 0; x < 5; x++) {
                    AddText(fs, "下标" + (x+1) + "  ");
                    AddText(fs, "极大值" + (x + 1) + "  ");
                }
                for (int x = 0; x < 5; x++) {
                    AddText(fs, "下标" + (x + 1) + "  ");
                    AddText(fs, "极小值" + (x + 1) + "  ");
                }

                AddText(fs, " \r\n");
                for (int x = 0; x < image.Height; x++) {
                    AddText(fs, "行" + (x + 1) + "  ");
                    for (int y = 1; y < maxlag; y++) {
                        AddText(fs, String.Format("{0:N6}", dResult[x, y]) + "  ");
                    }
                    AddText(fs, "   ");
                    for (int y = 0; y < 5; y++) {
                        AddText(fs, semiPeekMaxIndex[x, y] + "  ");
                        AddText(fs, String.Format("{0:N6}", semiPeekMax[x, y]) + "  ");

                    }
                    AddText(fs, "   ");
                    for (int y = 0; y < 5; y++) {
                        AddText(fs,  semiPeekMinIndex[x, y] + "  ");
                        AddText(fs, String.Format("{0:N6}", semiPeekMin[x, y]) + "  ");
                    }
                    AddText(fs, " \r\n");
                }
            }
        }
        //输出全幅变异的值
        private void saveMapCacuResultAsText(string path, double[] dMResult) {
            using (FileStream fs = File.Create(path)) {
                for (int i = 0; i < dMResult.Length; i++) {
                    AddText(fs, i + " " + String.Format("{0:N6}", dMResult[i]) + "\r\n ");
                }
            }
        }

        //提取变异前5个谷值
        private double[,] getSemiVarPeekMin(double[,] dResult) {
            double[,] semiPeekMin = new double[image.Height, 5];
            for (int j = 0; j < image.Height; j++) { //每一行
                int cnt = 0;//记录获取的极值的个数 
                for (int h = 1; h < maxlag - 1; h++) {
                    if ((dResult[j, h - 1] > dResult[j, h]) &&
                        (dResult[j, h]< dResult[j, h + 1]) && cnt < 5) {
                        semiPeekMin[j, cnt] = dResult[j, h];
                        cnt++;
                    }
                }
            }
            return semiPeekMin;
        }
        //提取变异前5个峰值
        private double[,] getSemiVarPeekMax(double[,] dResult) {
            double[,] semiPeekMax = new double[image.Height, 5];
            for (int j = 0; j < image.Height; j++) { //每一行
                int cnt = 0;//记录获取的极值的个数 
                for (int h = 1; h < maxlag-1; h++) {
                    if ((dResult[j, h - 1] < dResult[j, h]) && 
                        (dResult[j, h] > dResult[j, h + 1]) && cnt < 5) {
                        semiPeekMax[j, cnt] = dResult[j, h];
                        cnt++;
                    }
                }
            }
            return semiPeekMax;
        }
        //获取对应极值的下标，也就是变异函数的滞后距离
        private int[,] getSemiVarPeekMaxIndex(double[,] dResult) {
            int[,] semiPeekMaxIndex = new int[image.Height, 5];
            for (int j = 0; j < image.Height; j++) { //每一行
                int cnt = 0;//记录获取的极值的个数 
                for (int h = 1; h < maxlag - 1; h++) {
                    if ((dResult[j, h - 1] < dResult[j, h]) &&
                        (dResult[j, h] > dResult[j, h + 1]) && cnt < 5) {
                        semiPeekMaxIndex[j, cnt] =h;
                        cnt++;
                    }
                }
            }
            return semiPeekMaxIndex;
        }
        private int[,] getSemiVarPeekMinIndex(double[,] dResult) {
            int[,] semiPeekMinIndex = new int[image.Height, 5];
            for (int j = 0; j < image.Height; j++) { //每一行
                int cnt = 0;//记录获取的极值的个数 
                for (int h = 1; h < maxlag - 1; h++) {
                    if ((dResult[j, h - 1] > dResult[j, h]) &&
                        (dResult[j, h] < dResult[j, h + 1]) && cnt < 5) {
                        semiPeekMinIndex[j, cnt] = h;
                        cnt++;
                    }
                }
            }
            return semiPeekMinIndex;
        }
        private int[,] BinMap(Bitmap image, InterpreProBar iterprePB) {
            iterprePB.Show();
            int[,] idata = new int[image.Width, image.Height];      //存储像元值，用于计算
            for (int x = 0; x < image.Width; x++) {
                iterprePB.SetProgressValue(x);
                for (int y = 0; y < image.Height; y++) {
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
            return idata;
        }

        private void saveBinMap(int [,] idata,string datapath,Bitmap image) {
            using (FileStream fs = File.Create(datapath)) {
            //注意：y和x的循环次序不可相反，否则输出的二值会相对于原图产生90度翻转，
            //以后要是依靠二值图进行验证计算会产生错误的结果
            for (int y = 0; y <  image.Height; y++) {
                for (int x = 0; x <image.Width; x++) {
                       // //  sdata[x, y] = Convert.ToString(idata[x, y]) + " ";
                        AddText(fs, Convert.ToString(idata[x, y]));//观察测试用，没有分隔符
                    }
                    AddText(fs, " \r\n");
                }
            }
        }
        private static void AddText(FileStream fs, string value) {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        //是否保存二值
        private void radioButtonYes_CheckedChanged(object sender, EventArgs e) {
            btnBinMapSaveDir.Enabled = true;
            tBoxBinMap.Enabled = true;
        }
        private void radioButtonNo_CheckedChanged(object sender, EventArgs e) {
            btnBinMapSaveDir.Enabled = false;
            tBoxBinMap.Enabled = false;
        }
    }
}
