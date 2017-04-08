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
using System.Text.RegularExpressions;

namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for IPD.xaml
    /// </summary>
    public partial class IPD : Window
    {
        int checkMedico;
        int mediclaim;
        int srno;

        String defaultMediclaim = "";
        
        decimal total_amount_services = 0;
        decimal firstVisit = 1500;
        decimal totalPayable = 0;
        decimal totalCharges = 0;
        decimal discounts = 0;
        decimal deposit = 0;
        decimal serviceCharges = 0;
       
        String PatientName;
        public static String IpdNo_con = null;

        public IPD()
        {
            InitializeComponent();
            getMedicine();
            getServices();
            getDocters();
            DropdownLoad();
            getWardType();

            txtGender.Visibility = Visibility.Hidden;
            txtMediclaimType.Visibility = Visibility.Hidden;
            txtWardtype.Visibility = Visibility.Hidden;
            txtConsultant1.Visibility = Visibility.Hidden;
            txtConsultant2.Visibility = Visibility.Hidden;
            
        }

        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public void DropdownLoad()
        {
            drpGender.Items.Add("Male");
            drpGender.Items.Add("Female");

            drpMediclaimType.Items.Add("NA");
            drpMediclaimType.Items.Add("Cashless");
            drpMediclaimType.Items.Add("Reimburse");

          
        }

        //*******************Windows Loaded********************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            drpMediclaimType.Visibility = Visibility.Hidden;
            label10.Visibility = Visibility.Hidden;


            lblIpdno.Visibility = Visibility.Hidden;
            lblName.Visibility = Visibility.Hidden;
            lblDOA.Visibility = Visibility.Hidden;
            bttnClearSearch.Visibility = Visibility.Hidden;

            DOA.SelectedDate = DateTime.Today;
            dtPresc.SelectedDate = DateTime.Today;
            dtpickDischarge.SelectedDate = DateTime.Today;

//********************************Dropdown for More Details**********************
           
            

           //string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
            using (SqlConnection con = new SqlConnection(cons))
            {
                SqlCommand cmd = new SqlCommand(" select isnull(MAX(srNo),0) from Patient_main", con);

                con.Open();

                String id1 = cmd.ExecuteScalar().ToString();

                //String id1 = cmd.ExecuteScalar().ToString();


                srno = Convert.ToInt32(id1) + 1;

                //txtPatientId.Text = (Convert.ToInt32(id1) + 1).ToString();

                //System.Windows.Forms.MessageBox.Show(srno);



            }
        }

