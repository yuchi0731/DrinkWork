using DOS_Auth;
using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Button = System.Web.UI.WebControls.Button;
using TextBox = System.Web.UI.WebControls.TextBox;

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
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }

                //取得現在使用者是誰
                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null) //如果帳號不存在，導向登入頁
                {
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServerSide/UserManagement/ModifyUserInfo.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            

            Response.Redirect("/ServerSide/UserManagement/ModifyUserInfo.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //取得從UserList選到的帳號
            string account = this.Request.QueryString["Account"];
            var userInfo = UserInfoManager.GetUserInfo(account);


            var item = e.CommandSource as Button;
            var container = item.NamingContainer;

            var txtEID = (container.FindControl("txtEID") as TextBox).ToString();
            
            var txtDID = (container.FindControl("txtDID") as TextBox).ToString();
            var txtD = (container.FindControl("txtD") as TextBox).ToString();
            var txtLName = (container.FindControl("txtLName") as TextBox).ToString();
            var txtFName = (container.FindControl("txtFName") as TextBox).ToString();


            var dpContact = (container.FindControl("dpContact") as DropDownList).ToString();
            var txtEmail = (container.FindControl("txtEmail") as TextBox).ToString();
            var txtext = (container.FindControl("txtext") as TextBox).ToString();
            var txtPhone = (container.FindControl("txtPhone") as TextBox).ToString();
            var txtRepS = (container.FindControl("txtRepS") as TextBox).ToString();
            var dpJobGrade = (container.FindControl("dpJobGrade") as DropDownList).ToString();
            var txtdesc = (container.FindControl("txtdesc") as TextBox).ToString();
            var filePhoto = (container.FindControl("filePhoto") as FileUpload).ToString();
            var lastModified = DateTime.Now;

            int EID;
            int jobG;
            if(!int.TryParse(txtEID, out EID))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "員工ID格式錯誤，請重新輸入";
                return;
            }

 
            if(!int.TryParse(dpJobGrade, out jobG))
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "職等選項錯誤，請重新選擇";
                return;
            }


            if(dpContact != "ext" || dpContact != "phone" || dpContact != "email")
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "聯絡方式選項錯誤，請重新選擇";
                return;
            }

            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("即將變更資料，繼續請按確定", "確認變更",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error);

            if (MsgBoxResult == DialogResult.OK)
            {

            UserInfoManager.UpdateUserInfolinq(account, EID, txtDID, txtD, txtFName, txtLName, dpContact, txtEmail, txtext, txtPhone, jobG, txtdesc, txtRepS, filePhoto, lastModified);
                Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
            }
            else
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "取消成功，尚未存取變更";
                return;
            }

        }
    }
}