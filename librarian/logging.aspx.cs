using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class logging : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string penalty = "0";
        double numOfDays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from logging";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            d1.DataSource = dt;
            d1.DataBind();
        }
    }
}