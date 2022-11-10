using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Teretana
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
            }
        }
        protected void FillDropDownList()
        {
            ddlTeretana.Items.Clear();
            ddlTeretana.Items.Add(new ListItem("Selektujte teretanu:"));
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connection.conString;
            SqlDataReader reader;

            SqlCommand cmd = new SqlCommand("Select idOsobe, idTeretane from Osoba", con);
            using (con)
            {
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["idTerertane"].ToString();
                        item.Value = reader["idOsobe"].ToString();
                        ddlTeretana.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        protected void ddlTeretana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SqlSelect = "Select * from Employees where EmployeeID='" + ddlTeretana.SelectedItem.Value + "'";
            SqlConnection con = new SqlConnection(); 
            con.ConnectionString = Connection.conString;
            SqlCommand cmd = new SqlCommand(SqlSelect, con); 
            SqlDataReader reader; 
            using (con)
            {
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader(); 
                    reader.Read(); 

                   
                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }

    }
}