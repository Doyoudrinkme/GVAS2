using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.esriSystem;
using System.Windows.Forms;

namespace GeoVar {
    public  class ExportMap {
        public static void ExportView(IActiveView view, IGeometry pGeo, int OutputResolution, int Width, int Height, string ExpPath, bool bRegion) {
            IExport pExport = null;
            tagRECT exportRect = new tagRECT();
            IEnvelope pEnvelope = pGeo.Envelope;
            string sType = System.IO.Path.GetExtension(ExpPath);
            switch (sType) {
                case ".jpg":
                    pExport = new ExportJPEGClass();
                    break;
                case ".bmp":
                    pExport = new ExportBMPClass();
                    break;
                case ".gif":
                    pExport = new ExportGIFClass();
                    break;
                case ".tif":
                    pExport = new ExportTIFFClass();
                    break;
                case ".png":
                    pExport = new ExportPNGClass();
                    break;
                case ".pdf":
                    pExport = new ExportPDFClass();
                    break;
                default:
                    MessageBox.Show("没有输出格式，默认到JPEG格式");
                    pExport = new ExportJPEGClass();
                    break;
            }
            pExport.ExportFileName = ExpPath;

            exportRect.left = 0;
            exportRect.top = 0;
            exportRect.right = Width;
            exportRect.bottom = Height;//bottom 写成 left 两天才排出错误 2016年4月17日20:24:13
            if (bRegion) {
                view.GraphicsContainer.DeleteAllElements();
                view.Refresh();
            }

            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)exportRect.left, (double)exportRect.top, (double)exportRect.right, (double)exportRect.bottom);
            pExport.PixelBounds = envelope;
            //MessageBox.Show("Go Here！  OutputResolution  " + OutputResolution, "yahooo");
            view.Output(pExport.StartExporting(), OutputResolution, ref exportRect, pEnvelope, null);//无法运行2016年4月17日14:42:25
            /*
            当时发现错误出现在上句，对分辨率参数做了排查，但是忽略了其它参数，而最终的问题就在于其中的pEnvelope参数
            这次能够排出错误，是因为对照了原来的代码，而在自己写程序时没有参考代码，仅靠对照排错是不够的，
            因此，要逐步缩小出错的代码块，对每一个参数都要进行检验。（2016年4月17日20:31:12）
         */                                                                                         
            pExport.FinishExporting();
            pExport.Cleanup();
        }
    }
}