using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoVar.pTool {
    public partial class InterpreProBar : Form {
   
        public InterpreProBar(int min, int max) {
            InitializeComponent();
            progressBar1.Maximum = max;
            progressBar1.Minimum = min;
        }
        public void SetProgressValue(int value) {
            if (value < progressBar1.Maximum) {  //如果值有效
                this.progressBar1.Value = value;
                this.label1.Text = "解析进度 :" + value.ToString() + "/" + progressBar1.Maximum;
            }
            Application.DoEvents();
        }
    }
}
