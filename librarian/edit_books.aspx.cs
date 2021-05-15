using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class edit_books : System.Web.UI.Page
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

            if (IsPostBack) 
                return;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book where id=" + id + "";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                title.Text = dr["book_title"].ToString();
                author.Text = dr["book_author_name"].ToString();
                isbn.Text = dr["book_isbn"].ToString();
                quantity.Text = dr["available_qty"].ToString();
                image.Text = dr["book_image"].ToString();
                pdf.Text = dr["book_pdf"].ToString();
                video.Text = dr["book_video"].ToString();
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string bookImageName = "";
            string bookPdf = "";
            string bookVideo = "";

            string path = "";
            string path2 = "";
            string path3 = "";

            if (f1.FileName.ToString() != "")
            {
                bookImageName = Class1.GetRandomPassword(10) + ".jpg";
                f1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + bookImageName.ToString());
                path = "books_images/" + bookImageName.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_title='" + title.Text + "',book_image='" + path.ToString() +
                    "',book_author_name='" + author.Text + "'," + "book_isbn='" + isbn.Text + "',available_qty='" 
                    + quantity.Text + "' where id=" + id;
                cmd.ExecuteNonQuery();
            }

            if (f2.FileName.ToString() != "")
            {
                bookPdf = Class1.GetRandomPassword(10) + ".pdf";
                f2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + bookPdf.ToString());
                path2 = "books_pdf/" + bookPdf.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_title='" + title.Text + "',book_pdf='" + path2.ToString() +
                    "',book_author_name='" + author.Text + "'," + "book_isbn='" + isbn.Text + "',available_qty='"
                    + quantity.Text + "' where id=" + id;
                cmd.ExecuteNonQuery();
            }

            if (f3.FileName.ToString() != "")
            {
                bookVideo = Class1.GetRandomPassword(10) + ".mp4";
                f3.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_videos/" + bookVideo.ToString());
                path3 = "books_videos/" + bookVideo.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_title='" + title.Text + "',book_video='" + path3.ToString() +
                    "',book_author_name='" + author.Text + "'," + "book_isbn='" + isbn.Text + "',available_qty='"
                    + quantity.Text + "' where id=" + id;
                cmd.ExecuteNonQuery();
            }

            if (f1.FileName.ToString() == "" && f2.FileName.ToString() == "" && f3.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set book_title='" + title.Text + "',book_author_name='" 
                    + author.Text + "'," + "book_isbn='" + isbn.Text + "',available_qty='"
                    + quantity.Text + "' where id=" + id;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("display_books.aspx");
        }
    }
}