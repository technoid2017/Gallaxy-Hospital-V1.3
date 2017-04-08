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
    /// Interaction logic for MedicineBill.xaml
    /// </summary>
    public partial class MedicineBill : Window
    {
        //String Ipd_number = null;
        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public MedicineBill(String Ipd)
        {
            InitializeComponent();
            String Ipd_number = Ipd;
            decimal totalAmount = 0;
            decimal amount = 0;

            generateMedicineBill();
            System.Windows.MessageBox.Show(Ipd_number);
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select srno as 'Sr No', Medicine, quantity as 'Quantity', amnt as 'Amount' from priscription where p_id = (select srNo from Patient_main where IpdId = @Ipd)", con);
                    cmd.Parameters.AddWithValue("@Ipd", Ipd_number);
                    con.Open();
                    
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Priscription");
                    sda.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;
                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select amnt from priscription where p_id = (select srNo from Patient_main where IpdId = @Ipd)", con);
                    cmd.Parameters.AddWithValue("@Ipd", Ipd_number);
                    con.Open();
                    

                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        amount = (decimal)rdr["amnt"];
                        totalAmount = totalAmount + amount;
                       // System.Windows.MessageBox.Show(totalAmount.ToString());
                    }

                    txtTotalAmount.Text = totalAmount.ToString();
                    
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

          
        }
        

        //String Ipd;

        public void generateMedicineBill()
        {
            //ipd = new IPD();
            //String Ipd = ipd.getIpdId(sender, e);
            //String Ipd = ipd.getIpdId(object sender, RoutedEventArgs e);
           
            

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        //    IPD ipd = new IPD();
        //    ipd.generateMedicineBill();
        //   // dataGrid1.ItemsSource = dt.DefaultView;
           // generateMedicineBill(sender, e);

        }

        private void bttnPrescBillPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintMedicine form = new PrintMedicine();
            form.Show();
        }
    }
}
