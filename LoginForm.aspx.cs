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
    public partial class LoginForm : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
           
            DbCon();
            String query = "select * from SignUp where username='"+tbxname.Text+"' and password='"+tbxpass.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
           i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                lblerror.Text = "incorrect username or password";
            }
            else
            {
                Response.Redirect("Unit.aspx");

            }
            con.Close();
        }
    }
}