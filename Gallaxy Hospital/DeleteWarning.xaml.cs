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
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Navigation;


namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for DeleteWarning.xaml
    /// </summary>
    public partial class DeleteWarning : Window
    {
        String IPDNumber;
        public DeleteWarning(String txtIpd)
        {
            InitializeComponent();
            IPDNumber = txtIpd;
        }
        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
       
        

        private void bttnYes_Click(object sender, RoutedEventArgs e)
        {

            //IPD ipd = new IPD();
           // String str = ipd.getValue(sender, e);
           // System.Windows.MessageBox.Show(IPDNumber);
            //ipd.bDel_click(sender, e);
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("delete from Patient_main where IpdId = @Ipd", con);
                    cmd.Parameters.AddWithValue("@Ipd", IPDNumber);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Patient Deleted successfully");
                    }
                }
                this.Close();
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }

        private void bttnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
