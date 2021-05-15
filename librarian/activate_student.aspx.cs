using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class activate_student : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update student set approved='yes' where id='"+ id +"'";
            cmd.ExecuteNonQuery();

            Response.Redirect("display_students.aspx");
        }
    }
}