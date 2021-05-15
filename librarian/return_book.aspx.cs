using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
	public partial class return_book : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
		int id;
		string book_isbn = "";
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
			cmd.CommandText = "update issued_book set is_book_returned='yes',book_return_date='" + DateTime.Now.ToString("yyyy/MM/dd")+"' where id='"+ id +"'";
			cmd.ExecuteNonQuery();

			SqlCommand cmd1 = con.CreateCommand();
			cmd1.CommandType = CommandType.Text;
			cmd1.CommandText = "select * from issued_book where id='" + id + "'";
			cmd1.ExecuteNonQuery();

			DataTable dt1 = new DataTable();
			SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
			da1.Fill(dt1);

			foreach (DataRow dr in dt1.Rows)
				book_isbn = dr["book_isbn"].ToString();

			SqlCommand cmd2 = con.CreateCommand();
			cmd2.CommandType = CommandType.Text;
			cmd2.CommandText = "update book set available_qty=available_qty+1 where book_isbn='"+ book_isbn.ToString() +"'";
			cmd2.ExecuteNonQuery();

			Response.Redirect("get_books_back.aspx");
		}
	}
}