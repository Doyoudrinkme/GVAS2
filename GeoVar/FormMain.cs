
using System;
using System.Windows.Forms;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using GeoVar.ImageGenerPanel;
using GeoVar.Algorithm.Variance;

namespace GeoVar {
    public partial class FormMain : Form {
        #region 变量定义
        //地图导出窗体
        private ExportMapForm frExpMap;
        private string sMapUnits = "未知单位";          //地图单位变量
        private object missing = Type.Missing;
        //TOCC菜单
        IFeatureLayer pTocFeatureLayer = null;//点击的要素图层
      //  private FormAtrribute frmAttribute = null;//图层属性窗体
        private ILayer pMoveLayer;//需要调整显示顺序的图层
        private int toIndex;                    //存放拖动图层移动到的索引号

        //鹰眼同步
        private bool bCanDrag;                  //鹰眼地图上的矩形框可移动的标志
        private IPoint pMoveRectPoint;          //记录在移动鹰眼地图上的矩形框时鼠标的位置
        private IEnvelope pEnv;                 //记录数据视图的Extent
        #endregion

        #region 初始化

        public FormMain()  {
            InitializeComponent();
            axTOCControl.SetBuddyControl(mainMapControl);
            EagleEyeMapControl.Extent = mainMapControl.FullExtent;
            pEnv = EagleEyeMapControl.Extent;
            DrawRectangle(pEnv);
        }
        #endregion

        #region 数据加载

        private void MxFileLoad_Click(object sender, EventArgs e) {
            //加载数据之前如果有数据则清空
            try {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "打开地图文档";
                openFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd;|ArcMap模板(*.mxt|*.mxt)|发布地图文件(*.pmf)|*.pmf|所有地图格式(*.mxd;*.mxt;*.pmf)|*.mxd;*.mxt;*.pmf";
                openFileDialog.Multiselect = false;//           不允许多个文件同时选择
                openFileDialog.RestoreDirectory = true;         //存储打开的文件路径
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = openFileDialog.FileName;
                    if (fileName == "") {
                        return;
                    }
                    if (mainMapControl.CheckMxFile(fileName))    //检查地图文档的有效性
                    {
                        // ClearAllData();
                        mainMapControl.LoadMxFile(fileName);
                        SynchronizedEagleEye();
                    }
                    else {
                        MessageBox.Show(fileName + "是无效地图文档！", "信息提示");
                        return;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("打开地图文档失败！" + ex.Message);
            }
        }

        private void RasterfileLoad_Click(object sender, EventArgs e) {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开Raster文件";
            pOpenFileDialog.Filter = "栅格文件(*.*)|*.bmp;*.tif;*.jpg;*.img|(*.bmp)|*.bmp|(*.tif)|*.tif)|(*.jpg)|*.jpg|(*.img)|*.img";
            pOpenFileDialog.ShowDialog();

            string pRasterFileName = pOpenFileDialog.FileName;
            if (pRasterFileName == "")
                return;
            string pPath = System.IO.Path.GetDirectoryName(pRasterFileName);
            string pFileName = System.IO.Path.GetFileName(pRasterFileName);

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pPath, 0);
            IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);

            //影像金字塔的判断和创建
            IRasterPyramid3 pRasPyramid = pRasterDataset as IRasterPyramid3;
            if (pRasPyramid != null) {
                if (!(pRasPyramid.Present))
                    pRasPyramid.Create();           //创建金字塔
            }
            IRaster pRaster = pRasterDataset.CreateDefaultRaster();
            IRasterLayer pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromRaster(pRaster);
            ILayer pLayer = pRasterLayer as ILayer;
            mainMapControl.AddLayer(pLayer, 0);
        }

        private void TxtfileLoad_Click(object sender, EventArgs e) {

        }

