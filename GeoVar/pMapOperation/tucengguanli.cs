using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesFile;
using System.Runtime.InteropServices;


namespace GeoVar {
    public partial class dianchazhi : Form
    {
        
        static FormMain frm;
        public int layerindex = -1;
        //IMapControl3 m_mapControl;
        public dianchazhi(FormMain frmm) {
            InitializeComponent();
            frm = frmm;
        }


        private void dianchazhi_Load(object sender, EventArgs e)  {//读入图层名
            ///加载打开的所有文件名到listBox中
            for (int i = 0; i < frm.mainMapControl.LayerCount; i++)
                listBox1.Items.Add(frm.mainMapControl.get_Layer(i).Name);
        }

        private void button1_Click(object sender, EventArgs e)  {
            //存储打开文件的全路径
            string fullFilePath;
            //设置OpenFileDialog的属性，使其能打开多种类型文件
            OpenFileDialog openFile = new OpenFileDialog();            
            openFile.Filter = "shape文件(*.shp)|*.shp|栅格数据(*.img,*.tiff)|*.img;*.tiff|Personal Geodatabase(*.mdb)|*.mdb|地图文档(*.mxd)|*.mxd|All Files(*.*)|*.*";

            openFile.Title = "打开文件";
            try  {
                if (openFile.ShowDialog() == DialogResult.OK) {
                    fullFilePath = openFile.FileName;
                    //获得文件路径
                    int index = fullFilePath.LastIndexOf("\\");
                    string filePath = fullFilePath.Substring(0, index);
                    int loc2 = fullFilePath.LastIndexOf(".");
                    //获得文件名称
                    string fileNam = fullFilePath.Substring(index + 1);
                    //加载shape文件
                    if (openFile.FilterIndex == 1)  {
                        //打开工作空间工厂
                        IWorkspaceFactory workspcFac = new ShapefileWorkspaceFactory();
                        IFeatureWorkspace featureWorkspc;
                        IFeatureLayer featureLay = new FeatureLayerClass();
                        //打开路径
                        featureWorkspc = workspcFac.OpenFromFile(filePath, 0) as IFeatureWorkspace;
                        //打开类要素
                        featureLay.FeatureClass = featureWorkspc.OpenFeatureClass(fileNam);
                        String fname;
                        fname = fullFilePath.Substring(index + 1, loc2 - index - 1);
                        listBox1.Items.Insert(0, fname);
                        frm.mainMapControl.ClearLayers();//////注意与主函数MainForm中区别，此处要加"frm."
                        //添加图层
                        frm.mainMapControl.AddLayer(featureLay);//////注意与主函数MainForm中区别，此处要加"frm."
                        frm.mainMapControl.Refresh();//////注意与主函数MainForm中区别，此处要加"frm."                                         

                    }
                    //加载栅格图像
                    else if (openFile.FilterIndex == 2)   {
                        IWorkspaceFactory workspcFac = new RasterWorkspaceFactory();
                        IRasterWorkspace rasterWorkspc;
                        IRasterDataset rasterDatst = new RasterDatasetClass();
                        IRasterLayer rasterLay = new RasterLayerClass();
                        rasterWorkspc = workspcFac.OpenFromFile(filePath, 0) as IRasterWorkspace;
                        rasterDatst = rasterWorkspc.OpenRasterDataset(fileNam);
                        rasterLay.CreateFromDataset(rasterDatst);
                        String fname= fullFilePath.Substring(index + 1, loc2 - index - 1);
                        listBox1.Items.Insert(0, fname);
                        ////////frm.axMapControl1.ClearLayers();//////注意与主函数MainForm中区别，此处要加"frm."
                        //添加图层
                        frm.mainMapControl.AddLayer(rasterLay);//////注意与主函数MainForm中区别，此处要加"frm."
                        frm.mainMapControl.Refresh();//////注意与主函数MainForm中区别，此处要加"frm."   
                    }
                    //加载地图文档
                    else if (openFile.FilterIndex == 3)  {
                        IMapDocument mapDoc = new MapDocumentClass();
                        mapDoc.Open(filePath, "");
                        frm.mainMapControl.ClearLayers();//////注意与主函数MainForm中区别，此处axMapControl1前要加"frm."
                        for (int i = 0; i < mapDoc.MapCount - 1; i++)   {
                            frm.mainMapControl.Map = mapDoc.get_Map(i);
                        }
                        IActiveView activeViw = frm.mainMapControl.Map as IActiveView;
                        activeViw.Extent = frm.mainMapControl.FullExtent;
                        frm.mainMapControl.Refresh();
                    }
                }

            }
            catch (Exception ex)    {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)   {
            frm.mainMapControl.ClearLayers();//////注意与主函数MainForm中区别，此处要加"frm."
            listBox1.Items.Clear();
            ////绑定图例控件
            frm.axTOCControl.Update();/////用updata,实现清除
            frm.mainMapControl.Refresh();//////注意与主函数MainForm中区别，此处要加"frm.
        }
        //////////////图层上移
        private void button2_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex > 0)   {
                int i;
                i = listBox1.SelectedIndex;
               frm.mainMapControl.MoveLayerTo(i, i - 1);
                //地图刷新
                frm.axTOCControl.Update();/////用updata,实现清除
                frm.mainMapControl.Refresh();//////注意与主函数MainForm中区别，此处要加"frm.
                //list控件内的两个元素位置交换
                String tstring = listBox1.Items[i].ToString();
                listBox1.Items[i] = listBox1.Items[i - 1].ToString();
                listBox1.Items[i - 1] = tstring;
                listBox1.SelectedIndex = i - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            //判断选择中图层使否可移动
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1 && listBox1.SelectedIndex > -1)  {
                int i;
                i = listBox1.SelectedIndex;
                frm.mainMapControl.MoveLayerTo(i, i + 1);
                //地图刷新
                frm.mainMapControl.Update();/////用updata,实现清除
                frm.mainMapControl.Refresh();//////注意与主函数MainForm中区别，此处要加"frm.
                //list控件内的两个元素位置交换
                String tstring;
                tstring = listBox1.Items[i].ToString();
                listBox1.Items[i] = listBox1.Items[i + 1].ToString();
                listBox1.Items[i + 1] = tstring;
                listBox1.SelectedIndex = i + 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)  {
            if (listBox1.SelectedIndex > -1)   {
                frm.mainMapControl.DeleteLayer(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                frm.mainMapControl.Update();/////用updata,实现清除
            }
        }

    }

}


