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
    public partial class ImageAggregation : Form {
        public ImageAggregation() {
            InitializeComponent();
        }

        private void saveFileDir_Click(object sender, EventArgs e) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = "D:\\MyDesktop\\";
            savefile.Title = "保存到……";
            savefile.Filter = "BMP文件(*.bmp)|*.bmp|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";

            if (savefile.ShowDialog() == DialogResult.OK) {
                textBoxDir.Text = savefile.FileName;
            }
        }

        private void btnGen_Click(object sender, EventArgs e) {

        }

      
    }
}
