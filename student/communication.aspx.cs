using System;

namespace LibraryManagementSystem.student
{
    public partial class communication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student"] == null)
                Response.Redirect("student_login.aspx");
        }
    }
}