using DOS_Auth;
using DOS_DBSoure;
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


            var current = AuthManager.GetCurrentUser();
            var orderNumber = DrinkListManager.GetUserLastOrderNumber(current.Account);
            string runMsg = $"～歡迎～{current.FirstName}! 您目前使用等級為是{current.JobGrade}，最近下的訂單是【{orderNumber}】";
            string text = "<MARQUEE>" + runMsg + "</MARQUEE>";
            lbTopMsg.Text = text;


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

        //protected void timerTop_Tick(object sender, EventArgs e)
        //{
        //    var current = AuthManager.GetCurrentUser();
        //    var orderNumber = DrinkListManager.GetUserLastOrderNumber(current.Account);
        //    string runMsg = $"～歡迎～{current.FirstName}! 您目前使用等級為是{current.JobGrade}，最近下的訂單是【{orderNumber}】";

        //    string newst = runMsg.Substring(0, 1); //第一個字
        //    runMsg = runMsg.Substring(1, runMsg.Length - 1) + newst;
        //    //新字串每次從第二個字開始抓，然後把之前抓的第一個字補在最後

        //    lbTopMsg.Text = runMsg; //顯示字串
        //}
    }
}