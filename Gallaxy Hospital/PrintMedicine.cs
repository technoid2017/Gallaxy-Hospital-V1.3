using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gallaxy_Hospital
{
    public partial class PrintMedicine : Form
    {
        public PrintMedicine()
        {
            InitializeComponent();
        }

        private void PrintMedicine_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
