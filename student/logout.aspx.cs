using System;


namespace LibraryManagementSystem.student
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("student_login.aspx");
        }
    }
}