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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;





namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // string pass;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
                //System.Windows.Forms.MessageBox.Show(cons);

                using (SqlConnection con = new SqlConnection(cons))
                {
                    string username = Txt_UserName.Text;
                    SqlCommand cmd = new SqlCommand("Select [password] from login where [username] = '" + username + "'", con);
                    con.Open();
                   string  pass = cmd.ExecuteScalar().ToString();

                   // System.Windows.Forms.MessageBox.Show(pass);

                    if (pass == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Please enter correct user name ");
                    }
                    else if (pass == passwordBox1.Password)
                    {
                        //System.Windows.Forms.MessageBox.Show("Login Succefull ");
                        Window W = new Dashboard();
                        W.Show();
                        this.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Enter Correct Password ");
                    }
                         

                }

            }
             catch (Exception cs)
            {

                 System.Windows.Forms.MessageBox.Show(cs.Message);
            }

          }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

           
           
        }

        //  private void button2_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    
    }

