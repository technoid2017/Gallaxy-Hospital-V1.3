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
    /// Interaction logic for ResetPassword2.xaml
    /// </summary>
    public partial class ResetPassword2 : Window
    {
        String username = "";
        String password1 = "";

        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public ResetPassword2(String name, String password)
        {
            InitializeComponent();
            username = name;
            password1 = password;
        }

     
        private void bttnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (password1.Equals(txtOldPassword.Text))
            {
                try
                {


                    using (SqlConnection con = new SqlConnection(cons))
                    {
                        SqlCommand cmd = new SqlCommand("update login set password = @password where username = @username", con);
                        cmd.Parameters.AddWithValue("@password", txtNewPassword.Text);
                        cmd.Parameters.AddWithValue("@username", username);


                        con.Open();

                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            System.Windows.MessageBox.Show("Password changed Successfully");

                        }

                        txtOldPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        this.Close();
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

            else
            {
                System.Windows.MessageBox.Show("Enter correct old Password");
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }
    }
}