        private void ShapefileLoad_Click(object sender, EventArgs e) {
            //ClearAllData();
            try {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "打开Shape文件";
                openFileDialog.Filter = "Shape文件(*.shp)|*.shp";
                openFileDialog.ShowDialog();

                //获取文件路径
                //FileInfo pFileInfo = new FileInfo(openFileDialog.FileName);
                //string path = openFileDialog.FileName.Substring(0, openFileDialog.FileName.Length - pFileInfo.Name.Length);
                //mainMapControl.AddShapeFile(path, pFileInfo.Name);

                string pFullPath = openFileDialog.FileName;
                if (pFullPath == "")
                    return;
                int index = pFullPath.LastIndexOf("\\");
                string filePath = pFullPath.Substring(0, index);            //文件路径
                string fileName = pFullPath.Substring(index + 1);           //文件名

                //实例化ShapefileWorkspaceFactory工作空间，打开Sahpe文件
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(filePath, 0);

                //创建并实例化要素类
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(fileName);
                IFeatureLayer featureLayer = new FeatureLayer();
                featureLayer.FeatureClass = featureClass;
                featureLayer.Name = featureLayer.FeatureClass.AliasName;

                //    ClearAllData();         //新增删除数据
                mainMapControl.Map.AddLayer(featureLayer);
                mainMapControl.ActiveView.Refresh();

                //同步鹰眼
                SynchronizedEagleEye();
            }
            catch (Exception ex) {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }

        private void FileDatabaseLoad_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            string pFullPath = dlg.SelectedPath;
            if (pFullPath == "")
                return;
            IWorkspaceFactory pFileGDBWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
            ClearAllData();
            //获取工作空间
            IWorkspace pWorkspace = pFileGDBWorkspaceFactory.OpenFromFile(pFullPath, 0);
            AddAllDataset(pWorkspace, mainMapControl);
        }

