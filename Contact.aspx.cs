using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace Teretana
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack) FillDropDownList();
        }
        public void FillDropDownList()
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Selektujte ime:"));
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                conn.Open();
                string cmdSelect = "SELECT ime ,idOsobe FROM Osoba";
                using (SqlCommand cmd = new SqlCommand(cmdSelect, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["ime"].ToString();
                        item.Value = reader["idOsobe"].ToString();
                        ddl.Items.Add(item);
                    }
                    reader.Close();
                }
            }

        }


        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                try
                {
                    conn.Open();
                    string cmdSelect = "Select * from Osoba where idOsobe = @id";
                    using (SqlCommand cmd = new SqlCommand(cmdSelect, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ddl.SelectedItem.Value);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                       
                        TextBox1.Text = reader["idTeretane"].ToString();
                        reader.Close();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                try
                {
                    conn.Open();
                    string cmdUpdate = "UPDATE Osoba SET  idTeretane= @idTeretane WHERE idOsobe=@id";
                    using (SqlCommand cmd = new SqlCommand(cmdUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ddl.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@idTeretane", TextBox1.Text.ToString());
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
    }
