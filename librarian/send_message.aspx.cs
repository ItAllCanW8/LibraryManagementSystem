using System;

namespace LibraryManagementSystem.librarian
{
    public partial class send_message1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["librarian"] == null)
                Response.Redirect("login.aspx");
        }
    }
}