using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.student
{
    public partial class display_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["student"] == null)
                Response.Redirect("student_login.aspx");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            r1.DataSource = dt;
            r1.DataBind();
        }
        public string checkVideo(object value, object id)
        {
            //value == System.DBNull.Value ||
            if (value == "")
                return "Not Available";
            else
            {
                value = "../librarian/" + value.ToString(); 
                return "<a href='" + value.ToString() + "' style='color:green'>view</a>";
            }
                
        }

        public string checkPdf(object value1, object id1)
        {
            //value == System.DBNull.Value ||
            if (value1 == "")
                return "Not Available";
            else
            {
                value1 = "../librarian/" + value1.ToString();
                return "<a href='" + value1.ToString() + "' style='color:green'>view</a>";
            }
                
        }

    }
}