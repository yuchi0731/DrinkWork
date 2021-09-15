using DOS_Auth;
using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //可能是按按鈕跳回本頁，所以要判斷Postback
            {
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }


                var current = AuthManager.GetCurrentUser();

                var hasCheckoutList = DrinkListManager.GetneedCheckoutOrderList(current.Account);
                if (hasCheckoutList != null)
                {
                    DialogResult MsgBoxResult;
                    MsgBoxResult = MessageBox.Show("~提醒您尚有未結帳訂單~", "提醒",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                var goingtoendList = DrinkListManager.GetGTEOrderListInfo(current.Account);
                if (goingtoendList.Established != "YES" && goingtoendList.RequiredTime < DateTime.Now.AddMinutes(90))
                {
                    DialogResult MsgBoxResult;
                    MsgBoxResult = MessageBox.Show($"訂單【{goingtoendList.OrderNumber}】即將過期，請盡速送出訂購單", "提醒",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }



                
                var userInfo = UserInfoManager.GetUserInfo(current.Account);
                var orderNumber = DrinkListManager.GetUserLastOrderNumber(current.Account);
                this.ltAccount.Text = current.Account.ToString();
                this.ltOrderNumber.Text = $"{goingtoendList.OrderNumber.ToString()}";

                if (userInfo.JobGrade == 0)
                {
                    this.lbuserlevel.Text = "一般會員";
                    this.lbuserlevel.ForeColor = Color.Blue;

                }
                if (userInfo.JobGrade == 1)
                {
                    this.lbuserlevel.Text = "管理者";
                    this.lbuserlevel.ForeColor = Color.Green;

                }

                if (userInfo.JobGrade == 2)
                {
                    this.lbuserlevel.Text = "高階管理者";
                    this.lbuserlevel.ForeColor = Color.Red;
                }




            }
        }

        protected void btnChangePWD_Click(object sender, EventArgs e)
        {

            Response.Redirect("/ServerSide/UserManagement/ModifyPassword.aspx");
        }
    }
}