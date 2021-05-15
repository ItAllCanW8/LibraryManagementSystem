using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class load_new_messages : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string msg = "";
        int count = 0;
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");

            username = Request.QueryString["username"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where recipient_username='librarian' and is_read='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                count++;

                if (count == 1)
                    msg = dr["sender_username"].ToString() + ":" + dr["msg"].ToString();
                else
                    msg = msg + "||abcd||" + dr["sender_username"].ToString() + ":" + dr["msg"].ToString();


                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update messages set is_read='yes' where id="+ dr["id"].ToString() +"";
                cmd1.ExecuteNonQuery();
            }

            if (count == 0)
                Response.Write("0");
            else
                Response.Write(msg.ToString());
        }
    }
}