using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.student
{
    public partial class load_messages : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["student"] == null)
                Response.Redirect("student_login.aspx");

            username = Session["student"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where (sender_username='" + username.ToString() +
                "' and recipient_username='librarian') or (recipient_username='" + username.ToString() +
                "' and sender_username='librarian')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<p>");
                Response.Write(dr["sender_username"].ToString() + ":" + dr["msg"].ToString());
                Response.Write("</p>");
                Response.Write("<hr>");

                if (dr["recipient_username"].ToString() == username.ToString())
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update messages set is_read='yes' where id=" + dr["id"].ToString() + "";
                    cmd1.ExecuteNonQuery();
                }
            }
        }
    }
}