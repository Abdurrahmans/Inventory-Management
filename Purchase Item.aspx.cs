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
    public partial class Purchase_Item : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
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

        private void LoadGrid()
        {
            DbCon();
            string query = "select * from Purchase_master";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            DbCon();
            SqlCommand cmd = new SqlCommand("insert into Purchase_master(Product_name,product_quantity,product_price,total_product,purchase_date,purchase_party_name,purchase_type,expair_date,profit) values (@pname,@pquntity,@tproduct, @pprice,@pdate,@ppname,@ptype,@edate,@profit)", con);
            cmd.Parameters.AddWithValue("@pname", DropDownList1.Text.ToString());
            cmd.Parameters.AddWithValue("@pquntity", tbxpqn.Text.ToString());
            cmd.Parameters.AddWithValue("@tproduct", tbxtproduct.Text.ToString());
            cmd.Parameters.AddWithValue("@pprice", tbxprice.Text.ToString());
            cmd.Parameters.AddWithValue("@pdate", tbxpdate.Text.ToString());
            cmd.Parameters.AddWithValue("@ppname", DropDownList2.Text.ToString());
            cmd.Parameters.AddWithValue("@ptype", DropDownList3.Text.ToString());
            cmd.Parameters.AddWithValue("@edate", tbxedate.Text.ToString());
            cmd.Parameters.AddWithValue("@profit", tbxprofit.Text.ToString());
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void tbxprice_TextChanged(object sender, EventArgs e)
        {
            tbxtproduct.Text  = Convert.ToString(Convert.ToInt32(tbxpqn.Text) * Convert.ToInt32(tbxprice.Text));
        }
    }
}