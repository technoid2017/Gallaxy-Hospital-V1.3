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
    public partial class ReportDischarge : Form
    {
        public ReportDischarge()
        {
            InitializeComponent();
        }

        private void ReportDischarge_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