//***********************************Tab1 - Add Patient******************************************

        private void chkMediClaim_Checked(object sender, RoutedEventArgs e)
        {
            
           
                    //chkMediclaim.IsChecked = true;
                    drpMediclaimType.Visibility = Visibility.Visible;
                    label10.Visibility = Visibility.Visible;
               
     
        }

        private void chkMediClaim_Unchecked(object sender, RoutedEventArgs e)
        {
            drpMediclaimType.Visibility = Visibility.Hidden;
            label10.Visibility = Visibility.Hidden;
        }



        private void chkMedicoLegal_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void StringValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EmailValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        //*****************************Validation Logic************************
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            Boolean flag = true;

            if (txtName.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("Please enter Name");
                txtName.Focus();
                flag = false;

            }

            else
            {
                flag = true;
            }

            if (drpGender.SelectedIndex == -1 && !txtGender.IsVisible)
            {
                System.Windows.MessageBox.Show("Please select gender");
                drpGender.Focus();
                flag = false;
            }

            else
            {
                flag = true;
            }

            

            if (txtEmail.Text.Length >= 1)
            {

                if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    System.Windows.MessageBox.Show("Enter a valid email.");
                    txtEmail.Select(0, txtEmail.Text.Length);
                    txtEmail.Focus();
                    flag = false;
                }
            }

            if (DOA.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Please Select Date");
                DOA.Focus();
                flag = false;

            }

            else
            {
                flag = true;
            }

            if (txtIpdId.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("Please Generate Ipd number");
                txtAge.Focus();
                flag = false;
            }

            else
            {
                flag = true;
            }

            //******************************Logic to insert chkMedico*******************
            if (chkMedicoLegal.IsChecked == true)
            {
                checkMedico = 1;

            }
            else
            {
                checkMedico = 0;
            }


            if (chkMediClaim.IsChecked == true && !txtMediclaimType.IsVisible)
            {
                mediclaim = 1;
                defaultMediclaim = drpMediclaimType.SelectedItem.ToString();
            }

            else
            {
                mediclaim = 0;
                defaultMediclaim = "NA";
            }




            //******************************Logic to insert chkMediclaim*******************


            if (flag)
            {
                try
                {


                    IpdNo_con = txtIpdId.Text;
                    PatientName = txtName.Text;

                    using (SqlConnection con = new SqlConnection(cons))
                    {



                        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Patient_main]([srNo],[IpdId],[DateofAdmission],[TimeOfAdmission],[PatientName],[Address], address2, [CelNo],[email],[age],[sex],[medicolegal],[mediclaim],[mediclaim_type],[serviceCharges],wardType, discount, payable, deposit, broughtby, relationship, consult1, consult2, refDr, diagnosis)VALUES(convert(int,@srno),@ipdId, @doa, @toa,@name,@address, @address2, @celno,@email,convert(int,@age),@gender,convert(int,@medico),convert(int,@mediclaim),@type,@service, @wardType, @discount, @payable, @deposit, @broughtby, @relationship, @consult1, @consult2, @refDr, @diagnosis)", con);

                        cmd.Parameters.AddWithValue("@ipdId", txtIpdId.Text);
                        cmd.Parameters.AddWithValue("@srno", srno.ToString());
                        //String strDateFormat = "yyyy-MM-dd";//change accordingly if format is something different
                        //DateTime doa = DateTime.ParseExact(DOA.SelectedDate.ToString(), strDateFormat, CultureInfo.InvariantCulture);
                        //DateTime from = DateTime.ParseExact(date_from.Text, strDateFormat, CultureInfo.InvariantCulture);

                        cmd.Parameters.AddWithValue("@doa", Convert.ToDateTime(DOA.SelectedDate.ToString()));
                        cmd.Parameters.AddWithValue("@toa", txtTOA.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@address2", txtAddress2.Text);
                        cmd.Parameters.AddWithValue("@celno", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@age", txtAge.Text);
                        if (txtGender.IsVisible)
                        {
                            cmd.Parameters.AddWithValue("@gender", txtGender.Text);
                        }

                        else
                        {
                            cmd.Parameters.AddWithValue("@gender", drpGender.SelectedItem.ToString());
                        }
                        cmd.Parameters.AddWithValue("@medico", checkMedico.ToString());

                        
                        cmd.Parameters.AddWithValue("@mediclaim", mediclaim.ToString());
                        
                        if (txtMediclaimType.IsVisible)
                        {
                            cmd.Parameters.AddWithValue("@type", txtMediclaimType.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@type", defaultMediclaim);
                        }
                        cmd.Parameters.AddWithValue("@service", serviceCharges);
                        cmd.Parameters.AddWithValue("@wardType", "None");
                        cmd.Parameters.AddWithValue("@discount", 0);
                        cmd.Parameters.AddWithValue("@payable", 0);
                        cmd.Parameters.AddWithValue("@deposit", 0);
                        
                        cmd.Parameters.AddWithValue("@broughtby", "None");
                        cmd.Parameters.AddWithValue("@relationship", "None");
                        cmd.Parameters.AddWithValue("@consult1", "None");
                        cmd.Parameters.AddWithValue("@consult2", "None");
                        cmd.Parameters.AddWithValue("@refDr", "None");
                        cmd.Parameters.AddWithValue("@diagnosis", "None");
                        
                        con.Open();
                        int i = cmd.ExecuteNonQuery();


                        if (i >= 1)
                        {
                            System.Windows.MessageBox.Show("Patient Details Inserted Successfully");
                            txtIpdId_MoreDetails.Text = IpdNo_con.ToString();
                            txtPatientName_MoreDetails.Text = PatientName.ToString();
                        }

                        tabMoreDetails.IsSelected = true;

                    }

                }

                catch (Exception cs)
                {
                    System.Windows.MessageBox.Show(cs.Message);
                }

                txtIpdId.Text = "";
                txtTOA.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                drpGender.SelectedIndex = -1;
                drpMediclaimType.SelectedIndex = -1;
                chkMediClaim.IsChecked = false;
                chkMedicoLegal.IsChecked = false;



            }
        }

       

        //******************************Logic for IPD Number**********************
       // String ipdNo = null;
       // String mon = "";
       // String year = "";
       // String part1 = "";

        public String generateIpdNumber()
        {


            DateTime now = DateTime.Now;
            String ipdNo = null;
            String mon = "Dec";
            String year = "16";
            String part1 = null;
            int serial = 0;
            int part2 = 0;


            using (SqlConnection con = new SqlConnection(cons))
            {
                SqlCommand cmd = new SqlCommand(" select isnull(MAX(serial),0) from Ipd_SrNo", con);

                con.Open();

                String id1 = cmd.ExecuteScalar().ToString();
                serial = Convert.ToInt32(id1) + 1;

            }

            using (SqlConnection con = new SqlConnection(cons))
            {

                SqlCommand cmd2 = new SqlCommand("select top 1 * from Ipd_SrNo order by serial desc", con);

                con.Open();
                cmd2.ExecuteNonQuery();

                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {

                    mon = rdr["mon"].ToString();
                    //System.Windows.MessageBox.Show(mon);
                    year = (String)rdr["yy"];
                   // System.Windows.MessageBox.Show(year);
                    part2 = (int)rdr["srno"];
                   // System.Windows.MessageBox.Show(part2.ToString());
                }
            }



            while (mon != null)
            {
                mon = mon.Trim();
                year = year.Trim();
                String abc = now.ToString("MMM").Trim();
                //System.Windows.MessageBox.Show(mon);
               // System.Windows.MessageBox.Show(now.ToString("MMM"));


                //if (mon == now.ToString("MMM"))
                if (mon.Contains(abc))
                //while (mon.Equals(now.ToString("MMM")))
                {
                    part1 = mon + "-" + year + "-";
                    part2 = part2 + 1;
                    ipdNo = part1 + part2.ToString();
                   // System.Windows.MessageBox.Show(ipdNo);



                    using (SqlConnection con = new SqlConnection(cons))
                    {



                        SqlCommand cmd = new SqlCommand("INSERT INTO Ipd_SrNo (srno, mon, yy,serial) VALUES(convert(int,@srno),@mon,@yy,convert(int,@serial))", con);

                        cmd.Parameters.AddWithValue("@srno", part2.ToString());
                        cmd.Parameters.AddWithValue("@mon", mon);
                        cmd.Parameters.AddWithValue("@yy", year);
                        cmd.Parameters.AddWithValue("@serial", serial.ToString());

                        con.Open();
                        int i = cmd.ExecuteNonQuery();


                        if (i >= 1)
                        {
                            System.Windows.MessageBox.Show("New Ipd Generated!");
                        }

                    }

                    break;
                }

                else
                {
                    mon = now.ToString("MMM");
                    year = now.ToString("yy");
                    part2 = 0;
                    part1 = mon + "-" + year + "-";
                    System.Windows.MessageBox.Show("Month Changed. New series of " + mon + "Starts");
                }


            }
            return ipdNo;
        }

        private void bttnIpdGen_Click(object sender, RoutedEventArgs e)
        {
            String ipd = generateIpdNumber();
            txtIpdId.Text = ipd;
        }


        private void bttnMoreDetails_Click(object sender, RoutedEventArgs e)
        {
            tabMoreDetails.IsSelected = true;

        }

        private void btnCancelPatient_Click(object sender, RoutedEventArgs e)
        {
            txtIpdId.Text = "";
            txtTOA.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            drpGender.SelectedIndex = -1;
            drpMediclaimType.SelectedIndex = -1;
            chkMediClaim.IsChecked = false;
            chkMedicoLegal.IsChecked = false;
        }


        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

//********************************Tab2 - Search Patient***********************************

        String Ipdno_search;
        String pName_search;
        DateTime DOA_search;


      

        void bEdit_Click(object sender, EventArgs e)
        {
            System.Windows.Controls.Button bEdit = sender as System.Windows.Controls.Button;
            tabMoreDetails.IsSelected = true;
              

            try
            {

                using (SqlConnection con = new SqlConnection(cons))
                {

                    if (txtSearchIpdId.Text != String.Empty)
                    {
                         SqlCommand cmd2 = new SqlCommand("select IpdId, PatientName, broughtby, relationship, consult1, consult2, refDr, deposit, diagnosis, wardType from Patient_main where IpdId = @Ipdno", con);
                        cmd2.Parameters.AddWithValue("@Ipdno", txtSearchIpdId.Text);
                        con.Open();
                        cmd2.ExecuteNonQuery();

                        SqlDataReader rdr = cmd2.ExecuteReader();
                        while (rdr.Read())
                        {
                            String ward = (String)rdr["wardType"];
                            if(ward.Trim() !="None")
                            {
                            txtWardtype.Text = ward;
                            txtWardtype.Visibility = Visibility.Visible;
                            }
                            
                            txtIpdId_MoreDetails.Text = (String)rdr["IpdId"];
                            txtPatientName_MoreDetails.Text = (String)rdr["PatientName"];
                            txtBoughtBy.Text = (String)rdr["broughtby"];
                            txtRelation.Text = (String)rdr["relationship"];
                            String consult1 = (String)rdr["consult1"];
                            if (consult1.Trim() != "None")
                             {
                                 txtConsultant1.Text = (String)rdr["consult1"];
                                 txtConsultant1.Visibility = Visibility.Visible;
                             }

                             String consult2 = (String)rdr["consult2"];
                             if (consult2.Trim() != "None")
                             {
                                 txtConsultant2.Visibility = Visibility.Visible;
                                 txtConsultant2.Text = (String)rdr["consult2"];
                             }
                           //System.Windows.MessageBox.Show(cons1);
                            //String cons2 = (String)rdr["consult2"];
                          // drpConsultant1.SelectedItem = cons1;
                           //drpConsultant2.SelectedItem = rdr["consult2"].ToString();
                             //drpConsultant1.Text = ((ComboBoxItem)drpConsultant1.Items[1]).Content.ToString();

                         
                            //drpConsultant1.Text = cons1;
                            //drpConsultant2.SelectedItem.Equals(cons2);
                            txtRefDocter.Text = (String)rdr["refDr"];
                            decimal dep = (decimal)rdr["deposit"];
                            txtDiagnosis.Text = (String)rdr["diagnosis"];
                            txtDepositAmt.Text = dep.ToString();
                            
                            txtPatientName_MoreDetails.IsReadOnly = true;
                            txtIpdId_MoreDetails.IsReadOnly = true;

                        }
                   }

                    else if (txtSearchIpdId.Text == String.Empty )
                    {
                        SqlCommand cmd2 = new SqlCommand("select IpdId, PatientName, broughtby, relationship, consult1, consult2, refDr, deposit, diagnosis from Patient_main where PatientName = @pname", con);
                        cmd2.Parameters.AddWithValue("@pname", txtsearchName.Text);
                        con.Open();
                        //stackPanelSearchIpd.Children[1]).ToString()
                        cmd2.ExecuteNonQuery();

                        SqlDataReader rdr = cmd2.ExecuteReader();
                        while (rdr.Read())
                        {
                            //drpConsultant1.SelectedItem = rdr["consult1"].ToString();
                            txtIpdId_MoreDetails.Text = (String)rdr["IpdId"];
                            txtPatientName_MoreDetails.Text = (String)rdr["PatientName"];
                            txtBoughtBy.Text = (String)rdr["broughtby"];
                            txtRelation.Text = (String)rdr["relationship"];
                            drpConsultant1.SelectedValue = "Nikhil";
                            drpConsultant2.SelectedItem = rdr["consult2"].ToString();
                            //drpConsultant1.SelectedItem = drpConsultant1.FindItemByValue(item.stateid.ToString());
                            // drpConsultant1.SetValue(rdr["consult1"]);
                            //drpConsultant2.DisplayMemberPath = rdr["consult2"].ToString();
                            txtRefDocter.Text = (String)rdr["refDr"];
                            decimal dep = (decimal)rdr["deposit"];
                            txtDiagnosis.Text = (String)rdr["diagnosis"];
                            txtDepositAmt.Text = dep.ToString();

                            txtPatientName_MoreDetails.IsReadOnly = true;
                            txtIpdId_MoreDetails.IsReadOnly = true;
                        }


                    }

                    else
                    {
                        System.Windows.MessageBox.Show("Patient doesnot Exist!!");
                    }

                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }


        public void bDel_warning(object sender, EventArgs e)
        {
           // System.Windows.MessageBox.Show(TextBoxText);
            Window W = new DeleteWarning(txtSearchIpdId.Text);
            W.Show();
            
        }

       


        private void btnsearch1_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {

             
                lblIpdno.Visibility = Visibility.Visible;
                lblName.Visibility = Visibility.Visible;
                lblDOA.Visibility = Visibility.Visible;
                bttnClearSearch.Visibility = Visibility.Visible;
                
                


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select IpdId, PatientName, DateofAdmission from Patient_main where IpdId like '%' +@Ipdno + '%' ", con);
                    cmd.Parameters.AddWithValue("@Ipdno", txtSearchIpdId.Text);
                    con.Open();

                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    //int i = 1;

                    while (rdr.Read())
                    {

                        

                        Ipdno_search = (String)rdr["IpdId"];
                        pName_search = (String)rdr["PatientName"];
                        DOA_search = (DateTime)rdr["DateofAdmission"];
                        string formattedDate = DOA_search.ToString("dd-MM-yyyy");
                       

                        System.Windows.Controls.TextBox txtIpd = new System.Windows.Controls.TextBox();

                        txtIpd.IsReadOnly = true;
                        txtIpd.BorderThickness = new Thickness(0);
                        txtIpd.Height = 40;
                        txtIpd.Width = 120;
                        txtIpd.Text = Ipdno_search;
                        txtIpd.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtIpd.Background = Brushes.PaleVioletRed;
                        stackPanelSearchIpd.Children.Add(txtIpd); 


                        System.Windows.Controls.TextBox txtName = new System.Windows.Controls.TextBox();

                        txtName.IsReadOnly = true;
                        txtName.BorderThickness = new Thickness(0);
                        txtName.Height = 40;
                        txtName.Width = 220;
                        txtName.Text = pName_search;
                        txtName.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtName.Background = Brushes.PaleVioletRed;
                        stackPanelSearchName.Children.Add(txtName); 



                        System.Windows.Controls.TextBox txtDOA = new System.Windows.Controls.TextBox();

                        txtDOA.IsReadOnly = true;
                        txtDOA.BorderThickness = new Thickness(0);
                        txtDOA.Height = 40;
                        txtDOA.Width = 120;
                        txtDOA.Text = formattedDate;
                        txtDOA.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtDOA.Background = Brushes.PaleVioletRed;
                        stackPanelSearchDOA.Children.Add(txtDOA);


                        System.Windows.Controls.Button bEdit = new System.Windows.Controls.Button();
                        bEdit.Content = "Edit";
                        bEdit.Width = 75;
                        bEdit.Height = 40;
                        bEdit.Click += new RoutedEventHandler(bEdit_Click);
                        stackPanelbttnEdit.Children.Add(bEdit);

                       

                        System.Windows.Controls.Button bDel = new System.Windows.Controls.Button();
                        bDel.Content = "Delete";
                        bDel.Width = 85;
                        bDel.Height = 40;
                        bDel.Click += new RoutedEventHandler(bDel_warning);

                        stackPanelbttnDel.Children.Add(bDel);

                        

                    }


                }


            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

       


            

        }

      

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                lblIpdno.Visibility = Visibility.Visible;
                lblName.Visibility = Visibility.Visible;
                lblDOA.Visibility = Visibility.Visible;
                bttnClearSearch.Visibility = Visibility.Visible;


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select IpdId, PatientName, DateofAdmission from Patient_main where PatientName like '%' +@Pname+ '%' ", con);
                    cmd.Parameters.AddWithValue("@Pname", txtsearchName.Text);
                    con.Open();

                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        String Ipdno_search;
                        String pName_search;
                        DateTime DOA_search;

                        Ipdno_search = (String)rdr["IpdId"];
                        pName_search = (String)rdr["PatientName"];
                        DOA_search = (DateTime)rdr["DateofAdmission"];
                        string formattedDate = DOA_search.ToString("dd-MM-yyyy");


                        System.Windows.Controls.TextBox txtIpd = new System.Windows.Controls.TextBox();

                        txtIpd.IsReadOnly = true;
                        txtIpd.BorderThickness = new Thickness(0);
                        txtIpd.Height = 40;
                        txtIpd.Width = 120;
                        txtIpd.Text = Ipdno_search;
                        txtIpd.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtIpd.Background = Brushes.PaleVioletRed;
                        stackPanelSearchIpd.Children.Add(txtIpd);


                        System.Windows.Controls.TextBox txtName = new System.Windows.Controls.TextBox();

                        txtName.IsReadOnly = true;
                        txtName.BorderThickness = new Thickness(0);
                        txtName.Height = 40;
                        txtName.Width = 220;
                        txtName.Text = pName_search;
                        txtName.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtName.Background = Brushes.PaleVioletRed;
                        stackPanelSearchName.Children.Add(txtName);



                        System.Windows.Controls.TextBox txtDOA = new System.Windows.Controls.TextBox();

                        txtDOA.IsReadOnly = true;
                        txtDOA.BorderThickness = new Thickness(0);
                        txtDOA.Height = 40;
                        txtDOA.Width = 120;
                        txtDOA.Text = formattedDate;
                        txtDOA.Opacity = 1;
                        //txtIpd.Background = Color.SemiTransparentRedVioletBrushKey;
                        txtDOA.Background = Brushes.PaleVioletRed;
                        stackPanelSearchDOA.Children.Add(txtDOA);


                        System.Windows.Controls.Button bEdit = new System.Windows.Controls.Button();
                        bEdit.Content = "Edit";
                        bEdit.Width = 75;
                        bEdit.Height = 40;
                        bEdit.Click += new RoutedEventHandler(bEdit_Click);
                        stackPanelbttnEdit.Children.Add(bEdit);


                        System.Windows.Controls.Button bDel = new System.Windows.Controls.Button();
                        bDel.Content = "Delete";
                        bDel.Width = 85;
                        bDel.Height = 40;
                        bDel.Click += new RoutedEventHandler(bDel_warning);
                        stackPanelbttnDel.Children.Add(bDel);


                    }


                }


            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }

        private void bttnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            stackPanelSearchIpd.Children.Clear();
            stackPanelSearchName.Children.Clear();
            stackPanelSearchDOA.Children.Clear();
            stackPanelbttnEdit.Children.Clear();
            stackPanelbttnDel.Children.Clear();

            lblIpdno.Visibility = Visibility.Hidden;
            lblName.Visibility = Visibility.Hidden;
            lblDOA.Visibility = Visibility.Hidden;
            bttnClearSearch.Visibility = Visibility.Hidden;
            txtSearchIpdId.Clear();
            txtsearchName.Clear();

         
        }
      
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

      


