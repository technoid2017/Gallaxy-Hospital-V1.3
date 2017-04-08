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
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Data;

namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for DischargeMuster.xaml
    /// </summary>
    public partial class DischargeMuster : Window
    {
        public DischargeMuster()
        {
            InitializeComponent();
        }

        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtpckAdmissionFrom.SelectedDate = DateTime.Today;
            dtpckAdmissionTo.SelectedDate = DateTime.Today;
            dataGrid1.Visibility = Visibility.Hidden;
        }


        private void bttnGoNamePres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select srNo as 'Sr No.', IpdId as 'IPD Number', PatientName, age as 'Age', sex as 'Sex', mediclaim as 'Mediclaim', dischargeDate as 'Discharge Date', refDr as 'Reference Docter' from Patient_main where dischargeDate between convert(date,@dateFrom, 105) and convert(date,@dateTo, 105)", con);
                    cmd.Parameters.AddWithValue("@dateFrom", dtpckAdmissionFrom.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("@dateTo", dtpckAdmissionTo.SelectedDate.ToString());
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Priscription");
                    sda.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;
                    //System.Windows.MessageBox.Show(" ");
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }
    }
}
