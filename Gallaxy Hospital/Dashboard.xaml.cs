using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window W = new IPD();
            W.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
          
            Graphs form = new Graphs();
            form.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Window W = new AdmissionMuster();
            //    W.Show();
            //    this.Close();
            //}
            //catch (Exception cs)
            //{
            //    System.Windows.MessageBox.Show(cs.Message);
            //}

            ReportAdmission form = new ReportAdmission();
            form.Show();
        }

        private void bttnDischargeMuster_Click(object sender, RoutedEventArgs e)
        {
            //Window W = new DischargeMuster();
            //W.Show();
            //this.Close();

            ReportDischarge form = new ReportDischarge();
            form.Show();
        }

        private void bttnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Window W = new Admin();
            W.Show();
            this.Close();
        }

        private void bttnAccounts_Click(object sender, RoutedEventArgs e)
        {
            Window W = new Accounts();
            W.Show();
            this.Close();

           // PrintMedicine form = new PrintMedicine();
           // form.Show();
        }
    }
}
