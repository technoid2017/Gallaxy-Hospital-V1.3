﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gallaxy_Hospital
{
    public partial class ReportAdmission : Form
    {
        public ReportAdmission()
        {
            InitializeComponent();
        }

        private void ReportAdmission_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
