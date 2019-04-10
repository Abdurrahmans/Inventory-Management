using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem
{
    public partial class WebForm1 : System.Web.UI.Page
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
        protected void Btn1_Click(object sender, EventArgs e)
        {
            DbCon();
            int Count = 0;
            String query = "select * from Unit11 where addunit='"+ tbxunit.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(cmd);
            _da.Fill(dt);
            Count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (Count == 0)
            {
                string query1 = "insert into Unit11(addunit) values(@anit)";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@anit", tbxunit.Text);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                Response.Write("The unit is already added");
            }
            

        }
    }
}