using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        SqlConnection conn = new SqlConnection("data source=DESKTOP-B9B8CS7;database=taskday;Integrated security=SSPI");
        SqlCommand comm;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Request.Cookies["Vote"] != null)
                {
                    Label2.Style["display"] = "block";
                    Label3.Style["display"] = "block";
                    Label4.Style["display"] = "block";
                    Label5.Style["display"] = "block";
                    Label6.Style["display"] = "block";
                    RadioButtonList1.Style["Display"] = "none";
                    Button1.Style["Display"] = "none";
                    int excellentcount, vergoodcount, goodcount, acceptcount, poorcount;
                    vergoodcount = goodcount = acceptcount = poorcount = excellentcount = 0;
                    conn.Open();
                    comm = new SqlCommand("Select Vote from Task", conn);
                    SqlDataReader read = comm.ExecuteReader();
                    while (read.Read())
                    {

                        if (read[0].ToString() == "Very Good")
                        {
                            vergoodcount++;
                        }
                        else if (read[0].ToString() == "Good")
                        {
                            goodcount++;
                        }
                        else if (read[0].ToString() == "Accceptable")
                        {
                            acceptcount++;
                        }
                        else if (read[0].ToString() == "Poor")
                        {
                            poorcount++;
                        }
                        else
                        {
                            excellentcount++;

                        }

                    }
                    conn.Close();
                    conn.Open();
                    comm = new SqlCommand("Select Count(*) from Task", conn);
                    int Votecount = (int)comm.ExecuteScalar();
                    double ExeccelentCountPercent = (excellentcount * 100 / Votecount);
                    double VeryGoodCountPercent = (vergoodcount * 100 / Votecount);
                    double GoodCountPercent = (goodcount * 100 / Votecount);
                    double acceptCountPercent = (goodcount * 100 / Votecount);
                    double PoorCountPercent = (poorcount * 100 / Votecount);
                    Label2.Text += ExeccelentCountPercent.ToString("N2") + "%";
                    Label3.Text += VeryGoodCountPercent.ToString("N2") + "%";
                    Label4.Text += GoodCountPercent.ToString("N2") + "%";
                    Label5.Text += acceptCountPercent.ToString("N2") + "%";
                    Label6.Text += PoorCountPercent.ToString("N2") + "%";
                    conn.Close();
                }
                else
                {
                    Label2.Style["Display"] = "None";
                    Label3.Style["Display"] = "None";
                    Label4.Style["Display"] = "None";
                    Label5.Style["Display"] = "None";
                    Label6.Style["Display"] = "None";
                }

            
            }

            protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Style["Display"] = "None";
            Label3.Style["Display"] = "None";
            Label4.Style["Display"] = "None";
            Label5.Style["Display"] = "None";
            Label6.Style["Display"] = "None";
            conn.Open();
            string answer = RadioButtonList1.SelectedValue;
            HttpCookie cook = new HttpCookie("Vote");
            cook["uservote"] = RadioButtonList1.SelectedValue;
            cook.Expires = DateTime.Now.AddDays(90);
            Response.Cookies.Add(cook);
            
            String Query = $"insert into Task(Vote) Values('{RadioButtonList1.SelectedValue}')";
             comm = new SqlCommand(Query,conn);
            comm.ExecuteNonQuery();
            conn.Close();
            Page_Load( sender, e);
        }
    }
}