        private void PersonGeodatabaseLoad_Click(object sender, EventArgs e) {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "Personal Geodatabase(*.mdb)|*.mdb";
            pOpenFileDialog.Title = "打开PersonGeodatabase文件";
            pOpenFileDialog.ShowDialog();

            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
                return;
            IWorkspaceFactory pAccessWorkspaceFactory = new AccessWorkspaceFactory();//using ESRI.ArcGIS.DataSourcesGDB

            //获取工作空间
            IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);
            ClearAllData();
            //加载工作空间里的数据
            AddAllDataset(pWorkspace, mainMapControl);
        }

        private void newMxdFile_Click(object sender, EventArgs e) {
            MapDocument pMapDocument = new MapDocumentClass();
            SaveFileDialog opfd = new SaveFileDialog();
            opfd.Title = "新建Mxd文件";
            opfd.Filter = "MapDocuments(*.mxd|*.mxd";
            opfd.ShowDialog();
            string sFilePath = opfd.FileName;
            //   MessageBox.Show("Go Here！  sFilePath=  " + sFilePath, "yahooo");
            if (sFilePath != "") {//如果不判断，不想创建退出时会异常
                 pMapDocument.New(sFilePath);
                 pMapDocument.Open(sFilePath, "");
                 mainMapControl.Map = pMapDocument.get_Map(0);
            }
        }

        #endregion

        #region 保存

        private void saveFile_Click(object sender, EventArgs e) {
            try {
                string sMaxFileName = mainMapControl.DocumentFilename;
                IMapDocument pMapDocument = new MapDocumentClass();
                if (sMaxFileName != null && mainMapControl.CheckMxFile(sMaxFileName)) {
                    if (pMapDocument.get_IsReadOnly(sMaxFileName)) {
                        MessageBox.Show("本地图文档只读，不能保存！");
                        pMapDocument.Close();
                        return;
                    }
                }
                else {
                    SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                    pSaveFileDialog.Title = "请选择保存路径";
                    pSaveFileDialog.OverwritePrompt = true;
                    pSaveFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd|ArcMap模板(*.mxt)|*.mxt";
                    if (pSaveFileDialog.ShowDialog() == DialogResult.OK) {
                        sMaxFileName = pSaveFileDialog.FileName;
                    }
                    else {
                        return;
                    }
                }
                pMapDocument.New(sMaxFileName);
                pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                pMapDocument.Close();
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveFileAs_Click(object sender, EventArgs e) {
            try {
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                pSaveFileDialog.Title = "另存为";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd|ArcMap模板(*.mxt)|*.mxt";
                pSaveFileDialog.RestoreDirectory = true;
                if (pSaveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = pSaveFileDialog.FileName;

                    IMapDocument pMapDocument = new MapDocumentClass();
                    pMapDocument.New(filePath);
                    pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                    pMapDocument.Save(true, true);
                    pMapDocument.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
     
        #endregion

        #region 地图浏览
        string pMouseOperate = null;
        internal object mainMapControl1;
        #endregion

        #region 地图导出
        //局域导出
        private void LocalExport_Click(object sender, EventArgs e) {
            mainMapControl.CurrentTool = null;
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            pMouseOperate = "ExportRegion";
        }
        //全域导出  CartogramPanel.cs
        private void TotalExport_Click(object sender, EventArgs e) {
            if (frExpMap == null || frExpMap.IsDisposed) {
                frExpMap = new ExportMapForm(mainMapControl);
            }
            frExpMap.IsRegion = false;
            frExpMap.GetGeometry = mainMapControl.ActiveView.Extent;
            frExpMap.Show();
            frExpMap.Activate();
        }
        #endregion

        #region 书签管理
        #endregion

        #region 地图量测
        #endregion

        #region 要素选择
        #endregion

        #region mainMapControl事件
        private void mainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e) {
            //得到当前视图范围  
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        private void mainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e) {
            SynchronizedEagleEye(); MessageBox.Show("*********！", "信息提示");
        }

        private void mainMapControl_OnMouseMove(object sender,IMapControlEvents2_OnMouseMoveEvent e) {
            sMapUnits = GetMapUnit(mainMapControl.Map.MapUnits); 
            toolStripStatusLabel1.Text = string.Format("当前坐标：X={0:#.###} Y={1:#.###} {2}", e.mapX, e.mapY,sMapUnits);
        }
        //private void mainMapControl_OnAfterScreenDraw(object sender,IMapControlEvents2_OnAfterScreenDrawEvent e) {
        //    IActiveView pActiveView=(IActiveView)a
        //}


        #endregion  mainMapControl事件

        #region 封装的方法
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            //在绘制前，清除之前绘制的矩形
            IGraphicsContainer pGraphicsContainer = EagleEyeMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;

            //设置矩形框（实质为中间透明的面）
            IRgbColor pColor = new RgbColorClass();
            pColor = GetRgbColor(255, 0, 0);
            pColor.Transparency = 255;

            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 1;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;

            //向鹰眼中添加矩形
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);

            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private IRgbColor GetRgbColor(int R, int G, int B)
        {
            IRgbColor pRgbColor = null;
            if (R < 0 || R > 255 || G < 0 ||G > 255 ||B < 0 || B > 255)
                return pRgbColor;
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = R;
            pRgbColor.Green = G;
            pRgbColor.Blue = B;
            return pRgbColor;
        }

        private void ClearAllData() {
            if (mainMapControl.Map != null && mainMapControl.Map.LayerCount > 0) {
                //新建mainMapControl中的Map
                IMap dataMap = new MapClass();
                dataMap.Name = "Map";
                mainMapControl.DocumentFilename = string.Empty;
                mainMapControl.Map = dataMap;

                //新建EageleEyeMapControl中的Map
                IMap eagleEyeMap = new MapClass();
                eagleEyeMap.Name = "eagleEyeMap";
                EagleEyeMapControl.DocumentFilename = string.Empty;
                EagleEyeMapControl.Map = eagleEyeMap;
            }
        }

        private void SynchronizedEagleEye() {
            if (EagleEyeMapControl.LayerCount > 0)
                EagleEyeMapControl.ClearLayers();
            //设置鹰眼和主地图的坐标系统一致
            EagleEyeMapControl.SpatialReference = mainMapControl.SpatialReference;
            for (int i = mainMapControl.LayerCount - 1; i >= 0; i--) {
                //设置鹰眼视图和数据视图的图层顺序上下保持一致
                ILayer pLayer = mainMapControl.get_Layer(i);
                if (pLayer is IGroupLayer || pLayer is ICompositeLayer) {
                    ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                    for (int j = pCompositeLayer.Count - 1; j >= 0; j--) {
                        ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                        IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                        if (pFeatureLayer != null) {
                            //由于鹰眼地图较小，所以不添加点图层
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint &&
                                pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint) {
                                EagleEyeMapControl.AddLayer(pLayer);
                            }
                        }
                    }
                }
                else {
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (pFeatureLayer != null) {
                        if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint &&
                            pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint) {
                            EagleEyeMapControl.AddLayer(pLayer);
                        }
                    }
                }
                //设置鹰眼地图的全局显示
                EagleEyeMapControl.Extent = mainMapControl.FullExtent;
                pEnv = mainMapControl.Extent as IEnvelope;
                DrawRectangle(pEnv);
                EagleEyeMapControl.ActiveView.Refresh();
            }
        }

        private string GetMapUnit(esriUnits mapUnits) {
            String sMapUnits = string.Empty;
            switch (mapUnits) {
                case esriUnits.esriCentimeters:
                    sMapUnits = "厘米";
                    break;

                case esriUnits.esriDecimalDegrees:
                    sMapUnits = "十进制";
                    break;
                case esriUnits.esriDecimeters:
                    sMapUnits = "分米";
                    break;
  
                case esriUnits.esriFeet:
                    sMapUnits = "尺";
                    break;
                case esriUnits.esriInches:
                    sMapUnits = "英寸";
                    break;
                case esriUnits.esriKilometers:
                    sMapUnits = "千米";
                    break;
                case esriUnits.esriMeters:
                    sMapUnits = "米";
                    break;

                case esriUnits.esriMiles:
                    sMapUnits = "英里";
                    break;
                case esriUnits.esriNauticalMiles:
                    sMapUnits = "厘米";
                    break;
                case esriUnits.esriPoints:
                    sMapUnits = "点";
                    break;
                case esriUnits.esriUnitsLast:
                    sMapUnits = "UnitsLast";
                    break;
                case esriUnits.esriYards:
                    sMapUnits = "码";
                    break;
                case esriUnits.esriUnknownUnits:
                    sMapUnits = "未知单位";
                    break;

                default:
                    break;

            }
            return sMapUnits;
        }
        private void AddAllDataset(IWorkspace pWorkspace, AxMapControl mainMapControl)
        {
            throw new NotImplementedException();
        }

        private void addFeature(string layerName,IGeometry geometry) {
            int i = 0;
            ILayer layer = null;
            for( i = 0; i < mainMapControl.LayerCount; i++) {
                layer = mainMapControl.Map.get_Layer(i);
                if (layer.Name.ToLower() == layerName) {
                    break;
                }
            }
            IFeatureLayer pfeatureLayer = layer as IFeatureLayer;
            IFeatureClass pfeatureclass = pfeatureLayer.FeatureClass;
            IDataset dataset = (IDataset)pfeatureclass;
            IWorkspace pworkspace = dataset.Workspace;

            //开始空间编辑
            IWorkspaceEdit eworkspaceEdit = (IWorkspaceEdit)pworkspace;
            eworkspaceEdit.StartEditing(true);
            eworkspaceEdit.StartEditOperation();
            IFeatureBuffer bfeatureBuffer = pfeatureclass.CreateFeatureBuffer();
            //清除图层原有的实体对象
            IFeatureCursor cfeatureCursor = pfeatureclass.Search(null, true);
            IFeature ifeature = cfeatureCursor.NextFeature();
            while (ifeature != null) {
                ifeature.Delete();
                ifeature = cfeatureCursor.NextFeature();
            }
            //开始插入新的实体对象
            cfeatureCursor = pfeatureclass.Insert(true);
            bfeatureBuffer.Shape = geometry;
            object ofeatureID = cfeatureCursor.InsertFeature(bfeatureBuffer);

            //保存实体
            cfeatureCursor.Flush();
            eworkspaceEdit.StopEditOperation();
            eworkspaceEdit.StopEditing(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(cfeatureCursor);
        }


        #endregion 封装的方法

        #region 鹰眼实现及同步

        private void EagleEyeMapControl_OnMouseDown(object sender ,IMapControlEvents2_OnMouseDownEvent e)  {
            if (EagleEyeMapControl.Map.LayerCount > 0)  {
                //按下鼠标左键移动矩形框
                if (e.button == 1)  {
                    //如果指针落在矩形框中，标记可移动
                    if(e.mapX>pEnv.XMin&&e.mapY>pEnv.YMin&&
                        e.mapX < pEnv.XMax && e.mapY < pEnv.YMax) {
                        bCanDrag = true;
                    }
                    pMoveRectPoint = new PointClass();
                    pMoveRectPoint.PutCoords(e.mapX, e.mapY);//记录点击的第一个坐标
                }
                //按下鼠标右键绘制矩形框
                else if (e.button == 2)    {
                    IEnvelope pEnvelope = EagleEyeMapControl.TrackRectangle();
                    IPoint pTemPoint = new PointClass();
                    pTemPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                    mainMapControl.Extent = pEnvelope;
                    //矩形框的高宽和数据视图的高度不一定成正比，这里要做一个中心调整
                    mainMapControl.CenterAt(pTemPoint);
                }
            }
        }

        //移动矩形框
        private void EagleEyeMapControl_OnMouseMove(object sender,IMapControlEvents2_OnMouseMoveEvent e)  {
            if(e.mapX>pEnv.XMin&&e.mapY>pEnv.YMin&&
                e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)  {
                //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
                EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
                if (e.button == 2) { //如果在内部按下鼠标右键，将鼠标演示设置为默认样式 
                    EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
            }
            else //如果在其它地方，将鼠标演示设置为默认样式
            {
                EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
            if (bCanDrag)   {
                double Dx, Dy;      //记录鼠标移动的位置
                Dx = e.mapX - pMoveRectPoint.X;
                Dy = e.mapY - pMoveRectPoint.Y;
                pEnv.Offset(Dx, Dy);//根据偏移量更改pEnv位置
                pMoveRectPoint.PutCoords(e.mapX, e.mapY);
                DrawRectangle(pEnv);
                mainMapControl.Extent = pEnv;
            }
        }

        private void EagleEyeMapControl_OnMouseUp(object sender,IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    mainMapControl.CenterAt(pMoveRectPoint);
                }
                bCanDrag = false;
            }
        }

        //绘制矩形框

        #endregion 鹰眼实现及同步

        #region TOC右键菜单的添加和功能的实现
        #endregion

        #region 菜单事件
        //private void generPoint_Click(object sender, EventArgs e) {
        //    IGeometryCollection geometryCollection = new MultipointClass();
        //    IMultipoint multipoint = null;
        //    object missing = Type.Missing;
        //    IPoint point;
        //    for(int i = 0; i < 10; i++) {
        //        point = new PointClass();
        //        point.PutCoords(i * 2, i * 2);
        //        geometryCollection.AddGeometry(point as IGeometry, ref missing, ref missing);
        //    }
        //    multipoint = geometryCollection as IMultipoint;
        //    addFeature("multipoint", multipoint as IGeometry);
        //    this.mainMapControl.Extent = multipoint.Envelope;
        //    this.mainMapControl.Refresh();
        //}


        #endregion

        #region 生成规则，随机，聚集模拟图事件

        private void RasterGener_Click(object sender, EventArgs e) {
            new ImageRandom().Show();
        }
        private void AggreGener_Click(object sender, EventArgs e) {

        }
        private void RegularGener_Click(object sender, EventArgs e) {
            new ImageRegular().Show();
        }

        private void ReguToRandGener_Click(object sender, EventArgs e) {
            new ImageRegularToRandom().Show();
        }

        #endregion 生成规则，随机，聚集模拟图事件
       
        //逐行变异计算

        //显示或关闭鹰眼
        private void EagelEyeShow_Click(object sender, EventArgs e) {
            if (this.EagleEyeMapControl.Visible ==false)
                this.EagleEyeMapControl.Visible = true;
            else {
                this.EagleEyeMapControl.Visible = false;   
            }     
        }

        private void VarianceCaculate_Click(object sender, EventArgs e) {
            new TwoDimVariance().Show();
        }

        private void SemiVarCalculate_Click(object sender, EventArgs e) {
            new VarCaculator().Show();
        }
        
        //提取每行元素大小
        private void btnGetLineObjectSize_Click(object sender, EventArgs e) {
            new GetLineObjectSize().Show();
        }
    }
}
