using GeoVar.pTool;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MSExcel = Microsoft.Office.Interop.Excel;
namespace GeoVar.ImageGenerPanel {
    public partial class GetLineObjectSize : Form {
        public GetLineObjectSize() {
            InitializeComponent();
        }
        SaveFileDialog savefile = new SaveFileDialog();
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
        
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "计算结果保存到……";
            savefile.Filter = "txt文件(*.txt)|*.txt|xlsx文件(*.xlsx)|*.xlsx";
            if (savefile.ShowDialog() == DialogResult.OK) {
                tBoxExportResult.Text = savefile.FileName;
            }
        }
        private void btnDefault_Click(object sender, EventArgs e) {
            tBoxImportData.Text = "D:\\MyDesktop\\";
            tBoxExportResult.Text = "D:\\MyDesktop\\";
        }

        private void btnClear_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text != null || tBoxExportResult.Text != null) {
                tBoxImportData.Text = "";
                tBoxExportResult.Text = "";
            }
        }
        private void VarCal_Click(object sender, EventArgs e) {
            if (tBoxImportData.Text == "" || tBoxExportResult.Text == "") {
                MessageBox.Show("请输入完整的参数和存储路径！", "逐行提取对象大小");
                return;         //退出函数
            }
            Bitmap image = new Bitmap(tBoxImportData.Text, true);      //读入图片
            InterpreProBar iterprePB = new InterpreProBar(0, image.Width);//数据解析进度
            int[,] idata = BinMap(image, iterprePB);     // 二值化  

            //提取每行的元素 计算：地物和背景的均值/方差    地物均值/方差   背景均值/方差
            double[] bavg = new double[image.Height];//存储每行背景的均值
            double[] oavg = new double[image.Height];

            double[] bvar = new double[image.Height];//存储每行背景的方差
            double[] ovar = new double[image.Height];

            double[] OBvar = new double[image.Height];//存储每行的方差
            double[] OBavg = new double[image.Height];//存储每行的均值

            double[] cyclevar = new double[image.Height];//存储每行的方差
            double[] cycleavg = new double[image.Height];//存储每行的均值


            CacuProBar progressForm = new CacuProBar("逐行方差均值计算",0, image.Height); //计算进度    
            progressForm.Show();//开始显示计算进度

            for (int i = 0; i < image.Height; i++) {//逐行计算
                progressForm.SetProgressValue(i);
                int[] obasize = objBacSizeLine(i, idata);
                int bcnt = 0, ocnt = 0;
                double bsum = 0; double osum = 0; double OBsum = 0;
                //分别计算地物和背景的方差均值
                for (int j = 0; j < obasize.Length; j++) {
                    OBsum += obasize[j];
                    if (idata[0, i] == 0) {//如果第一个是背景 0    010101010
                        if (j % 2 == 0) {  //偶数下标就是背景bac长度
                            bsum += obasize[j];
                            bcnt++;
                        }
                        else {              //奇数数下标就是地物obj长度
                            osum += obasize[j];
                            ocnt++;
                        }
                    }
                    else {                 //如果第一个是背景 1    101010101
                        if (j % 2 == 0) {  //偶数下标就是地物obj长度
                            osum += obasize[j];
                            ocnt++;
                        }
                        else {
                            bsum += obasize[j];
                            bcnt++;
                        }
                    }
                }
                progressForm.Close();
                OBavg[i] = OBsum / (bcnt + ocnt);
                bavg[i] = bsum / bcnt;
                oavg[i] = osum / ocnt;

                double os = 0;//obj均值与数组元素值得差的平方和
                double bs = 0;//bac均值与数组元素值得差的平方和
                double OBs = 0;//bac均值与数组元素值得差的平方和

                //计算地物和背景的方差     
                for (int j = 0; j < obasize.Length; j++) {
                    OBs += Math.Pow(obasize[j] - OBavg[i], 2);
                    if (idata[0, i] == 0) {//如果第一个是背景 0
                        if (j % 2 == 0) {
                            bs += Math.Pow(obasize[j] - bavg[i], 2);
                        }
                        else {
                            os += Math.Pow(obasize[j] - oavg[i], 2);
                        }
                    }
                    else {                ////如果第一个是地物 1
                        if (j % 2 == 0) {
                            os += Math.Pow(obasize[j] - oavg[i], 2);
                        }
                        else {
                            bs += Math.Pow(obasize[j] - bavg[i], 2);
                        }
                    }
                }
                OBvar[i] = OBs / (bcnt + ocnt);
                bvar[i] = bs / bcnt;
                ovar[i] = os / ocnt;

                //计算黑白周期长度的均值和方差 
                for (int j = 0; j < obasize.Length; j++) {
                  
                    if (idata[0, i] == 0) {//如果第一个是背景 0
                        if (j % 2 == 0) {
                            bs += Math.Pow(obasize[j] - bavg[i], 2);
                        }
                        else {
                            os += Math.Pow(obasize[j] - oavg[i], 2);
                        }
                    }
                    else {                ////如果第一个是地物 1
                        if (j % 2 == 0) {
                            os += Math.Pow(obasize[j] - oavg[i], 2);
                        }
                        else {
                            bs += Math.Pow(obasize[j] - bavg[i], 2);
                        }
                    }
                }

            }
            String str= tBoxExportResult.Text;
            //写出计算结果
            if (str.Substring(str.LastIndexOf('.'),3+1)==".txt") {//包头不包尾
                saveCacuResultAsText(tBoxExportResult.Text, bavg, bvar, oavg, ovar, OBavg, OBvar);
            }
            else {
                saveCacuResultAsExcel(tBoxExportResult.Text, bavg, bvar, oavg, ovar, OBavg, OBvar);
            }

            MessageBox.Show("OK,计算和保存完成！", "逐行提取对象大小");
            this.Dispose();
        }

        private void saveCacuResultAsExcel(string path, double[] bavg, double[] bvar, double[] oavg, double[] ovar, double[] OBavg, double[] OBvar) {
            CacuProBar progressForm = new CacuProBar("写入excel", 0, bavg.Length); //计算进度  
            progressForm.Show();
            MSExcel.Application excelApp;//Excel 应用程序变量
            MSExcel.Workbook excelDoc;//Excel文档变量

            excelApp = new MSExcel.ApplicationClass();//初始化
            if (File.Exists(path)) {
                File.Delete(path);
            }

            //由于使用的是COM库，因此许多变量需要用misspara代替
            Object misspara = Missing.Value;
            excelDoc = excelApp.Workbooks.Add(misspara);
            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range类型的变量r
            MSExcel.Range r1, r2, r3, r4, r5, r6, r7;
            r1 = ws.get_Range("A2", "A2");//获取A2处的表格，并赋值
            r2 = ws.get_Range("B2", "B2");//获取A2处的表格，并赋值
            r3 = ws.get_Range("C2", "C2");//获取A2处的表格，并赋值
            r4 = ws.get_Range("D2", "D2");//获取A2处的表格，并赋值
            r5 = ws.get_Range("E2", "E2");//获取A2处的表格，并赋值
            r6 = ws.get_Range("F2", "F2");//获取A2处的表格，并赋值
            r7 = ws.get_Range("G2", "G2");//获取A2处的表格，并赋值

            r1.Value2 = "行号";
            r2.Value2 = "背景均值";
            r3.Value2 = "背景方差";
            r4.Value2 = "地物均值";
            r5.Value2 = "地物方差";
            r6.Value2 = "混合均值";
            r7.Value2 = "混合方差 ";

            for (int i = 3; i < bavg.Length + 3; i++) {//行  , , , 
                progressForm.SetProgressValue(i);
                ws.Cells[i, 1] =(i-3).ToString();//行号
                ws.Cells[i, 2] = String.Format("{0,12:F3}", bavg[i - 3]);
                ws.Cells[i, 3] = String.Format("{0,12:F3}", bvar[i - 3]);
                ws.Cells[i, 4] = String.Format("{0,12:F3}", oavg[i - 3]);
                ws.Cells[i, 5] = String.Format("{0,12:F3}", ovar[i - 3]);
                ws.Cells[i, 6] = String.Format("{0,12:F3}", OBavg[i - 3]);
                ws.Cells[i, 7] = String.Format("{0,12:F3}", OBvar[i - 3]);

            }
            progressForm.Close();
            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookDefault;
            //将excelDoc文档对象的内容保存为XLSX
            excelDoc.SaveAs(path, format, misspara, misspara, misspara, misspara,
                            MSExcel.XlSaveAsAccessMode.xlExclusive,
                            misspara, misspara, misspara, misspara, misspara);
            //关闭excelDoc文档对象
            excelDoc.Close(misspara, misspara, misspara);
            //关闭excelApp组件对象
            excelApp.Quit();
        }

        private static void saveCacuResultAsText(string path, double[] bavg, double[] bvar, double[] oavg, double[] ovar, double[] OBavg, double[] OBvar) {
            CacuProBar progressForm = new CacuProBar("写入txt", 0, bavg.Length); //计算进度 
            progressForm.Show();
            int i = 0;//记录行号
            using (FileStream fs = File.Create(path)) {
                AddText(fs,
                      String.Format("{0,3}", "行号") +
                      String.Format("{0,11}", "背景均值") +
                      String.Format("{0,11}", "背景方差") +
                      String.Format("{0,11}", "地物均值") +
                      String.Format("{0,11}", "地物方差") +
                      String.Format("{0,11}", "混合均值") +
                      String.Format("{0,11}", "混合方差")
                     );
                AddText(fs, " \r\n");
                for (int x = 0; x < bavg.GetLength(0); x++) {
                    progressForm.SetProgressValue(x);
                    AddText(fs,
                        String.Format("{0,3}", i++) + "   " +
                        String.Format("{0,12:F3}", bavg[x]) + "   " +
                        String.Format("{0,12:F3}", bvar[x]) + "   " +
                        String.Format("{0,12:F3}", oavg[x]) + "   " +
                        String.Format("{0,12:F3}", ovar[x]) + "   " +
                        String.Format("{0,12:F3}", OBavg[x]) + "   " +
                        String.Format("{0,12:F3}", OBvar[x]));
                    AddText(fs, " \r\n");
                }
                progressForm.Close();
            }
        }
        private static void AddText(FileStream fs, string value) {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        //获取每一行地物和背景的大小
        public static int[] objBacSizeLine(int line, int[,] data) {
            ArrayList size = new ArrayList(10);//存储相邻的背景和元素长度 
            int t = 0;//存储所有段数的总和，等于总长度时，每一行的循环终止
            int partSize = 0;//记录每一段
            int ob = 0;//ob 存储下一次比较的起点

            //取每一行元素的个数
            while (t < data.GetLength(0)) {
                for (int i = ob; i < data.GetLength(0) - 1; i++) {
                    //每行判断
                    if (data[i, line] == data[i + 1, line]) {
                        partSize++;
                    }
                    else {
                        ob = i + 1;
                        break;
                    }
                }
                /*  size.Add((++partSize));//将每一段的长度赋给数组
                 *  自增的原因：获取每段的长度是通过相邻两个元素相减为0来判断
                 *  每次相减为0 则计数自增1，但是真正的长度还要再次加1
                 *  如 111  相邻两个相减为0，计数自增为2，但是长度还要再加1才是长度
                 */
                size.Add((++partSize));
                t += (partSize + 1);//循环终止条件，每次累加，等于总长时循环终止
                partSize = 0;
            }
            //根据实际的段数创建整型数据返回，便于计算
            int[] size2 = new int[size.Count];
            for (int i = 0; i < size.Count; i++) {
                size2[i] = (int)size[i];
            }
            return size2;
        }
        //图像二值化
        private static int[,] BinMap(Bitmap image, InterpreProBar iterprePB) {
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
    }



}


