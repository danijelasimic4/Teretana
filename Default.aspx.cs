using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


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
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Selektujte teretanu:"));
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                conn.Open();
                string cmdSelect = "SELECT idTeretane,naziv FROM Teretana";
                using (SqlCommand cmd = new SqlCommand(cmdSelect, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["naziv"].ToString();
                        item.Value = reader["idTeretane"].ToString();
                        ddl.Items.Add(item);
                    }
                    reader.Close();
                }
            }
        }

        protected void ddlTeretana_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connection.conString; 
            SqlDataReader reader;
            string SqlSelect = "Select idOsobe AS idOSobe, Osoba.ime AS ime, Osoba.prezime AS prezime,Osoba.datumRodjenja AS datumRodjenja,Osoba.kontakt AS kontakt, Osoba.idTeretane AS idTeretane from Osoba";
            if (ddl.SelectedItem.Text != "Selektujte teretanu:")
                SqlSelect += " WHERE idTeretane = " + ddl.SelectedItem.Value;

            SqlCommand cmd = new SqlCommand(SqlSelect, conn);
            using (conn)
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("idOsobe");
                dataTable.Columns.Add("ime");
                dataTable.Columns.Add("prezime");
                dataTable.Columns.Add("datumRodjenja");
                dataTable.Columns.Add("kontakt");
                dataTable.Columns.Add("idTeretane");
                while (reader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["idOsobe"] = reader["idOsobe"];
                    row["ime"] = reader["ime"];
                    row["prezime"] = reader["prezime"];
                    row["datumRodjenja"] = reader["datumRodjenja"];
                    row["kontakt"] = reader["kontakt"];
                    row["idTeretane"] = reader["idTeretane"];
                    dataTable.Rows.Add(row);
                }
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Obrisi")
            {
                SqlConnection con = new SqlConnection(Connection.conString);
                int rowIndex = Int32.Parse(e.CommandArgument.ToString());
                string osobaId = GridView1.Rows[rowIndex].Cells[0].Text;

                string SqlDelete = "Delete from Osoba where idOsobe= " + osobaId;
                SqlCommand cmd = new SqlCommand(SqlDelete, con);
                int deleted = 0;

                using (con)
                {
                    try
                    {
                        con.Open();
                        deleted = cmd.ExecuteNonQuery();
                        Response.Redirect("~/Default.aspx");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}

        
    
        