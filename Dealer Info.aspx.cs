using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem
{
    public partial class Dealer_Info : System.Web.UI.Page
    {
        SqlConnection con = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DbCon()
        {
            try
            {
                String strCon = "Data Source=DESKTOP-E3I7MOH\\ABDURRAHMANSQL;Initial Catalog=InventorySystem;Integrated Security=True";
                con = new SqlConnection(strCon);
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            DbCon();
            String query = "insert into Dealer_Info(dealer_name,dealer_company_name,contact ,adderss,city) values(@dname ,@dcname,@dcontact,@daddress,@dcity)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@dname", tbxdname.Text);
            cmd.Parameters.AddWithValue("@dcname", tbxdcname.Text);
            cmd.Parameters.AddWithValue("@dcontact", tbxdcontact.Text);
            cmd.Parameters.AddWithValue("@daddress", tbxdaddress.Text);
            cmd.Parameters.AddWithValue("@dcity", tbxdcity.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}