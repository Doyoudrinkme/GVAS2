using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using System.Data.OleDb;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.AnalysisTools;




namespace GeoVar {
    public partial class frmInterpolationIDW : Form
    {
        private bool bDataPath = false;// '判断是否通过打开对话框选择点特征类
        private bool bDataLinePath = false;// '判断是否通过打开对话框选择线障碍特征类
        static FormMain frm;
        public frmInterpolationIDW(FormMain frmm)
        {
            InitializeComponent();
            frm = frmm;
        }

        private void frmInterpolationIDW_Load(object sender, EventArgs e)
        {
            FillComboWithMapLayers(comboBoxInPoint, true, false);
            FillComboWithMapLayers(comboBoxBarrier, true, true);

            //txtOutputRasterPath.Text = MainForm.SAoption.AnalysisPath;
            //txtCellSize.Text = MainForm.SAoption.RasterCellSize.ToString();
            comboBoxSearchRadius.Items.Add("固定");
            comboBoxSearchRadius.Items.Add("变化");
            comboBoxSearchRadius.Text = "变化";
            groupBoxVariable.Visible = true;
            groupBoxFixed.Visible = false;
            comboBoxBarrier.Enabled = false;
            comboBoxZValueField.Text = "无";
            txtWeightValue.Text = "2";
            txtPointNumbers.Text = "12";
            btnOpenBarrier.Enabled = false;
        }
        private void FillComboWithMapLayers(ComboBox combLayers, bool bLayer, bool bType)
        {
            combLayers.Items.Clear();
            ILayer aLayer;

            for (int i = 0; i < frm.mainMapControl.Map.LayerCount; i++)
            {
                aLayer = frm.mainMapControl.Map.get_Layer(i);
                if (aLayer != null)
                {
                    if (bLayer == true)
                    {
                        if (aLayer is IFeatureLayer)
                        {
                            IFeatureLayer flyr;
                            IFeatureClass pFeatureClass;
                            flyr = (IFeatureLayer)aLayer;
                            pFeatureClass = flyr.FeatureClass;

                            if (bType == false)
                            {
                                if (flyr.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                {
                                    combLayers.Items.Add(aLayer.Name);
                                }
                            }
                            else
                            {
                                if (flyr.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                {
                                    combLayers.Items.Add(aLayer.Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnOpenSourceData_Click(object sender, EventArgs e)
        {
            OpenFileDlg.FileName = "";
            OpenFileDlg.Filter = "GIS（*.shp）|*.shp";
            OpenFileDlg.FilterIndex = 1;
            OpenFileDlg.ShowDialog();
            if (OpenFileDlg.FileName != "")
            {
                comboBoxInPoint.Text = OpenFileDlg.FileName;
                IWorkspaceFactory pWorkspaceFactory;
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                String wsp;
                int r;
                int l;
                r = comboBoxInPoint.Text.LastIndexOf("\\");
                l = comboBoxInPoint.Text.LastIndexOf(".");
                wsp = comboBoxInPoint.Text.Substring(0, r);
                IFeatureWorkspace pFWS;
                pFWS = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(wsp, 0);
                try
                {
                    String sp;
                    IFeatureClass pFeatureClass;
                    sp = comboBoxInPoint.Text.Substring(r + 1, l - r - 1);
                    pFeatureClass = pFWS.OpenFeatureClass(sp);

                    comboBoxZValueField.Items.Clear();
                    comboBoxZValueField.Items.Add("无");
                    try
                    {
                        for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                        {
                            if (pFeatureClass.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeDouble || pFeatureClass.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeSingle || pFeatureClass.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeSmallInteger || pFeatureClass.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeInteger)
                            {
                                comboBoxZValueField.Items.Add(pFeatureClass.Fields.get_Field(j).Name);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bDataPath = true;
            }
        }

        private void btnOpenBarrier_Click(object sender, EventArgs e)
        {
            OpenFileDlg.FileName = "";
            OpenFileDlg.Filter = "GIS（*.shp）|*.shp";
            OpenFileDlg.FilterIndex = 1;
            OpenFileDlg.ShowDialog();

            if (OpenFileDlg.FileName != "")
            {

                String wsp;
                int r;
                int l;
                r = OpenFileDlg.FileName.LastIndexOf("\\");
                l = OpenFileDlg.FileName.LastIndexOf(".");
                wsp = OpenFileDlg.FileName.Substring(0, r);
                IWorkspaceFactory pWorkspaceFactory;
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                IFeatureWorkspace pFWS;
                pFWS = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(wsp, 0);
                try
                {
                    String sp;
                    IFeatureClass pFeatureClass;
                    sp = OpenFileDlg.FileName.Substring(r + 1, l - r - 1);
                    pFeatureClass = pFWS.OpenFeatureClass(sp);
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {
                        comboBoxBarrier.Text = OpenFileDlg.FileName;
                    }
                    else
                    {
                        MessageBox.Show("请选择线类型的shape文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxBarrier.Text = "";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bDataLinePath = true;
            }
        }
        private void chkBarrier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBarrier.Checked == true)
            {
                comboBoxBarrier.Enabled = true;
                btnOpenBarrier.Enabled = true;
            }
            else
            {
                comboBoxBarrier.Enabled = false;
                btnOpenBarrier.Enabled = false;
            }
        }
        private void comboBoxBarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            bDataLinePath = false;
        }

        private void btnSaveRasterPath_Click(object sender, EventArgs e)
        {
            String pOutDSName;
            int iOutIndex;
            String sOutRasPath;
            String sOutRasName;

            saveFileDialog1.Title = "保存栅格运算结果";
            saveFileDialog1.Filter = "(*.img)|*.img";
            saveFileDialog1.OverwritePrompt = false;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)  {
                pOutDSName = saveFileDialog1.FileName;
                FileInfo fFile = new FileInfo(pOutDSName);
                //判断文件名是否已经存在，如果存在，则弹出提示
                if (fFile.Exists == true)    {
                    MessageBox.Show("文件名已存在，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtOutputRasterPath.Text = "";
                }
                else  {
                    iOutIndex = pOutDSName.LastIndexOf("\\");
                    sOutRasPath = pOutDSName.Substring(0, iOutIndex + 1);
                    sOutRasName = pOutDSName.Substring(iOutIndex + 1, pOutDSName.Length - iOutIndex - 1);
                    txtOutputRasterPath.Text = pOutDSName;
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)   {
            IFeatureClass pInPointFClass;//获得输入点特征数据类
            IFeatureClass pLineBarrierFClass;//获得输入的线障碍类

            String fileName;
            String rasterPath;
            String shpFile;
            int startX, endX;
            //选择要进行分析的字段
            if (bDataPath == true)   {
                fileName = comboBoxInPoint.Text;
                String shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                IWorkspaceFactory pWorkspaceFactory;
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                IFeatureWorkspace pFWS;
                pFWS = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(shpDir, 0);

                pInPointFClass = pFWS.OpenFeatureClass(shpFile);
            }
            else
            {
                pInPointFClass = GetFeatureFromMapLyr(comboBoxInPoint.Text);
            }

            if (bDataLinePath == true && chkBarrier.Checked)
            {
                fileName = comboBoxBarrier.Text;
                String shpDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                startX = fileName.LastIndexOf("\\");
                endX = fileName.Length;
                shpFile = fileName.Substring(startX + 1, endX - startX - 1);
                IWorkspaceFactory pWorkspaceFactory;
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                IFeatureWorkspace pFWS;
                pFWS = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(shpDir, 0);
                pLineBarrierFClass = pFWS.OpenFeatureClass(shpFile);
            }
            else if (chkBarrier.Checked)
            {
                pLineBarrierFClass = GetFeatureFromMapLyr(comboBoxBarrier.Text);
            }
            IFeatureLayer pFeatLayer = new FeatureLayerClass();
            pFeatLayer.FeatureClass = pInPointFClass;
            rasterPath = txtOutputRasterPath.Text;
            //查询过滤器

            //'FeatureClassDescriptor
            //这个对象主要用于提供访问控制FeatureClass descriptor的成员；例如，定义FeatureClass的那个属性作为分析操作。
            IFeatureClassDescriptor pFeatClsDes = new FeatureClassDescriptorClass();

            if (comboBoxZValueField.Text != "无")
            {
                pFeatClsDes.Create(pInPointFClass, null, comboBoxZValueField.Text);
            }
            else
            {
                pFeatClsDes.Create(pInPointFClass, null, "");
            }

            try
            {
                IInterpolationOp pInterpolationOp = new RasterInterpolationOpClass();
                String sCellSize = txtCellSize.Text;
                String sPower = txtWeightValue.Text;
                if (Convert.ToDouble(sCellSize) <= 0 || sPower == "")
                {
                    MessageBox.Show("还没输入权重值或栅格单元！请输入后在进行插值。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double dCellSize = Convert.ToDouble(sCellSize);
                double dPower = Convert.ToDouble(sPower);

                IRasterRadius pRsRadius = new RasterRadiusClass();
                if (comboBoxSearchRadius.Text == "变化")
                {
                    String sPointNums = txtPointNumbers.Text;
                    if (sPointNums != "")
                    {
                        int iPointNums = Convert.ToInt32(sPointNums);
                        if (txtDisMaxValue.Text != "")
                        {
                            double maxDis = Convert.ToDouble(txtDisMaxValue.Text);
                            object objMaxDis = maxDis as object;
                            pRsRadius.SetVariable(iPointNums, ref objMaxDis);
                        }
                        else
                        {
                            object objMaxDis = null;
                            pRsRadius.SetVariable(iPointNums, ref objMaxDis);
                        }
                    }
                    else
                    {
                        MessageBox.Show("还没输入点的数目！请输入后在进行插值。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    String sDistance = txtDisValue.Text;
                    if (sDistance != "")
                    {
                        double dDistance = Convert.ToDouble(sDistance);
                        if (txtMaxPointNums.Text != "")
                        {
                            double maxPointNums = Convert.ToDouble(txtMaxPointNums.Text);
                            object objMinPointNums = maxPointNums as object;
                            pRsRadius.SetFixed(dDistance, ref objMinPointNums);
                        }
                        else
                        {
                            object objMinPointNums = null;
                            pRsRadius.SetFixed(dDistance, ref objMinPointNums);
                        }
                    }
                    else
                    {
                        MessageBox.Show("还没输入距离的值！请输入后在进行插值。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }

                pInterpolationOp = SetRasterInterpolationAnalysisEnv(rasterPath, dCellSize, pFeatLayer);
                object objLineBarrier = null;
                if (chkBarrier.Checked == true)
                {
                    objLineBarrier = comboBoxBarrier;
                }
                else
                {
                    objLineBarrier = Type.Missing;
                }


                IRaster pOutRaster;
                pOutRaster = (IRaster)pInterpolationOp.IDW((IGeoDataset)pFeatClsDes, dPower, pRsRadius, ref objLineBarrier);
                //着色                
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.Name = "反距离栅格";
                ConvertRasterToRsDataset(rasterPath, ref pOutRaster, "反距离栅格");
                pRasterLayer = SetRsLayerClassifiedColor(pOutRaster);
                frm.mainMapControl.AddLayer(pRasterLayer, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private IFeatureClass GetFeatureFromMapLyr(String sLyrName)
        {
            IFeatureClass pFeatCls = null;
            for (int i = 0; i < frm.mainMapControl.Map.LayerCount; i++)
            {
                ILayer pLyr = frm.mainMapControl.Map.get_Layer(i);
                if (pLyr != null)
                {
                    if (pLyr.Name == sLyrName)
                    {
                        if (pLyr is IFeatureLayer)
                        {
                            IFeatureLayer pFLyr = (IFeatureLayer)pLyr;
                            pFeatCls = pFLyr.FeatureClass;
                        }
                    }
                }
            }
            return pFeatCls;
        }


        private IInterpolationOp SetRasterInterpolationAnalysisEnv(String rasterpath, double cellsize, IFeatureLayer pFeatLayer)
        {
            object Missing = Type.Missing;
            IWorkspaceFactory pWSF;
            pWSF = new RasterWorkspaceFactoryClass();
            IWorkspace pWorkspace = pWSF.OpenFromFile(rasterpath, 0);
            IInterpolationOp pInterpolationOp = new RasterInterpolationOpClass();
            IRasterAnalysisEnvironment pRsEnv = (IRasterAnalysisEnvironment)pInterpolationOp;
            pRsEnv.OutWorkspace = pWorkspace;
            //装箱操作
            object objCellSize = cellsize;

            pRsEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objCellSize);

            IEnvelope pEnv = new EnvelopeClass();
            pEnv.XMin = pFeatLayer.AreaOfInterest.XMin;
            pEnv.XMax = pFeatLayer.AreaOfInterest.XMax;
            pEnv.YMin = pFeatLayer.AreaOfInterest.YMin;
            pEnv.YMax = pFeatLayer.AreaOfInterest.YMax;
            object objExtent = pEnv;
            pRsEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objExtent, ref Missing);
            return pInterpolationOp;
        }

        private void ConvertRasterToRsDataset(String sPath, ref IRaster pRaster, String sOutName)
        {
            try
            {
                IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
                if (pWSF.IsWorkspace(sPath) == false)
                {
                    return;
                }

                IWorkspace pRWS = pWSF.OpenFromFile(sPath, 0);

                if (File.Exists(sPath + "\\" + sOutName + ".img") == true)
                {
                    File.Delete(sPath + "\\" + sOutName + ".img");
                }


                IRasterBandCollection pRasBandCol = (IRasterBandCollection)pRaster;

                IDataset pDS = pRasBandCol.SaveAs(sOutName + ".img", pRWS, "IMAGINE Image");
                ITemporaryDataset pRsGeo = (ITemporaryDataset)pDS;
                if (pRsGeo.IsTemporary())
                {
                    pRsGeo.MakePermanent();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IRasterLayer SetRsLayerClassifiedColor(IRaster pRaster)
        {
            IRasterClassifyColorRampRenderer pClassRen = new RasterClassifyColorRampRendererClass();
            IRasterRenderer pRasRen = (IRasterRenderer)pClassRen;
            //Set raster for the render and update
            pRasRen.Raster = pRaster;
            pClassRen.ClassCount = 9;
            pRasRen.Update();
            //Create a color ramp to use
            //定义起点和终点颜色
            IColor pFromColor = new RgbColorClass();
            IRgbColor pRgbColor = (IRgbColor)pFromColor;
            pRgbColor.Red = 255;
            pRgbColor.Green = 200;
            pRgbColor.Blue = 0;
            IColor pToColor = new RgbColorClass();
            pRgbColor = (IRgbColor)pToColor;
            pRgbColor.Red = 0;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 255;
            //创建颜色分级
            IAlgorithmicColorRamp pRamp = new AlgorithmicColorRampClass();
            pRamp.Size = 9;
            pRamp.FromColor = pFromColor;
            pRamp.ToColor = pToColor;
            bool ok = true;
            pRamp.CreateRamp(out ok);

            //获得栅格统计数值
            IRasterBandCollection pRsBandCol = (IRasterBandCollection)pRaster;
            IRasterBand pRsBand = pRsBandCol.Item(0);
            pRsBand.ComputeStatsAndHist();
            IRasterStatistics pRasterStatistic = pRsBand.Statistics;
            double dMaxValue = pRasterStatistic.Maximum;
            double dMinValue = pRasterStatistic.Minimum;

            //Create symbol for the classes
            IFillSymbol pFSymbol = new SimpleFillSymbolClass();
            double LabelValue = Convert.ToDouble((dMaxValue - dMinValue) / 9);

            for (int i = 0; i < pClassRen.ClassCount; i++)
            {
                pFSymbol.Color = pRamp.get_Color(i);
                pClassRen.set_Symbol(i, (ISymbol)pFSymbol);
                double h1 = (LabelValue * i) + dMinValue;
                double h2 = (LabelValue * (i + 1)) + dMinValue;
                pClassRen.set_Label(i, h1.ToString() + "-" + h2.ToString());
            }

            //Update the renderer and plug into layer
            pRasRen.Update();
            IRasterLayer pRLayer = new RasterLayerClass();
            pRLayer.CreateFromRaster(pRaster);
            pRLayer.Renderer = (IRasterRenderer)pClassRen;
            return pRLayer;
        }
                 
        
    }
}