//*******************************Tab 3 = More Details**************************************


        void getWardType()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select ward_type from Ward_Details order by ward_type", con);
                    //cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String ward = (String)rdr["ward_type"];
                        drpWardType.Items.Add(ward);
                      
                    }
                }

            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }


        void getDocters()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select docter_name from docters order by docter_name", con);
                    //cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String doc = (String)rdr["docter_name"];
                        drpConsultant1.Items.Add(doc);
                        drpConsultant2.Items.Add(doc);
                        //drp.Items.Add(med);
                    }
                }

            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }
        
        
        private void btnBasicDetails_Click(object sender, RoutedEventArgs e)
        {
            tabAdmission.IsSelected = true;

            try
            {

                using (SqlConnection con = new SqlConnection(cons))
                {

                    SqlCommand cmd2 = new SqlCommand("select IpdId, PatientName, DateofAdmission, TimeOfAdmission, Address, CelNo, email, age, sex, medicolegal, mediclaim, mediclaim_type from Patient_main where IpdId = @Ipdno", con);
                    cmd2.Parameters.AddWithValue("@Ipdno", txtIpdId_MoreDetails.Text);
                    con.Open();
                    cmd2.ExecuteNonQuery();

                    SqlDataReader rdr = cmd2.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtIpdId.Text = (String)rdr["IpdId"];
                        txtName.Text = (String)rdr["PatientName"];
                        DateTime Doa = (DateTime)rdr["DateofAdmission"];
                        DOA.SelectedDate = Doa;
                       // DOA.SelectedDate = (DateTime)rdr.["DateofAdmission"];
                        txtTOA.Text = (String)rdr["TimeOfAdmission"];
                        txtAddress.Text = (String)rdr["Address"];
                        txtPhone.Text = (String)rdr["celNo"]; ;
                        //txtPhone.Text = celno.ToString();
                        String email = (String)rdr["email"];
                        txtEmail.Text = email.Trim();
                        int age = (int)rdr["age"];
                        txtAge.Text = age.ToString();
                        //String gen = (String)rdr["sex"];
                        txtGender.Text = rdr["sex"].ToString();
                        txtGender.Visibility = Visibility.Visible;
                        //Boolean medicoleg = rdr.GetBoolean(10);
                        bool chkmedico = (Boolean)rdr["medicolegal"];
                        bool chkmediclaim = (Boolean)rdr["mediclaim"];

                        if(chkmedico)
                            chkMedicoLegal.IsChecked = true;
                        else
                            chkMedicoLegal.IsChecked = false;

                        if (chkmediclaim)
                        chkMediClaim.IsChecked = true;
                        else
                        chkMediClaim.IsChecked = false;

                        //chkMediClaim.Content = rdr.GetBoolean(11);
                        txtMediclaimType.Text = (String)rdr["mediclaim_type"];
                        txtMediclaimType.Visibility = Visibility.Visible;
                       // int dep = (int)rdr["deposit"];

                        //txtDepositAmt.Text = dep.ToString();

                        //DatePickerFormat DOA = DatePickerFormat.Long;

                       // drpConsultant1.Text = ((ComboBoxItem)drpConsultant1.Items[1]).Content.ToString();
                        //drpConsultant1.SetValue(cons1);
                        //drpConsultant2.SelectedItem.Equals(cons2);
                       // txtRefDocter.Text = (String)rdr["refDr"];
                        //int dep = (int)rdr["deposit"];
                       // txtDiagnosis.Text = (String)rdr["diagnosis"];
                       // txtDepositAmt.Text = dep.ToString();

                        txtPatientName_MoreDetails.IsReadOnly = true;
                        txtIpdId_MoreDetails.IsReadOnly = true;

                    }

                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnAddAdvanced_Click(object sender, RoutedEventArgs e)
        {
            Boolean flag = true;

            if (txtDiagnosis.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("Please enter Diagnosis");
                txtName.Focus();
                flag = false;

            }

            else
            {
                flag = true;
            }

            if (drpWardType.SelectedIndex == -1 && !txtWardtype.IsVisible)
            {
                System.Windows.MessageBox.Show("Please enter Ward Type");
                txtName.Focus();
                flag = false;

            }

            else
            {
                flag = true;
            }



            if (flag)
            {
                try
                {


                    using (SqlConnection con = new SqlConnection(cons))
                    {
                        SqlCommand cmd = new SqlCommand("update  [Patient_main] set [wardType] = @wardType, [broughtby] = @broughtby,[relationship]= @relation,[consult1] = @consult1,[consult2] = @consult2,[refDr] = @refdr,[deposit] = convert(decimal,@deposit),[diagnosis] = @diagnosis where IpdId = @Ipdno", con);
                        //cmd.Parameters.AddWithValue("@srno",adv_srno);
                        //cmd.Parameters.AddWithValue("@pid",patientid );

                        if (txtWardtype.IsVisible && drpWardType.SelectedIndex == -1)
                         
                        {
                            cmd.Parameters.AddWithValue("@wardType", txtWardtype.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@wardType", drpWardType.SelectedItem.ToString());
                        }
                        cmd.Parameters.AddWithValue("@Ipdno", txtIpdId_MoreDetails.Text);
                        cmd.Parameters.AddWithValue("@broughtby", txtBoughtBy.Text);
                        cmd.Parameters.AddWithValue("@relation", txtRelation.Text);

                        if (txtConsultant1.IsVisible && drpConsultant1.SelectedIndex == -1)
                        {
                            cmd.Parameters.AddWithValue("@consult1", txtConsultant1.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@consult1", drpConsultant1.SelectedItem.ToString());
                        }

                        if (txtConsultant2.IsVisible && drpConsultant2.SelectedIndex == -1)
                        {
                            cmd.Parameters.AddWithValue("@consult2", txtConsultant2.Text);
                        }

                        else
                        {
                            cmd.Parameters.AddWithValue("@consult2", drpConsultant2.SelectedItem.ToString());
                        }
                        cmd.Parameters.AddWithValue("@refdr", txtRefDocter.Text);
                        cmd.Parameters.AddWithValue("@deposit", txtDepositAmt.Text);
                        cmd.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                        con.Open();

                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            System.Windows.MessageBox.Show("Data Saved Successfully");

                        }

                        drpWardType.SelectedIndex = -1;
                        txtIpdId_MoreDetails.Text = " ";
                        txtPatientName_MoreDetails.Text = " ";
                        txtIpdId_MoreDetails.Text = " ";
                        txtBoughtBy.Text = " ";
                        txtRelation.Text = " ";
                        drpConsultant1.SelectedIndex = -1;
                        drpConsultant2.SelectedIndex = -1;
                        txtRefDocter.Text = " ";
                        txtDepositAmt.Text = " ";
                        txtDiagnosis.Text = " ";
                        txtWardtype.Visibility = Visibility.Hidden;
                        txtConsultant1.Visibility = Visibility.Hidden;
                        txtConsultant2.Visibility = Visibility.Hidden;


                    }
                }

                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

        }

        private void bttnCancelAdvanced_Click(object sender, RoutedEventArgs e)
        {
            tabSearch.IsSelected = true;
           
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

    

      
   



//******************************************* Tab 4 = Priscription*********************** 

        void getMedicine()
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select med_name from Medicine order by med_name", con);
                    //cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String med = (String)rdr["med_name"];
                        dropMed.Items.Add(med);
                        //drp.Items.Add(med);
                    }
                }

            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }



        public String getIpdId(object sender, RoutedEventArgs e)
        {
            String abc = txtIpdNoPresc.Text;
            System.Windows.MessageBox.Show(abc);
            return abc;
        }
        
        private void bttnGoIpdPres_Click(object sender, RoutedEventArgs e)
        {
            int p_id = 0;
       
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select PatientName, Diagnosis from Patient_main where IpdId = @Ipd", con);
                    cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    //System.Windows.MessageBox.Show(txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtNamePresc.Text = (String)rdr["PatientName"];
                        txtDiagnosisPresc.Text = (String)rdr["Diagnosis"];
                    }
                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select srNo from Patient_main where IpdId = @IpdId", con);
                    cmd.Parameters.AddWithValue("@IpdId", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        p_id = (int)rdr["srNo"];
                        //System.Windows.MessageBox.Show(p_id.ToString());
                    }
                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select Medicine as 'Medicine', quantity as 'Quantity' from priscription where p_id = @p_id", con);
                    cmd.Parameters.AddWithValue("@p_id", p_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Priscription");
                    sda.Fill(dt);
                    dataGridPrescription.ItemsSource = dt.DefaultView;
                }
                    

                    
                


            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }


        private void bttnGoNamePres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select PatientName, Diagnosis from Patient_main where IpdId = @Ipd", con);
                    cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtIpdNoPresc.Text = (String)rdr["IpdId"];
                        txtDiagnosisPresc.Text = (String)rdr["Diagnosis"];
                    }
                   


                }


            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }


       
        private void bttnAddNewPresc2_Click(object sender, RoutedEventArgs e)
        {
            decimal med_price;
            decimal amount = 0;
            int p_id = 0;
            int srno = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand(" select isnull(MAX(srno),0) from priscription", con);

                    con.Open();

                    String id1 = cmd.ExecuteScalar().ToString();

                    //String id1 = cmd.ExecuteScalar().ToString();


                    srno = Convert.ToInt32(id1) + 1;
                }


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select med_price from Medicine where med_name = @medName", con);
                    cmd.Parameters.AddWithValue("@medName", dropMed.SelectedItem.ToString());
                     con.Open();

                     cmd.ExecuteNonQuery();
                     SqlDataReader rdr = cmd.ExecuteReader();

                     while (rdr.Read())
                     {
                         med_price = (decimal)rdr["med_price"];


                         decimal quantity = decimal.Parse(txtQuant.Text);
                         amount = med_price * quantity;
                         //System.Windows.MessageBox.Show(amount.ToString());
                     }

                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select srNo from Patient_main where IpdId = @IpdId",con);
                    cmd.Parameters.AddWithValue("@IpdId", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        p_id = (int)rdr["srNo"];
                       // System.Windows.MessageBox.Show(p_id.ToString());
                    }
                }



                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("insert into priscription (srno, p_id, PriscDate, Medicine, quantity, amnt) VALUES (@srno, @p_id, @prescDate, @Med, convert(int, @quantity), @amnt)", con);
                    cmd.Parameters.AddWithValue("@srno", srno);
                    cmd.Parameters.AddWithValue("@p_id", p_id);
                    cmd.Parameters.AddWithValue("@prescDate", Convert.ToDateTime(dtPresc.SelectedDate.ToString()));
                    cmd.Parameters.AddWithValue("@Med", dropMed.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@quantity", txtQuant.Text);
                    cmd.Parameters.AddWithValue("@amnt", amount);
                    //System.Windows.MessageBox.Show(amount.ToString());
                    con.Open();
                    // cmd.ExecuteNonQuery();

                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Medicine Inserted Successfully");

                    }
                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select Medicine as 'Medicine', quantity as 'Quantity' from priscription where p_id = @p_id", con);
                    cmd.Parameters.AddWithValue("@p_id", p_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Priscription");
                    sda.Fill(dt);
                    dataGridPrescription.ItemsSource = dt.DefaultView;
                }



              
            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private void bttnSubmitPresc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bttnCancelPresc_Click(object sender, RoutedEventArgs e)
        {

        }

     


        private void bttnGenBillPresc_Click(object sender, RoutedEventArgs e)
        {
          //  Window w = new MedicineBill(txtIpdNoPresc.Text);
           // w.Show();
            //getIpdId(sender, e);
            //tabPrescBill.IsSelected = true;
            //IpdNo_con = txtIpdNoPresc.Text;

            PrintMedicine form = new PrintMedicine();
            form.Show();

        }

        private void generateMedicineBill(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }




        private void btnBasic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmitDiag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelDiag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTreatment_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dropMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void drpMediclaimType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
