using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem
{
    public partial class SignUp : System.Web.UI.Page
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
            DbCon();
            String query = "insert into SignUp(Fullname,Email, UserName ,Password,Confirmpassword) values(@fname ,@email,@name,@password,@cpassword)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", tbxfn.Text);
            cmd.Parameters.AddWithValue("@email", tbxemail.Text);
            cmd.Parameters.AddWithValue("@name", tbxname.Text);
            cmd.Parameters.AddWithValue("@password", tbxpass.Text);
            cmd.Parameters.AddWithValue("@cpassword", tbxCpass.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("LoginForm.aspx");
        }
    }
}