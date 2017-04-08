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
    public partial class Graphs : Form
    {
        public Graphs()
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
                    String pattern = drpPattern.SelectedItem.ToString();

                    if (pattern.Equals("Yearly"))
                    {
                        chart2.Visible = true;
                        chart1.Visible = false;
                        SqlCommand cmd = new SqlCommand("SELECT DATEPART(year, DateofAdmission) as 'Year', COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY DATEPART(year, DateofAdmission) ORDER BY 'Year'", con);
                        cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFrom.Value.ToString()));
                        cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateTo.Value.ToString()));

                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // int no = (int)rdr["No. of Patient"];
                            this.chart2.Series["No of Patients"].Points.AddXY((int)rdr["Year"], (int)rdr["No. of Patient"]);

                        }
                    }
                        

                    //else if (drpPattern.SelectedItem == "Monthly")
                    else if (pattern.Equals("Monthly"))
                    {
                        chart2.Visible = true;
                        chart1.Visible = false;
                        SqlCommand cmd = new SqlCommand("SELECT DATEPART(month, DateofAdmission) as 'Month', COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY DATEPART(month, DateofAdmission) ORDER BY 'month'", con);
                        cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFrom.Value.ToString()));
                        cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateTo.Value.ToString()));

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
                        cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFrom.Value.ToString()));
                        cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateTo.Value.ToString()));

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


        //Tab 2 -  Diagnosis Wise
        private void bttnLoadDiagnosis_Click(object sender, EventArgs e)
        {
             try
            {

                using (SqlConnection con = new SqlConnection(cons))
                {


                        chart3.Visible = true;

                        SqlCommand cmd = new SqlCommand("SELECT diagnosis, COUNT(srNo) 'No. of Patient' FROM Patient_main where DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY diagnosis ORDER BY diagnosis", con);
                        cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFromDiagnosis.Value.ToString()));
                        cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateToDiagnosis.Value.ToString()));

                        con.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // int no = (int)rdr["No. of Patient"];
                            this.chart3.Series["No of Patients"].Points.AddXY((String)rdr["diagnosis"], (int)rdr["No. of Patient"]);

                        }
                    }
                }

           catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnLoadGender_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cons))
                {


                    chart4.Visible = true;

                    SqlCommand cmd = new SqlCommand("SELECT sex, COUNT(srNo) 'No. of Patient' FROM Patient_main where sex = 'Male'and DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY sex", con);
                    cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFromGender.Value.ToString()));
                    cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateToGender.Value.ToString()));

                    con.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // int no = (int)rdr["No. of Patient"];
                        this.chart4.Series["Male"].Points.AddXY((String)rdr["sex"], (int)rdr["No. of Patient"]);

                    }
                }


                using (SqlConnection con = new SqlConnection(cons))
                {


                    chart4.Visible = true;

                    SqlCommand cmd = new SqlCommand("SELECT sex, COUNT(srNo) 'No. of Patient' FROM Patient_main where sex = 'Female'and DateofAdmission between convert(date,@fromDate,105) and convert(date,@toDate,105) GROUP BY sex", con);
                    cmd.Parameters.AddWithValue("@fromDate", Convert.ToDateTime(dateFromGender.Value.ToString()));
                    cmd.Parameters.AddWithValue("@toDate", Convert.ToDateTime(dateToGender.Value.ToString()));

                    con.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // int no = (int)rdr["No. of Patient"];
                        this.chart4.Series["Female"].Points.AddXY((String)rdr["sex"], (int)rdr["No. of Patient"]);

                    }
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void bttnDashBoard_Click(object sender, EventArgs e)
        {
            //Window w = new Dashboard();
            //w.Show();
           // this.Close();

            Dashboard form = new Dashboard();
            form.Show();
        }
    }
}
