using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.student
{
    public partial class send_from_student : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string username = "";
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["student"] == null)
                Response.Redirect("student_login.aspx");

            username = Session["student"].ToString();
            msg = Request.QueryString["msg"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into messages values('" + username.ToString() + "','librarian','" + msg.ToString() + "','no')";
            cmd.ExecuteNonQuery();
        }
    }
}