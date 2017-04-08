namespace Gallaxy_Hospital
{
    partial class PrintMedicine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.DocumentMapWidth = 30;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.MinimumSize = new System.Drawing.Size(600, 1000);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.ReportPath = "/Galaxy_Repots/MedicineBill";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://galaxy-pc/ReportServer", System.UriKind.Absolute);
            this.reportViewer1.Size = new System.Drawing.Size(1200, 1000);
            this.reportViewer1.TabIndex = 0;
            // 
            // PrintMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 746);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintMedicine";
            this.Text = "PrintMedicine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintMedicine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;


    }
}