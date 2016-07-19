using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;

namespace ObjSize3 {
    class Program {
        static void Main(string[] args) {
            // String path = "D:\\MyDesktop\\Mapdata\\Image圆直径(31)离心距(31).bmp";
            //  String path = "D:\\MyDesktop\\Mapdata\\Image圆直径(12)离心距(12).bmp";
            // String path = "D:\\MyDesktop\\Mapdata\\Image3圆直径(25)离心距(25).bmp";
            String path = "D:\\MyDesktop\\Mapdata\\test2.bmp";
            Bitmap image = new Bitmap(path, true);     //读入图片

            int[,] idata = BinMap(image);     // 二值化  
                                              // string datapath= "D:\\MyDesktop\\Mapdata\\ImageBin.txt";//保存路径
            string datapath = "D:\\MyDesktop\\ImageBin.txt";//保存路径
            saveBinMap(datapath, idata);

            //提取每行的元素
            /*
             * 计算：
             * 行号 地物和背景的均值/方差    地物均值/方差   背景均值/方差
             */
            double[] bavg = new double[image.Height];//存储每行背景的均值
            double[] oavg = new double[image.Height];

            double[] bvar = new double[image.Height];//存储每行背景的方差
            double[] ovar = new double[image.Height];//

            double[] OBvar = new double[image.Height];//存储每行的方差
            double[] OBavg = new double[image.Height];//存储每行的均值

            for (int i = 0; i < image.Height; i++) {//逐行计算
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

                OBavg[i] = OBsum / (bcnt + ocnt);
                Console.WriteLine("OBavg[" + i + "]=" + OBavg[i]);

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
                Console.WriteLine("OBvar[" + i + "]=" + OBvar[i]);
                bvar[i] = bs / bcnt;
                ovar[i] = os / ocnt;

                Console.WriteLine("bvar[" + i + "]=" + bvar[i]);
                Console.WriteLine("ovar[" + i + "]=" + ovar[i]);

                Console.WriteLine("bavg[" + i + "]=" + bavg[i]);
                Console.WriteLine("oavg[" + i + "]=" + oavg[i]);

                //写出计算结果
                String rpath = "D:\\MyDesktop\\cacuResult.txt";//保存路径
                saveCacuResult(rpath, bavg, bvar, oavg, ovar, OBavg, OBvar);

            }
            Console.ReadKey();
        }

        private static void saveCacuResult(string path, double[] bavg, double[] bvar, double[] oavg, double[] ovar, double[] OBavg, double[] OBvar) {
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
            }
        }

        private static void saveBinMap(string datapath, int[,] data) {
            using (FileStream fs = File.Create(datapath)) {
                for (int y = 0; y < data.GetLength(1); y++) {//
                    for (int x = 0; x < data.GetLength(0); x++) {   //width
                        AddText(fs, Convert.ToString(data[x, y]));
                    }
                    AddText(fs, " \r\n");
                }
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
                for (int i = ob; i < data.GetLength(0) - 1; i++) {//二值数据的每行最后一个数据是空格，所以要减1
                    //Console.WriteLine("line=" + line);
                    //Console.WriteLine("i=" + i);
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
            Console.WriteLine();
            //根据实际的段数创建整型数据返回，便于计算
            int[] size2 = new int[size.Count];
            for (int i = 0; i < size.Count; i++) {
                size2[i] = (int)size[i];
                Console.Write(size2[i] + " ");
            }
            Console.WriteLine();
            return size2;
        }
        //图像二值化
        private static int[,] BinMap(Bitmap image) {
            int[,] idata = new int[image.Width, image.Height];      //存储像元值，用于计算
            for (int x = 0; x < image.Width; x++) {
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
            return idata;
        }
    }
}
