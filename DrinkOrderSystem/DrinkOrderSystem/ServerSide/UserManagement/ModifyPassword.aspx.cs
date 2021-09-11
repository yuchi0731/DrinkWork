using DOS_Auth;
using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class ModifyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            //取得從UserList選到的帳號
            string account = this.Request.QueryString["Account"];
            var useraccount = UserInfoManager.GetUserAccount(account);
            var userInfo = UserInfoManager.GetUserInfo(account);
            var pwd = useraccount.Password;

            var PWD = txtPWD.Text;
            var newPWD = txtNewPWD.Text;
            var RenewPWD = txtReNewPWD.Text;
            var newPWDL = newPWD.Length;
            var RenewPWDL = RenewPWD.Length;

            if (string.Compare(pwd, PWD, false) == 0)
            {
                if (newPWDL < 8 || RenewPWDL > 16)//檢查密碼長度
                {
                    this.lbMsg.Visible = true;
                    this.lbMsg.Text = "密碼需介於8～16個字";
                    return;
                }

                if (string.Compare(newPWD, RenewPWD, false) == 0)
                {
                 
                    //判斷是否為普通使用者
                    if(userInfo.JobGrade != 0)
                    {
                        DialogResult MsgBoxResult;
                        MsgBoxResult = MessageBox.Show("即將變更密碼，繼續請按確定", "確認更改密碼？",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error);

                        if (MsgBoxResult == DialogResult.OK)
                                {
                                    AuthManager.Logout();
                                    UserInfoManager.UpdateUserPWDlinq(account, newPWD);
                                    Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
                                }
                                else
                                {
                                    return;
                                }
                    }

                    else
                    {
                        DialogResult MsgBoxResult;
                        MsgBoxResult = MessageBox.Show("即將變更密碼，變更後將登出，繼續請按確定", "確認更改密碼？",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error);

                        if (MsgBoxResult == DialogResult.OK)
                        {
                            AuthManager.Logout();
                            UserInfoManager.UpdateUserPWDlinq(account, newPWD);
                            Response.Redirect("/ClientSide/Login.aspx");
                        }
                        else
                        {
                            return;
                        }
                    }


                }
                else
                {
                    lbMsg.Visible = true;
                    lbMsg.Text = "新密碼與確認密碼不符，請重新輸入";
                    txtNewPWD = null;
                    txtReNewPWD = null;
                }
            }
            else
            {
                lbMsg.Visible = true;
                lbMsg.Text = "原密碼與資料不符，請重新輸入";
                txtPWD = null;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxChange;
            MsgBoxChange = MessageBox.Show("取消變更將導回使用者清單頁", "確定取消變更？",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error);

            if (MsgBoxChange == DialogResult.OK)
            {
                Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
            }
            else
            {              
               return;
            }
        }
    }
}