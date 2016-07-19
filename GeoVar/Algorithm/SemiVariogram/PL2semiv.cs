using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.SystemUI;

using System.Diagnostics;

namespace GeoVar {
    public partial class PL2semiv : Form
    {
        private Stopwatch stw = new Stopwatch();  
        static FormMain frm;
        public PL2semiv(FormMain frmm)  {
            InitializeComponent();
            frm = frmm;
        }

        private void button6_Click(object sender, EventArgs e)   {
            this.Dispose();
        }

        int minnum, maxnum, k;//默认值

        private void btnChooseDir_Click(object sender, EventArgs e) {

        }

        private void btnCaculate_Click(object sender, EventArgs e) {
            FolderBrowserDialog m_FolderBrowserDialog = new FolderBrowserDialog();
            string m_DataPathName = "";
            string m_DataName = "";
            string parentPath = "";
            if (m_DataPathName != ""|| m_DataName != ""|| parentPath != "") {
                m_DataPathName = m_FolderBrowserDialog.SelectedPath;
                DirectoryInfo m_DirectoryInfo = new DirectoryInfo(m_DataPathName);
                m_DataName = m_DirectoryInfo.Name;
                DirectoryInfo pDirectoryInfo = m_DirectoryInfo.Parent;
                parentPath = pDirectoryInfo.FullName;
            }
            textBox3.Text = m_DataPathName;

            stw.Start();

            string jieguo2;
            for (int i = 0; i < frm.mainMapControl.LayerCount; i++) {
                string inputname = frm.mainMapControl.get_Layer(i).Name;
                int location2 = inputname.LastIndexOf('.');
                string sss2 = inputname;
                jieguo2 = sss2.Substring(0, location2);////"."后文件名称
                IRasterLayer pRasterLayer = frm.mainMapControl.get_Layer(i) as IRasterLayer;
                IRaster2 raster = pRasterLayer.Raster as IRaster2;
                IRasterDataset rasterDataset = raster.RasterDataset;
                IPnt pixelBlockOrigin  = new DblPntClass();
                pixelBlockOrigin.SetCoords(0, 0);
                IRasterBandCollection dirBandCollection = (IRasterBandCollection)rasterDataset;
                IRasterBand dirRasterBand = dirBandCollection.Item(0);
                IRawPixels dirRawPixels = (IRawPixels)dirRasterBand;
                IRasterProps dirProps = (IRasterProps)dirRawPixels;

                int dirColumns = dirProps.Width;                      //列数
                int dirRows = dirProps.Height;                        //行数
                double cellSizeX = dirProps.MeanCellSize().X;         //得到x方向栅格大小
                double cellSizeY = dirProps.MeanCellSize().Y;         //得到y方向栅格大小
                IPnt dirBlockSize = new DblPntClass();
                dirBlockSize.X = dirColumns;
                dirBlockSize.Y = dirRows;
                IPixelBlock3 dirPixelBlock = (IPixelBlock3)dirRawPixels.CreatePixelBlock(dirBlockSize);
                dirRawPixels.Read(pixelBlockOrigin, (IPixelBlock)dirPixelBlock);
                System.Array array = (System.Array)dirPixelBlock.get_PixelDataByRef(0);

                string ss = "";
                double[,] b = new double[dirRows, dirColumns];
                for (int row = 0; row < dirRows; row++)
                    for (int col = 0; col < dirColumns; col++) {
                        b[row, col] = Convert.ToSingle(array.GetValue(col, row));/////得到按行排列的值，注意这个为GetValue(col, row))
                    }

                if (textBox3.Text == "")
                    MessageBox.Show("文件保存名不能为空");

                String savename = textBox3.Text + "\\" + jieguo2 + ".txt";
                for (int c = 0; c < maxnum; c++) {
                    double sum, mean, a;//修改程序2012年7月27日 
                    a = 0;
                    sum = 0;
                    mean = 0;

                    if (cbBDirection.Text == "左边--->右边") {
                        for (int row = 0; row < dirRows; row++) {////窗口大小与图像行列数关系               
                            for (int col = 0; col < dirColumns - k; col++) {////窗口大小与图像行列数关系
                                sum +=Math.Pow((b[row, col] - b[row, col + k]) ,2);
                                a = a + 1;
                            }
                        }
                    }
                    if (cbBDirection.Text == "上边--->下边") {
                        for (int row = 0; row < dirRows- k; row++) {////窗口大小与图像行列数关系               
                            for (int col = 0; col < dirColumns ; col++) {////窗口大小与图像行列数关系
                                sum = sum + Math.Pow((b[row, col] - b[row+ k, col ]),2);
                                a = a + 1;
                            }
                        }
                    }
                    if (cbBDirection.Text == "左下--->右上") {
                        for (int row = 0; row < dirRows - k; row++) {////窗口大小与图像行列数关系               
                            for (int col = 0; col < dirColumns - k; col++) {////窗口大小与图像行列数关系
                                sum += Math.Pow((b[row, col] - b[row + k, col + k]) ,2);
                                a = a + 1;
                            }
                        }
                    }
                    if (cbBDirection.Text == "左上--->右下") {
                        for (int row = 0; row < dirRows - k; row++)////窗口大小与图像行列数关系               
                            for (int col = 0; col < dirColumns - k; col++) {////窗口大小与图像行列数关系
                                sum +=Math.Pow((b[row, col + k] - b[row + k, col]),2);
                                a = a + 1;
                            }
                    }         
                    mean = sum / (2 * a);
                    ss += mean + " " + a + " " + k + "\r\n";

                    String Strsavefile = savename;
                    StreamWriter sw = new StreamWriter(Strsavefile);
                    sw.WriteLine(ss);
                    sw.Close();
                    k = k + 1;
                }
            }
            stw.Stop();
            MessageBox.Show("程序共运行时间:" + stw.Elapsed.Minutes.ToString() + "分钟" + stw.Elapsed.Seconds.ToString() + "秒");
        }

        private void btnDefault_Click(object sender, EventArgs e) {
            if (textBox1.Text == "")
                minnum = 2;
            else
                minnum = Convert.ToInt32(textBox1.Text);

            if (textBox2.Text == "")
                maxnum = 1;
            else
                maxnum = Convert.ToInt32(textBox2.Text);
            k = minnum;
        }
    }
}
