using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Gallaxy_Hospital
{
    public partial class WindowGraph : Form
    {
        public WindowGraph()
        {
            InitializeComponent();
            drpPattern.Items.Add("Yearly");
            drpPattern.Items.Add("Monthly");
            drpPattern.Items.Add("Daily");
            chart2.Visible = false;
            chart1.Visible = false;
        }

      string cons = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;


  


        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {

                using (SqlConnection con = new SqlConnection(cons))
                {

                    if (drpPattern.SelectedItem == "Yearly")
                    {
                        chart2.Visible = true;
                        chart1.Visible = false;
                        SqlCommand cmd = new SqlCommand("SELECT DATEPART(year, DateofAdmission) as 'Year', COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY DATEPART(year, DateofAdmission) ORDER BY 'Year'", con);
                        cmd.Parameters.AddWithValue("@fromDate", dateFrom.Value.ToString());
                        cmd.Parameters.AddWithValue("@toDate", dateTo.Value.ToString());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // int no = (int)rdr["No. of Patient"];
                            this.chart2.Series["No of Patients"].Points.AddXY((int)rdr["Year"], (int)rdr["No. of Patient"]);

                        }
                    }

                    else if (drpPattern.SelectedItem == "Monthly")
                    {
                        chart2.Visible = true;
                        chart1.Visible = false;
                        SqlCommand cmd = new SqlCommand("SELECT DATEPART(month, DateofAdmission) as 'Month', COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY DATEPART(month, DateofAdmission) ORDER BY 'month'", con);
                        cmd.Parameters.AddWithValue("@fromDate", dateFrom.Value.ToString());
                        cmd.Parameters.AddWithValue("@toDate", dateTo.Value.ToString());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // int no = (int)rdr["No. of Patient"];
                            this.chart2.Series["No of Patients"].Points.AddXY((int)rdr["Month"], (int)rdr["No. of Patient"]);

                        }

                    }


                    else 
                    {
                        chart2.Visible = false;
                        chart1.Visible = true;
                        SqlCommand cmd = new SqlCommand("SELECT DateofAdmission, COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY DateofAdmission ORDER BY 'DateofAdmission'", con);
                        cmd.Parameters.AddWithValue("@fromDate", dateFrom.Value.ToString());
                        cmd.Parameters.AddWithValue("@toDate", dateTo.Value.ToString());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // int no = (int)rdr["No. of Patient"];
                            this.chart1.Series["No of Patients"].Points.AddXY((DateTime)rdr["DateofAdmission"], (int)rdr["No. of Patient"]);

                        }

                    }

                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}

