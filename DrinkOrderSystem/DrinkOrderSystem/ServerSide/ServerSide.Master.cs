using DOS_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide
{
    public partial class ServerSide : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }

            var currentuser = AuthManager.GetCurrentUser();
            if (currentuser.JobGrade != 0)
                ltlManger.Visible = true;
          

        }
    }
}