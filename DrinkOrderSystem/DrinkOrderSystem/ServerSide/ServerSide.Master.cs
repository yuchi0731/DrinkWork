using DOS_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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

        protected void btnLogut_Click(object sender, EventArgs e)
        {
            DialogResult MsgDelete;
            MsgDelete = MessageBox.Show("即將登出，尚未存取部分將被消除，繼續請按確定", "登出",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning);

            if (MsgDelete == DialogResult.OK)
            {
                AuthManager.Logout();
                Response.Redirect("/ClientSide/Login.aspx");
            }


            else
                return;


        }
    }
}