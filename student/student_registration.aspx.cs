using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace LibraryManagementSystem.student
{
    public partial class student_registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int count2 = 0;

            if (IsReCaptchValid())
            {

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from student where enrollment_num='" + enrollmentNum.Text + "'";
                cmd1.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                    Response.Write("<script>alert('this enrollment number is already registered');</script>");
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from student where username='" + username.Text + "'";
                    cmd2.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);
                    count2 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (count2 > 0)
                    {
                        Response.Write("<script>alert('this username is already registered');</script>");
                    }
                    else 
                    {
                        string randomNum = Class1.GetRandomPassword(10) + ".jpg";
                        string path = "";

                        f1.SaveAs(Request.PhysicalApplicationPath + "/student/student_images/" + randomNum.ToString());
                        path = "/student/student_images/" + randomNum.ToString();

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into student values('" + firstName.Text + "','" + lastName.Text + "','" + enrollmentNum.Text + "','" + username.Text + "','" + password.Text + "','" + email.Text + "','" + contact.Text + "','" + path.ToString() + "','no')";
                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Success');</script>");
                    } 
                }
                
            }
            else          
                lblMessage1.Text = "pass captcha!!";
            
        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6Lc4yMAaAAAAABwfJ00MmTuJUmgiiMiTTcsrF627";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}