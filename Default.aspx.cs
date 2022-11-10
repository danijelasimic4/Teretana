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
        public void FillDropDownList()
        {
            ddlTeretana.Items.Clear();
            ddlTeretana.Items.Add(new ListItem("Selektujte teretanu:"));
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                conn.Open();
                string cmdSelect = "SELECT idTeretane,idOsobe FROM Osoba";
                using (SqlCommand cmd = new SqlCommand(cmdSelect, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["idTeretane"].ToString();
                        item.Value = reader["idOsobe"].ToString();
                        ddlTeretana.Items.Add(item);
                    }
                    reader.Close();
                }
            }

        }
        protected void ddlTeretana_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SqlSelect = "Select * from Osoba where idOsobe='" + ddlTeretana.SelectedItem.Value + "'";
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