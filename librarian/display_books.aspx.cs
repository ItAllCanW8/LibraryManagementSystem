using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class display_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");

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
                return value.ToString();
            else
                return "<a href='delete_files.aspx?id=" + id + "' style='color:red'>delete video</a>";
        }

        public string checkPdf(object value1, object id1)
        {
            //value == System.DBNull.Value ||
            if (value1 == "")
                return value1.ToString();
            else
                return "<a href='delete_files.aspx?id1=" + id1 + "' style='color:red'>delete pdf</a>";
        }
    }
}