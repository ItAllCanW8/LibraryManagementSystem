using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class delete_files : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");

            if (Request.QueryString["id"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_video='' where id='" + Request.QueryString["id"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            else if (Request.QueryString["id1"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_pdf='' where id='" + Request.QueryString["id1"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from book where id='"+ Request.QueryString["id2"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("display_books.aspx");
        }
    }
}