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

namespace GeoVar
{
    public partial class ALVjisuan : Form
    {
        static FormMain frm;
        public ALVjisuan(FormMain frmm)
        {
            InitializeComponent();
            frm = frmm;
        }

        private void ALVjisuan_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < frm.axMapControl1.LayerCount; i++)
            //    comboBox1.Items.Add(frm.axMapControl1.get_Layer(i).Name);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            string jieguo2;
            for (int i = 0; i < frm.mainMapControl.LayerCount; i++)
            {               

            string inputname = frm.mainMapControl.get_Layer(i).Name;
            int location2 = inputname.LastIndexOf('.');
            string sss2 = inputname;
            jieguo2 = sss2.Substring(0, location2);////"."后文件名称
            IRasterLayer pRasterLayer = frm.mainMapControl.get_Layer(i) as IRasterLayer;
          
            IRaster2 raster = pRasterLayer.Raster as IRaster2;            
            System.Array array;            
            IRasterDataset rasterDataset = raster.RasterDataset;
            IPoint pPointOrign = new PointClass();
            pPointOrign.X = 0;
            pPointOrign.Y = 0;
            IPnt pixelBlockOrigin = null;
            pixelBlockOrigin = new DblPntClass();
            pixelBlockOrigin.SetCoords(pPointOrign.X, pPointOrign.Y);
            IRasterBandCollection dirBandCollection = (IRasterBandCollection)rasterDataset;
            IRasterBand dirRasterBand = dirBandCollection.Item(0);
            IRawPixels dirRawPixels = (IRawPixels)dirRasterBand;
            IRasterProps dirProps = (IRasterProps)dirRawPixels;
            int dirColumns = dirProps.Width;                      //列数
            int dirRows = dirProps.Height;                        //行数
            double cellSizeX = dirProps.MeanCellSize().X;         //得到x方向栅格大小
            double cellSizeY = dirProps.MeanCellSize().Y;         ////得到y方向栅格大小
            IPnt dirBlockSize = new DblPntClass();
            dirBlockSize.X = dirColumns;
            dirBlockSize.Y = dirRows;
            IPixelBlock3 dirPixelBlock = (IPixelBlock3)dirRawPixels.CreatePixelBlock(dirBlockSize);
            dirRawPixels.Read(pixelBlockOrigin, (IPixelBlock)dirPixelBlock);
            array = (System.Array)dirPixelBlock.get_PixelDataByRef(0);

            string ss = "";
            double[,] b = new double[dirRows, dirColumns];
            for (int row = 0; row < dirRows; row++) {
                    for (int col = 0; col < dirColumns; col++)  {
                    b[row, col] = Convert.ToSingle(array.GetValue(col, row));
                }
             }
            int minnum, maxnum, chuangkou;
            
            if (textBox1.Text == "") minnum = 2;
            else minnum = Convert.ToInt32(textBox1.Text);

            if (textBox2.Text == "") maxnum =1;
            else maxnum = Convert.ToInt32(textBox2.Text);
            chuangkou = minnum;

    
            if (textBox3.Text == "")
                MessageBox.Show("文件保存名不能为空");    

            String savename = textBox3.Text+"\\"+jieguo2+".txt";

            for (int c = 0; c < maxnum; c++)  {
                double result, sum, mean, fangcha, ste, a;////////修改程序2011年11月15日
                a = 0;
                ste = 0;
                sum = 0;
                fangcha = 0;
       
                for (int row = 0; row < dirRows - chuangkou + 1; row++)////窗口大小与图像行列数关系               
                    for (int col = 0; col < dirColumns - chuangkou + 1; col++)////窗口大小与图像行列数关系
                    {
                        for (int k = row; k < row + chuangkou; k++)////窗口大小与图像栅格和的关系
                            for (int l = col; l < col + chuangkou; l++)
                            {
                                sum = sum + b[k, l];
                            }
                        mean = sum / (chuangkou * chuangkou);

                        for (int m = row; m < row + chuangkou; m++)
                            for (int n = col; n < col + chuangkou; n++)
                            {

                                fangcha = fangcha + (b[m, n] - mean) * (b[m, n] - mean);
                            }

                        result = System.Math.Sqrt(fangcha / (chuangkou * chuangkou));

                        fangcha = 0;
                        sum = 0;
                        ste = ste + result;
                        a = a + 1;
                    }               
                //ss += ste / a + "    " + chuangkou + "\r\n";
                ss += ste / a + "    " + a + "    " + ste+"\r\n";
                //string varString = Convert.ToString(chuangkou);

                //////////////////////////////////////////////////////////////////////////
                ///////////////改写内容
                String Strsavefile;
                Strsavefile = savename;
                ////////FileStream fs = new FileStream(Strsavefile);

                StreamWriter sw = new StreamWriter(Strsavefile);
                sw.WriteLine(ss);
                sw.Close();
                //////////////////////////////////////////////////////////////////////////                
                chuangkou = chuangkou + 1;
                //MessageBox.Show(varString,"OK");                
                //this.Hide();
            } 
        }
           MessageBox.Show("OK");
           this.Hide();//////点击ok后计算窗口消失

        }
        
        private void button2_Click(object sender, EventArgs e)  {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //////SaveFileDialog fileChooser = new SaveFileDialog();
            //////fileChooser.Title = "保存文件";
            //////fileChooser.Filter = "文本文件(*.txt)|*.txt";
            //////DialogResult result = fileChooser.ShowDialog();
            //////if (result == DialogResult.Cancel)
            //////    return;
            //////string fileName;
            //////fileName = fileChooser.FileName;
            //////textBox3.Text = fileName;
            FolderBrowserDialog m_FolderBrowserDialog = new FolderBrowserDialog();
            string m_DataPathName = "";
            string m_DataName = "";
            string parentPath = "";
            if (m_FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                m_DataPathName = m_FolderBrowserDialog.SelectedPath;
                DirectoryInfo m_DirectoryInfo = new DirectoryInfo(m_DataPathName);
                m_DataName = m_DirectoryInfo.Name;
                DirectoryInfo pDirectoryInfo = m_DirectoryInfo.Parent;
                parentPath = pDirectoryInfo.FullName;
            }
            textBox3.Text = m_DataPathName;
        }
    }
}