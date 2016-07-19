using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;
using Microsoft.VisualBasic;

namespace GeoVar
{
    public partial class FrmNormalizeNew : Form
    {
        private DataTable FilterDataTable = new DataTable();
        IRasterLayer pRasterLayr;
        IRaster pRster;
        static FormMain frm;
        public FrmNormalizeNew(FormMain frmm)   {
            InitializeComponent();
            frm = frmm;
        }

        private void FrmNormalizeNew_Load(object sender, EventArgs e) {
            int i = 0;
            for (i = 0; i <= frm.mainMapControl.LayerCount - 1; i++)  {
                ILayer pLayer = default(ILayer);
                pLayer = frm.mainMapControl.get_Layer(i);

                if (((pLayer) is IRasterLayer)){
                    ComboBoxInLayer.Items.Add(pLayer.Name);
                }
            }
        }

        private void BtnInput_Click(object sender, EventArgs e) {
            string strPath = null;
            //文件名
            var _with1 = DlgOpen;
            _with1.FileName = "";
            _with1.Filter = "GIS（*.lyr）|*.*|GIS（*.img）|*.img|GIS（*.aux）|*.aux|GIS（*.tif）|";
            _with1.FilterIndex = 2;

            if ((DlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)) {
                strPath = DlgOpen.FileName.Trim();
                //获取图层的栅格信息
                IRasterWorkspace pRWS = default(IRasterWorkspace);
                IWorkspaceFactory pWorkspaceFactory = default(IWorkspaceFactory);
                pWorkspaceFactory = new RasterWorkspaceFactory();
                string wsp = null;
                int r = 0;
                int l = 0;
                r = strPath.LastIndexOf("\\");
                l = strPath.LastIndexOf(".");
                wsp = Microsoft.VisualBasic.Strings.Left(strPath, r);
                pRWS = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(wsp, 0);

                try {
                    string sp = null;
                    sp = Microsoft.VisualBasic.Strings.Mid(strPath, r + 2, strPath.Length - r - 1);

                    pRster = pRWS.OpenRasterDataset(sp).CreateDefaultRaster();
                    //打开栅格图层
                    ComboBoxInLayer.Text = sp;
                    ILayer pLayer = default(ILayer);
                    pRasterLayr = new RasterLayer();

                    pRasterLayr.CreateFromRaster(pRster);
                    pLayer = pRasterLayr;
                    frm.mainMapControl.AddLayer(pLayer);
                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            var _with2 = DlgSave;
            _with2.FileName = "";
            _with2.Filter = "栅格数据|*.GRID|GIS（*.aux）|*.aux|GIS（*.img）|*.img|*.tif|*.jpg";
            _with2.FilterIndex = 3;
            _with2.ShowDialog(this);
        }

        private void DlgSave_FileOk(object sender, CancelEventArgs e)  {
            string filePathName = null;
            filePathName = DlgSave.FileName;
            int intLengfilename = filePathName.Length;
            this.TxtBox.Text = DlgSave.FileName.Substring(0, intLengfilename - 5);
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            int i = 0; int j = 0;
            if (string.IsNullOrEmpty(this.ComboBoxInLayer.Text)){
                MessageBox.Show("请选择需要二值化的图层！", "栅格二值化", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int intLyrCount = frm.mainMapControl.LayerCount;

            for (i = 0; i <= intLyrCount - 1; i++) {
                if ((frm.mainMapControl.Map.get_Layer(i).Name == this.ComboBoxInLayer.Text.Trim())) {
                    IRasterLayer pRasterLayer = frm.mainMapControl.get_Layer(i) as IRasterLayer;
                    IRaster2 raster = pRasterLayer.Raster as IRaster2;
                    IRasterDataset rasterDataset = raster.RasterDataset;

                    IRasterBandCollection dirBandCollection = (IRasterBandCollection)rasterDataset;
                    IRasterBand dirRasterBand = dirBandCollection.Item(0);
                    IRawPixels dirRawPixels = (IRawPixels)dirRasterBand;

                    IPnt pixelBlockOrigin = null;
                    IPnt dirBlockSize = new DblPntClass();
                    IRasterProps dirProps = (IRasterProps)dirRawPixels;
                    int dirColumns = dirProps.Width;                      //列数
                    int dirRows = dirProps.Height;                        //行数

                    IPixelBlock3 dirPixelBlock = (IPixelBlock3)dirRawPixels.CreatePixelBlock(dirBlockSize);
                    dirRawPixels.Read(pixelBlockOrigin,(IPixelBlock)dirPixelBlock);

                    System.Array array;
                    array = (System.Array)dirPixelBlock.get_PixelDataByRef(0);//获取栅格数组

                    int min;
                    if (textBox1.Text == "") min = 20;
                    else min = Convert.ToInt32(textBox1.Text);
                    /////获得栅格数据像元值
                    double[,] b = new double[dirRows, dirColumns];
                    double value;
                    string strExcute=null;
                    for (int row = 0; row < dirRows; row++){
                        for (int col = 0; col < dirColumns; col++) {
                            b[row, col] = Convert.ToSingle(array.GetValue(col, row));
                            /////阈值判断
                            if (b[row, col] > min)
                              value=1;  
                            else
                              value=0;
                            strExcute = Convert.ToString(value);
                        }

                    }
                    IGeoDataset tempGeodata1 = (IGeoDataset)pRster;
                    IMapAlgebraOp pMapAlgebraOp = new RasterMapAlgebraOpClass();
                   
                     //设置栅格运算空间
                    IRasterAnalysisEnvironment pRasterAnalysisEnvironment = (IRasterAnalysisEnvironment)pMapAlgebraOp;
                    IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactoryClass();

                    string outPath = null;
                    string outLayerName = null;
                    outPath = this.TxtBox.Text.Trim();
                    j = this.TxtBox.Text.Trim().LastIndexOf("\\");

                    outPath = this.TxtBox.Text.Substring(0, j);
                    outLayerName = this.TxtBox.Text.Substring(j + 1);
                    string DataSetName = this.TxtBox.Text.Substring(j + 1);

                    //设置输出空间
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(outPath, 0);          
                    pRasterAnalysisEnvironment.OutWorkspace = pWorkspace;
                    IGeoDataset outGetDataset = pMapAlgebraOp.Execute(strExcute);
                    IRasterLayer pCreatRalyr = new RasterLayerClass();
                    pCreatRalyr.CreateFromRaster((IRaster)outGetDataset);

                    pCreatRalyr.Name = outLayerName;
                    frm.mainMapControl.AddLayer(pCreatRalyr);
                    break;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)  {
            this.Dispose();
        }
    }
}
