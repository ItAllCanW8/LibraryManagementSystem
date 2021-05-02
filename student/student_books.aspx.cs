using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.student
{
    public partial class student_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string penalty = "0";
        double numOfDays = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            if (Session["student"] == null)
                Response.Redirect("student_login.aspx");

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from penalty";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                penalty = dr["penalty"].ToString();
            }

            DataTable dt_temp = new DataTable();
            dt_temp.Clear();
            dt_temp.Columns.Add("student_enroll_num");
            dt_temp.Columns.Add("book_isbn");
            dt_temp.Columns.Add("book_issue_date");
            dt_temp.Columns.Add("book_approx_return_date");
            dt_temp.Columns.Add("student_username");
            dt_temp.Columns.Add("is_book_returned");
            dt_temp.Columns.Add("book_return_date");
            dt_temp.Columns.Add("delay_for_days");
            dt_temp.Columns.Add("penalty");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book where student_username='"+ Session["student"].ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr_temp = dt_temp.NewRow();
                dr_temp["student_enroll_num"] = dr["student_enroll_num"].ToString();
                dr_temp["book_isbn"] = dr["book_isbn"].ToString();
                dr_temp["book_issue_date"] = dr["book_issue_date"].ToString();
                dr_temp["book_approx_return_date"] = dr["book_approx_return_date"].ToString();
                dr_temp["student_username"] = dr["student_username"].ToString();
                dr_temp["is_book_returned"] = dr["is_book_returned"].ToString();
                dr_temp["book_return_date"] = dr["book_return_date"].ToString();

                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr["book_approx_return_date"].ToString());

                if (d1 > d2)
                {
                    TimeSpan t = d1 - d2;
                    numOfDays = t.TotalDays;
                    dr_temp["delay_for_days"] = numOfDays.ToString();
                }
                else
                    dr_temp["delay_for_days"] = "0";

                dr_temp["penalty"] = Convert.ToString(Convert.ToDouble(numOfDays) * Convert.ToDouble(penalty));
                dt_temp.Rows.Add(dr_temp);
            }

            d1.DataSource = dt_temp;
            d1.DataBind();
        }
    }
}