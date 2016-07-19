using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoVar.cElements {
     class ElemShape {
        public  void FillTriangle(Brush brush, Bitmap bmp, Graphics g, float x, float y, int pWidth, int pHeight) {
            g = Graphics.FromImage(bmp);
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine((pWidth / 2)+x, 0+y, pWidth + x, pHeight + y);
            gp.AddLine(pWidth + x, pHeight + y, 0 + x, pHeight + y);
            gp.AddLine(0 + x, pHeight + y, (pWidth / 2) + x, 0 + y);
            //以上面勾画的轮廓画图
            Region reg = new Region(gp);
            g.FillRegion(brush, reg);
            reg.Dispose();
            gp.Dispose();
        }
        public void FillSquare(Brush brush, Bitmap bmp, Graphics g, float x, float y, int pWidth, int pHeight) {
            g = Graphics.FromImage(bmp);
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine( x,  y, pWidth + x,  y);
            gp.AddLine(pWidth + x,  y, pWidth + x, pHeight + y);
            gp.AddLine(pWidth + x, pHeight + y,  x, pHeight + y);
            gp.AddLine(x, pHeight + y, x, y);
       
            //以上面勾画的轮廓画图
            Region reg = new Region(gp);
            g.FillRegion(brush, reg);
            reg.Dispose();
            gp.Dispose();
        }
        //生成六边形
        public void FillHexagon(Brush brush, Bitmap bmp, Graphics g, float x, float y, int pWidth, int pHeight) {
            g = Graphics.FromImage(bmp);
            GraphicsPath gp = new GraphicsPath();
            float px = pWidth/4;//六边形第一个顶点横坐标
            float edge = pWidth /2 ;//六边形第一个顶点横坐标

            gp.AddLine(px+x, y, px+ edge + x, y);
            gp.AddLine(px + edge + x, y, pWidth + x, (pHeight/2)+y);
            gp.AddLine( pWidth + x, (pHeight/2) + y, px + edge + x, y+pHeight);
            gp.AddLine(px + edge + x, y+ pHeight, px + x, y+ pHeight);
            gp.AddLine(px + x, y+ pHeight, x, (pHeight / 2) + y);
            gp.AddLine( x, (pHeight / 2) + y, px + x, y);

            //以上面勾画的轮廓画图
            Region reg = new Region(gp);
            g.FillRegion(brush, reg);
            reg.Dispose();
            gp.Dispose();
        }
    }
}
