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
    /// Interaction logic for ResetPassword1.xaml
    /// </summary>
    public partial class ResetPassword1 : Window
    {
        public ResetPassword1()
        {
            InitializeComponent();
        }

        string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private void bttnAddUser_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUsername.Text;
            String password = "";
            try
            {
                using (SqlConnection con = new SqlConnection(cons))
                {
                    SqlCommand cmd = new SqlCommand("select * from login where username = @username", con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String name = (String)rdr["username"];
                        password = (String)rdr["password"];

                        if (username.Equals(name))
                        {
                            Window W = new ResetPassword2(name, password);
                            W.Show();
                            this.Close();

                        }

                        else
                        {
                            System.Windows.MessageBox.Show("Enter valid username");
                            txtUsername.Text = "";

                        }

                    }
                }
            }

            catch (Exception cs)
            {
                System.Windows.MessageBox.Show(cs.Message);
            }
        }
    }
}
