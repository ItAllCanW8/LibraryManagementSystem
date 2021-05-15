using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class issue_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");

            if (IsPostBack) return;

            enrnum.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select enrollment_num from student";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
                enrnum.Items.Add(dr["enrollment_num"].ToString());

            isbn.Items.Clear();
            isbn.Items.Add("Select");
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select book_isbn from book";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
                isbn.Items.Add(dr["book_isbn"].ToString());

        }

        protected void b1_Click(object sender, EventArgs e)
        {

            if (isbn.SelectedItem.ToString() == "Select")
                Response.Write("<script>alert('select books'); window.location.href=window.location.href</script>");
            else
            {
                int found = 0;

                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "select * from issued_book where student_enroll_num='" + enrnum.SelectedItem.ToString() + "' and book_isbn='" + isbn.SelectedItem.ToString() + "' and is_book_returned='no'";
                cmd0.ExecuteNonQuery();

                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);

                found = Convert.ToInt32(dt0.Rows.Count.ToString());

                if (found > 0)
                    Response.Write("<script>alert('this book is already rented by this student'); </script>");
                else
                {
                    // if (inStock.Text == "0")
                    Response.Write("<script>alert('" + inStock.Text == "0" + "');</script>");
                    if (inStock.Text == "Available quantity: 0")
                        Response.Write("<script>alert('this book is not in stock');</script>");
                    else
                    {
                        string books_issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                        string approx_return_date = DateTime.Now.AddDays(30).ToString("yyyy/MM/dd");
                        string username = "";

                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select * from student where enrollment_num='" + enrnum.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();

                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(dt2);

                        foreach (DataRow dr2 in dt2.Rows)
                            username = dr2["username"].ToString();

                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "insert into issued_book values('" + enrnum.SelectedItem.ToString() + "','"
                            + isbn.SelectedItem.ToString() + "','" + books_issue_date.ToString() + "','"
                            + approx_return_date.ToString() + "','" + username.ToString() + "','no','no')";
                        cmd3.ExecuteNonQuery();

                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "update book set available_qty=available_qty-1 where book_isbn='" 
                            + isbn.SelectedItem.ToString() + "'";
                        cmd4.ExecuteNonQuery();

                        Response.Write("<script>alert('book issued'); window.location.href=window.location.href;</script>");
                    }
                }
            }
        }
        protected void isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            img.ImageUrl = "";
            bookName.Text = "";
            inStock.Text = "";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from book where book_isbn='" + isbn.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                img.ImageUrl = dr["book_image"].ToString();
                bookName.Text = "Title: " + dr["book_title"].ToString();
                inStock.Text = "Available quantity: " + dr["available_qty"].ToString();
            }
                
        }
    }
}