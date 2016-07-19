using System;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using System.Windows.Forms;

namespace GeoVar {
    public partial class ExportMapForm : Form {
        private string pSavePath = "";
        private IActiveView pActiveView;
        private IGeometry pGeometry = null;

        //导出空间图形
        public IGeometry GetGeometry {
            set {
                pGeometry = value;
            }
        }
        //全域导出还是局部导出
        private bool bRegion = true;
        public bool IsRegion {
            set {
                bRegion = value;
            }
        }
        public ExportMapForm(AxMapControl mainAxMapControl) {
            InitializeComponent();
            //   pActiveView = mainAxMapControl.ActiveView;
            pActiveView = mainAxMapControl.ActiveView;
        }

       
        private void ExportMapForm_Load(object sender,EventArgs e) {
            InitFormSize();
        }

        private void InitFormSize() {
            cboResolution.Text = pActiveView.ScreenDisplay.DisplayTransformation.Resolution.ToString();
            cboResolution.Items.Add(cboResolution.Text);
            if (bRegion) {
                IEnvelope pEnvelope = pGeometry.Envelope;
                tagRECT pRECT = new tagRECT();
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnvelope, ref pRECT, 9);
                if (cboResolution.Text != "") {
                    textWidth.Text = pRECT.right.ToString();
                    textHeight.Text = pRECT.bottom.ToString();
                }
            }
            else {
                if (cboResolution.Text != "") {
                    textWidth.Text = pActiveView.ExportFrame.right.ToString();
                    textHeight.Text = pActiveView.ExportFrame.bottom.ToString();
                }
            }
        }

        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e) {
            double num = (int)Math.Round(pActiveView.ScreenDisplay.DisplayTransformation.Resolution);
            if (cboResolution.Text == "") {
                textWidth.Text = "";
                textHeight.Text = "";
                return;
            }
            if (bRegion) {
                IEnvelope pEnvelope = pGeometry.Envelope;
                tagRECT pRECT = new tagRECT();
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnvelope, ref pRECT, 9);
                if (cboResolution.Text != "") {
                    textWidth.Text = Math.Round((double)(pRECT.right * (double.Parse(cboResolution.Text) / (double)num))).ToString();
                    textHeight.Text = Math.Round((double)(pRECT.bottom * (double.Parse(cboResolution.Text) / (double)num))).ToString();
                }
            }
            else {
                textWidth.Text = Math.Round((double)(pActiveView.ExportFrame.right * (double.Parse(cboResolution.Text) / (double)num))).ToString();
                textHeight.Text = Math.Round((double)(pActiveView.ExportFrame.bottom * (double.Parse(cboResolution.Text) / (double)num))).ToString();
            }
        }
        private void btnExPath_Click(object sender, EventArgs e) {
            SaveFileDialog savd = new SaveFileDialog();
            savd.DefaultExt = "jpg|bmp|tif|png|pdf";
            savd.Filter = "JPGE 文件(*.jpg)|*.jpg|BMP 文件(*.bmp)|*.bmp|GIF 文件(*.gif)|*.gif|TIF 文件(*.tif)|*.tif|PNG 文件(*.png)|*.png|PDF 文件(*.pdf)|*.pdf";
            savd.OverwritePrompt = true;
            savd.Title = "保存为";
            textExPath.Text = "";
            if (savd.ShowDialog() != DialogResult.Cancel) {
                pSavePath = savd.FileName;
                textExPath.Text = savd.FileName;
            }
        }
        private void btnExport_Click(object sender, EventArgs e) {
            if (textExPath.Text == "") {
                MessageBox.Show("请先确定导出路径", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(cboResolution.Text==""){
                if (textExPath.Text == "") {
                    MessageBox.Show("请输入分辨率", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }else if (Convert.ToInt16(cboResolution.Text) == 0) {
                MessageBox.Show("请正确输入分辨率", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else {
                try {
                
                    int resolution = int.Parse(cboResolution.Text);//输出图片的分辨率
                    int width = int.Parse(textWidth.Text);          //输出图片的宽度，以像素为单位
                    int height = int.Parse(textHeight.Text);        //输出图片的高度，以像素为单位

                    ExportMap.ExportView(pActiveView, pGeometry, resolution, width, height, pSavePath, bRegion);
                 
                    pActiveView.GraphicsContainer.DeleteAllElements();
                    pActiveView.Refresh();

                    MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                }
                catch (Exception) {
                    MessageBox.Show("导出失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            //局部导出时没有导出图像就退出
            pActiveView.GraphicsContainer.DeleteAllElements();
            pActiveView.Refresh();
            Dispose();
        }

        private void ExportMap_FormClosed(object sender, FormClosedEventArgs e) {
            //局部导出时没有导出图像就退出
            pActiveView.GraphicsContainer.DeleteAllElements();
            pActiveView.Refresh();
            Dispose();
        }
    }
}



































