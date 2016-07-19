using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoVar {
    public partial class CacuProBar : Form {
        public CacuProBar(String name,int min,int max) {
            InitializeComponent();
            this.Text = name;
            progressBar1.Maximum = max;
            progressBar1.Minimum = min;
        }
        public void SetProgressValue(int value) {
            if (value < progressBar1.Maximum) {  //如果值有效
                this.progressBar1.Value = value;
                this.label1.Text = "计算进度 :" + value.ToString() + "/"+ progressBar1.Maximum; 
            }
            Application.DoEvents();
            //if (value == this.progressBar1.Maximum - 1)
            //    this.Close();
        }
    }
}
