using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class librarian : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where recipient_username='librarian' and is_read='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            count = Convert.ToInt32(dt.Rows.Count.ToString());

            notification1.Text = count.ToString();
            notification2.Text = count.ToString();

            r1.DataSource = dt;
            r1.DataBind();
        }

        public string getTwentyCharacters(object msg) 
        {
            string s = Convert.ToString(msg.ToString());

            if (s.Length >= 15)
                return s.Substring(0, 15).ToString() + "..";
            else
                return s.ToString();
        }
    }
}