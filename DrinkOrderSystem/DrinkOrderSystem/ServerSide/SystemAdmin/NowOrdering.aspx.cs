using DOS_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class NowOrdering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }
        }

        protected void btnWithOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServerSide/SystemAdmin/UserList.aspx");
        }

        protected void gvNoworderinglist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        
        }
    }
}