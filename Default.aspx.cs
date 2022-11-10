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

        }
        protected void FillDropDownList()
        {
            ddlTeretana.Items.Clear();
            ddlTeretana.Items.Add(new ListItem("Selektujte zaposlenog"));
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connection.conString;
            SqlDataReader reader;
           
 SqlCommand cmd = new SqlCommand("Select FirstName, LastName, EmployeeID from Employees", con);
 using (con)
            {
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["FirstName"].ToString() + " " +
                       reader["LastName"].ToString();
                        item.Value = reader["EmployeeID"].ToString();
                        ddlTeretana.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Desila se greška";
                    lblMessage.Text += ex.Message;
                }
}