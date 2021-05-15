using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class add_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string bookImageName = Class1.GetRandomPassword(10) + ".jpg";
            string bookPdf = "";
            string bookVideo = "";

            f1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + bookImageName.ToString());
            string path = "books_images/" + bookImageName.ToString();

            string path2 = "";
            string path3 = "";

            if (f2.FileName.ToString() != "")
            {
                bookPdf = Class1.GetRandomPassword(10) + ".pdf";
                f2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + bookPdf.ToString());
                path2 = "books_pdf/" + bookPdf.ToString();
            }

            if (f3.FileName.ToString() != "")
            {
                bookVideo = Class1.GetRandomPassword(10) + ".mp4";
                f3.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_videos/" + bookVideo.ToString());
                path3 = "books_videos/" + bookVideo.ToString();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into book values('" + title.Text + "','" + path.ToString() + "','"
                + path2.ToString() + "','" + path3.ToString() +  "','" + author.Text + "','" + isbn.Text + "', '" 
                + quantity.Text + "')";
            cmd.ExecuteNonQuery();

            msg.Style.Add("display", "block");
        }
    }
}