//*********************************************Tab 5 : Services******************************************
        decimal services_database;
        decimal services_current;
        decimal services_final;
        int p_id = 0;

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select srNo, PatientName, serviceCharges from Patient_main where IpdId = @Ipd", con);
                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoService.Text);
                    //System.Windows.MessageBox.Show(txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        p_id = (int)rdr["srNo"];
                        txtNameService.Text = (String)rdr["PatientName"];
                        services_database = (decimal)rdr["serviceCharges"];
                        txtTotalServices.Text = services_database.ToString();
                    }
                   

                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select serviceName as 'Service Name', noOfDays as 'No of Days' from DischargeBill where p_id =(select srNo from Patient_main where IpdId = @Ipd)", con);
                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoService.Text);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("DischargeBill");
                    sda.Fill(dt);
                    dataGridServices.ItemsSource = dt.DefaultView;
                }


               
            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        //***********************Code for Dropdown****************************
        void getServices()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select serviceName from Services order by serviceName", con);
                    //cmd.Parameters.AddWithValue("Ipd", txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String service = (String)rdr["serviceName"];
                        drpServiceName.Items.Add(service);
                        //drp.Items.Add(med);
                    }
                }

            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }

        }


        //***********************Code for Add Service****************************

        private void bttnAddService_Click(object sender, RoutedEventArgs e)
        {
            decimal service_price = 0;
            decimal amount = 0;
            
            
            int srno = 0;
            
            try
            {
                
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select amount from Services where serviceName = @serviceName", con);
                    cmd.Parameters.AddWithValue("@serviceName", drpServiceName.SelectedItem.ToString());
                    con.Open();

                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        service_price = (decimal)rdr["amount"];
                        decimal days = decimal.Parse(txtNoofDayService.Text);
                        services_current = service_price * days;
                       // total_amount_services = total_amount_services + amount;
                        //txtTotalServices.Text = total_amount_services.ToString();
                       // System.Windows.MessageBox.Show(total_amount.ToString());
                    }

                }

                //using (SqlConnection con = new SqlConnection(cons))
                //{
                //    SqlCommand cmd = new SqlCommand("select srNo, serviceCharges from Patient_main where IpdId = @IpdId", con);
                //    cmd.Parameters.AddWithValue("@IpdId", txtIpdNoService.Text);
                //    con.Open();
                //    cmd.ExecuteNonQuery();
                //    SqlDataReader rdr = cmd.ExecuteReader();

                //    while (rdr.Read())
                //    {
                //        p_id = (int)rdr["srNo"];
                //        decimal storedServiceCharges = (decimal)rdr["serviceCharges"];
                //        if (storedServiceCharges > 0)
                //        {
                //            total_amount_services = storedServiceCharges;
                //        }

                //     total_amount_services = total_amount_services + amount;
                //      //  txtTotalServices.Text = total_amount_services.ToString();
                //        //System.Windows.MessageBox.Show(p_id.ToString());
                //    }
                //}

                services_final = services_current + services_database;
                txtTotalServices.Text = services_final.ToString();

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("insert into DischargeBill values(@srno, @p_id, @serviceName ,convert(int,@days) , @amount)", con);
                    cmd.Parameters.AddWithValue("@srno", srno);
                    cmd.Parameters.AddWithValue("@p_id", p_id);
                    cmd.Parameters.AddWithValue("@serviceName", drpServiceName.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@days", txtNoofDayService.Text);
                    cmd.Parameters.AddWithValue("@amount", services_current);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Service Inserted Successfully");

                    }


                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("update Patient_main set serviceCharges= @services where IPDId = @Ipd", con);
                    cmd.Parameters.AddWithValue("@services", services_final);
                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoService.Text);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Amount Saved Successfully");

                    }
                }

                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select serviceName as 'Service Name', noOfDays as 'No of Days' from DischargeBill where p_id = @p_id", con);
                    cmd.Parameters.AddWithValue("@p_id", p_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("DischargeBill");
                    sda.Fill(dt);
                    dataGridServices.ItemsSource = dt.DefaultView;
                }




            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }


            //try
            //{
            //    using (SqlConnection con = new SqlConnection(cons))
            //    {
            //        SqlCommand cmd = new SqlCommand("update Patient_main set serviceCharges= @services where IPDId = @Ipd", con);
            //        cmd.Parameters.AddWithValue("@services", txtTotalServices.Text);
            //        cmd.Parameters.AddWithValue("@Ipd", txtIpdNoService.Text);

            //        con.Open();
            //        int i = cmd.ExecuteNonQuery();

            //        if (i >= 1)
            //        {
            //            System.Windows.MessageBox.Show("Data Saved Successfully");

            //        }
            //    }

            //}
            //catch (Exception cs)
            //{
            //    System.Windows.MessageBox.Show(cs.Message);
            //}

        }

        private void bttnSubmitService_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(cons))
            //    {
            //        SqlCommand cmd = new SqlCommand("update Patient_main set serviceCharges= @services where IPDId = @Ipd", con);
            //        cmd.Parameters.AddWithValue("@services", txtTotalServices.Text);
            //        cmd.Parameters.AddWithValue("@Ipd", txtIpdNoService.Text);
                 
            //        con.Open();
            //        int i = cmd.ExecuteNonQuery();

            //        if (i >= 1)
            //        {
            //            System.Windows.MessageBox.Show("Data Saved Successfully");

            //        }
            //    }

            //}
            //catch (Exception cs)
            //{
            //    System.Windows.MessageBox.Show(cs.Message);
            //}
        }

        private void bttnCancelService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private static string MyToString(object o)
        {
            if (o == DBNull.Value || o == null)
                return "";

            return o.ToString();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            
            //int deposit = 0;
            int admitDaysInt = 0;
            double admitDays = 0;
            decimal bed=0;
            decimal doc=0;
            decimal nurse=0;
            DateTime admissionDate = DateTime.Now;


            //System.Windows.MessageBox.Show(firstVisit.ToString());
            txtFirstVisitDischarge.Text = firstVisit.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select PatientName, DateofAdmission, deposit, wardType, serviceCharges, discount, payable from Patient_main where IpdId = @Ipd", con);
                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoDischarge.Text);
                    //System.Windows.MessageBox.Show(txtIpdNoPresc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtNameDischarge.Text = (String)rdr["PatientName"];

                        admissionDate = (DateTime)rdr["DateofAdmission"];
                        txtDOADischarge.Text = admissionDate.ToString("dd-MM-yyyy");
                       // String wardType = (String)rdr["wardType"];
                        txtWardType.Text = (String)rdr["wardType"];
                       //txtWardType.Text = ((String)rdr["wardType"] == null) ? string.Empty : (String)rdr["wardType"];
                       
                       // String d = MyToString(rdr["deposit"]);
                        deposit = (decimal)rdr["deposit"];
                        txtDepositDischarge.Text = deposit.ToString();
                        total_amount_services = (decimal)rdr["serviceCharges"];
                        txtServiceChargeDischarge.Text = total_amount_services.ToString();
                        decimal pay = (decimal)rdr["payable"];
                        if(pay > 0)
                        {
                            txtPayableDischarge.Text = pay.ToString();
                        }
                    }

                    firstVisit = Convert.ToDecimal(txtFirstVisitDischarge.Text);
                }




                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select ward_type, bed_charges, doc_charges, nursing_charges from Ward_Details where ward_type =(select wardType from Patient_main where IpdId = @Ipd)", con);
                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoDischarge.Text);
                   // System.Windows.MessageBox.Show(txtIpdNoDischarge.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                       // txtWardType.Text = (String)rdr["ward_type"];
                        String ward = (String)rdr["ward_type"];
                        
                            bed = (decimal)rdr["bed_charges"];
                                             
                            doc = (decimal)rdr["doc_charges"];
                        
                            nurse = (decimal)rdr["nursing_charges"];
                      
                        
                       
                       // System.Windows.MessageBox.Show(admitDaysInt.ToString());
                    }

                }
                admitDays = (DateTime.Now - admissionDate).TotalDays;
                admitDaysInt = Convert.ToInt32(admitDays);

                bed = bed * admitDaysInt;
                txtBedChargeDischarge.Text = bed.ToString();
                doc = doc * admitDaysInt;
                txtDrChargeDischarge.Text = doc.ToString();
                nurse= nurse* admitDaysInt;
                txtNurseChargeDischarge.Text = nurse.ToString();

                totalCharges = bed + doc + nurse + total_amount_services + firstVisit;
                txtAmountDischarge.Text = totalCharges.ToString();


                txtDOADischarge.IsReadOnly = true;
                txtNameDischarge.IsReadOnly = true;
                txtWardType.IsReadOnly = false;
                txtBedChargeDischarge.IsReadOnly = false;
                txtDrChargeDischarge.IsReadOnly = false;
                txtNurseChargeDischarge.IsReadOnly = false;
                txtServiceChargeDischarge.IsReadOnly = false;
                txtAmountDischarge.IsReadOnly = false;
                txtDepositDischarge.IsReadOnly = true;
                txtPayableDischarge.IsReadOnly = false;
                
                
            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void dataGridPrescp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bttnShowPayable_Click(object sender, RoutedEventArgs e)
        {
            String discount = txtDiscountDischarge.Text;
            discounts = Convert.ToDecimal(discount);
            totalPayable = totalCharges - discounts - deposit;
            txtPayableDischarge.Text = totalPayable.ToString();

        }

        private void bttnSubmitDischarge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("update Patient_main set dischargeDate= @dischargeDate, firstVisit = convert(decimal,@firstVisit), amount = convert(decimal,@amount), discount= convert(decimal,@discount), payable = convert(decimal,@payable), dischargeTime = @dischargeTime where IPDId = @Ipd", con);

                    cmd.Parameters.AddWithValue("@Ipd", txtIpdNoDischarge.Text);
                    cmd.Parameters.AddWithValue("@dischargeDate", dtpickDischarge.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("@firstVisit", txtFirstVisitDischarge.Text);
                    cmd.Parameters.AddWithValue("@amount", txtAmountDischarge.Text);
                    cmd.Parameters.AddWithValue("@discount", txtDiscountDischarge.Text);
                    cmd.Parameters.AddWithValue("@payable", txtPayableDischarge.Text);
                    cmd.Parameters.AddWithValue("@dischargeTime", txtDischargeTime.Text);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Data Saved Successfully");

                    }
                }

            }
            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnCancelDischarge_Click(object sender, RoutedEventArgs e)
        {
            txtIpdNoDischarge.Text = "";
            txtFirstVisitDischarge.Text = "";
            txtDOADischarge.Text = "";
            txtNameDischarge.Text = "";
            txtWardType.Text = "";
            txtBedChargeDischarge.Text = "";
            txtDrChargeDischarge.Text = "";
            txtNurseChargeDischarge.Text = "";
            txtServiceChargeDischarge.Text = "";
            txtAmountDischarge.Text = "";
            txtDepositDischarge.Text = "";
            txtPayableDischarge.Text = "";
            txtDiscountDischarge.Text = "";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private void bttnGenBillDischarge_Click(object sender, RoutedEventArgs e)
        {
            PrintDischarge form = new PrintDischarge();
            form.Show();
        }

        private void bttnPrintServiceBill_Click(object sender, RoutedEventArgs e)
        {
            ServiceBill form = new ServiceBill();
            form.Show();
        }

     
      

































    }

}

 