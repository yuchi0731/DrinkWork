using DOS_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class ModifyUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //可能是按按鈕跳回本頁，所以要判斷Postback
            {
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                //取得現在使用者是誰
                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null) //如果帳號不存在，導向登入頁
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServerSide/UserManagement/ModifyUserInfo.aspx");
        }
    }
}