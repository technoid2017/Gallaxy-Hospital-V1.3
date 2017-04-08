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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private void bttnSearchDocter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select * from docters where docter_name like  '%'+ @doc +  '%'", con);
                    cmd.Parameters.AddWithValue("@doc", txtsearchDocter.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtNameDocter.Text = (String)rdr["docter_name"];
                        txtSpecification.Text = (String)rdr["specialization"];
                    }
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnAddDocter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("insert into docters (docter_name, specialization) values(@doc, @specialization)" , con);
                    cmd.Parameters.AddWithValue("@doc", txtNameDocter.Text);
                    cmd.Parameters.AddWithValue("@specialization", txtSpecification.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Docter added Successfully");
                       
                    }
                    txtNameDocter.Text = "";
                    txtSpecification.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnUpdateDocter_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("update docters set docter_name = @doc, specialization = @specialization where docter_name = @docSearch", con);
                    cmd.Parameters.AddWithValue("@doc", txtNameDocter.Text);
                    cmd.Parameters.AddWithValue("@specialization", txtSpecification.Text);
                    cmd.Parameters.AddWithValue("@docSearch", txtsearchDocter.Text);

                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Data Updated Successfully");

                    }

                    txtNameDocter.Text = "";
                    txtSpecification.Text = "";
                    txtsearchDocter.Text = "";
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnDeleteDocter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("delete from docters where docter_name=@doc", con);
                    cmd.Parameters.AddWithValue("@doc", txtNameDocter.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Data Deleted Successfully");

                    }
                    txtNameDocter.Text = "";
                    txtSpecification.Text = "";
                    txtsearchDocter.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnCancelDocter_Click(object sender, RoutedEventArgs e)
        {
            txtNameDocter.Text = "";
            txtSpecification.Text = "";
            txtsearchDocter.Text = "";
        }

//********************************Add Medicine Code*********************************************************

        private void bttnSearchMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select * from Medicine where med_name like '%'+ @med + '%'", con);
                    cmd.Parameters.AddWithValue("@med", txtMedSearch.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtMedName.Text = (String)rdr["med_name"];
                        decimal cost = (decimal)rdr["med_price"];
                        txtMedPrice.Text = cost.ToString();
                    }
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnAddMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("insert into Medicine (med_name, med_price) values(@med, convert(decimal,@med_price))", con);
                    cmd.Parameters.AddWithValue("@med", txtMedName.Text);
                    cmd.Parameters.AddWithValue("@med_price", txtMedPrice.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Medicine added Successfully");

                    }
                    txtMedName.Text = "";
                    txtMedPrice.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnUpdateMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("update Medicine set med_name = @med, med_price = @med_price where med_name = @medSearch", con);
                    cmd.Parameters.AddWithValue("@med", txtMedName.Text);
                    cmd.Parameters.AddWithValue("@med_price", txtMedPrice.Text);
                    cmd.Parameters.AddWithValue("@medSearch", txtMedSearch.Text);

                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Data Updated Successfully");

                    }

                    txtNameDocter.Text = "";
                    txtMedPrice.Text = "";
                    txtMedSearch.Text = "";
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnDelMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("delete from Medicine where med_name=@med", con);
                    cmd.Parameters.AddWithValue("@med", txtMedName.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Medicine Deleted Successfully");

                    }
                    txtMedName.Text = "";
                    txtMedPrice.Text = "";
                    txtMedSearch.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnCancelMed_Click(object sender, RoutedEventArgs e)
        {
            txtMedName.Text = "";
            txtMedPrice.Text = "";
            txtMedSearch.Text = "";
        }

//*********************************Serices Code**********************************************
        private void bttnSearchService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select * from Services where serviceName like  '%' + @service + '%'", con);
                    cmd.Parameters.AddWithValue("@service", txtServiceSearch.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtServiceName.Text = (String)rdr["serviceName"];
                        decimal cost = (decimal)rdr["amount"];
                        txtSericeAmount.Text = cost.ToString();
                    }
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnAddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("insert into Services (serviceName, amount) values(@service, convert(decimal,@amount))", con);
                    cmd.Parameters.AddWithValue("@service", txtServiceName.Text);
                    cmd.Parameters.AddWithValue("@amount", txtSericeAmount.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Service added Successfully");

                    }
                    txtServiceName.Text = "";
                    txtSericeAmount.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnUpdateService_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("update Services set serviceName = @service, amount = @amount where serviceName = @serviceSearch", con);
                    cmd.Parameters.AddWithValue("@service", txtServiceName.Text);
                    cmd.Parameters.AddWithValue("@amount", txtSericeAmount.Text);
                    cmd.Parameters.AddWithValue("@serviceSearch", txtServiceSearch.Text);

                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Data Updated Successfully");

                    }

                    txtServiceName.Text = "";
                    txtSericeAmount.Text = "";
                    txtServiceSearch.Text = "";
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("delete from Services where serviceName=@service", con);
                    cmd.Parameters.AddWithValue("@service", txtServiceName.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        System.Windows.MessageBox.Show("Service Deleted Successfully");

                    }
                    txtServiceName.Text = "";
                    txtSericeAmount.Text = "";
                    txtServiceSearch.Text = "";
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }

        private void bttnCancelService_Click(object sender, RoutedEventArgs e)
        {
            txtServiceName.Text = "";
            txtSericeAmount.Text = "";
            txtServiceSearch.Text = "";
        }

        private void bttnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text.Equals(txtconfirmPassword.Text))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(cons))
                    {
                        SqlCommand cmd = new SqlCommand("insert into login (username, password) values(@username, @password)", con);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            System.Windows.MessageBox.Show("New User Added Successfully");

                        }
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtconfirmPassword.Text = "";
                    }
                }
                catch (Exception cs)
                {
                    System.Windows.MessageBox.Show(cs.Message);
                }
            }

            else
            {
                System.Windows.MessageBox.Show("Password Mismatch! enter again.");
                txtPassword.Text = "";
                txtconfirmPassword.Text = "";
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
            Window W = new ResetPassword1();
            W.Show();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Dashboard();
            w.Show();
            this.Close();
        }

      
        
    }
}
