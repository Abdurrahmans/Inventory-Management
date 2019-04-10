using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem
{
    public partial class Product : System.Web.UI.Page
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

        protected void btn2_Click(object sender, EventArgs e)
        {
            DbCon();
            SqlCommand cmd = new SqlCommand("insert into Product(ProductName, unit) values (@pname,@unit)", con);
            cmd.Parameters.AddWithValue("@pname", tbxpd.Text.ToString());
            cmd.Parameters.AddWithValue("@unit", DropDownList1.Text.ToString());
           

            cmd.ExecuteNonQuery();

            con.Close();


        }







    }
}