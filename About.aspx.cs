using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Teretana
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        


        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Connection.conString))
            {
                try
                {
                    conn.Open();
                    string cmdInsert = "INSERT INTO Osoba(ime, prezime,datumRodjenja,kontakt,idTeretane) VALUES(@ime,@prezime,@datumRodjenja, @kontakt, @idTeretane)";
                    using (SqlCommand cmd = new SqlCommand(cmdInsert, conn))
                    {

                        cmd.Parameters.AddWithValue("@ime", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@prezime", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@datumRodjenja", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@kontakt", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@idTeretane", TextBox4.Text);
                        Label1.Text = "Dodat je novi";
                        /*int dodat = cmd.ExecuteNonQuery();
                        if (dodat == 1)
                        {
                            
                            FillDropDownList();
                        }*/
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