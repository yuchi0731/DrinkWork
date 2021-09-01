using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOS_DBSoure;
using DOS_Auth;
using System.Drawing;
using System.Windows.Forms;
using DOS_ORM;

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class CreateNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
            string txtAccount = this.txtCreateAccount.Text;
            string txtPWD = this.txtCreatePWD.Text;
            string txtRePWD = this.txtCreateRePWD.Text;
            string txtEID = this.txtCreateEID.Text;
            string txtDID = this.txtCreateDID.Text;
            string txtD = this.txtCreateD.Text;
            string txtLName = this.txtCreateLName.Text;
            string txtFName = this.txtCreateFName.Text;
            string txtcontact = this.dpCreateContact.SelectedItem.ToString();
            string txtEmail = this.txtCreateEmail.Text;
            string txtext = this.txtCreateext.Text;
            string txtphone = this.txtCreatePhone.Text;
            int jobgrade = this.dpCreateJobGrade.SelectedIndex;

            string txtReS = this.txtCreateRepS.Text;
            if (txtReS != "")
            {
                txtReS = this.txtCreateRepS.Text;
            }
            else
                txtReS = null;

            string desc = this.txtCreatedesc.Text;
            if (desc != "")
            {
                desc = this.txtCreateRepS.Text;
            }
            else
                desc = null;


            byte[] photo = null;



            string msg;
            string msg2;
            int pwdL = this.txtCreatePWD.Text.Length;
            int rpwdL = this.txtCreateRePWD.Text.Length;

            //取得輸入帳號，檢查帳號是否已存在 
            var drexist = UserInfoManager.GetUserInfoByAccount(txtAccount);
            if (drexist == null)
            {

                if (pwdL < 8 || rpwdL > 16)//檢查密碼長度
                {
                    MessageBox.Show($"密碼需介於8～16個字", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (pwdL > 8 && rpwdL < 16)
                {
                    if (!AuthManager.TryCreateUser(txtAccount, txtPWD, txtRePWD, txtEID, txtDID, txtD, txtFName, txtLName, txtcontact, txtEmail, txtext, txtphone, jobgrade, desc, txtReS, out msg, out msg2))
                    {
                        this.lblMsg.Text = msg;
                        this.lblMsg2.Text = msg2;
                        this.lblMsg.ForeColor = Color.Red;
                        this.lblMsg2.ForeColor = Color.Red;
                        return;
                    }

                    else
                    {
                    
                        //UserInfoManager.CreateNewUser(txtAccount, txtPWD);
                        //UserInfoManager.CreateUserDetail(txtAccount, Convert.ToInt32(txtEID), txtDID, txtD, txtFName, txtLName, txtcontact, txtEmail, txtext, txtphone, jobgrade, desc, txtReS, photo);

                        DateTime CreateDate = DateTime.Now;
                        UserInfoManager.CreateUserlinq(txtAccount, txtPWD);
                        UserInfoManager.CreateNewUserInfolinq(txtAccount, Convert.ToInt32(txtEID), txtDID, txtD, txtFName, txtLName, txtcontact, txtEmail, txtext, txtphone, jobgrade, desc, txtReS, photo, CreateDate, CreateDate);
                        MessageBox.Show("～建立成功～", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Response.Redirect("/ServerSide/UserManagement/UserList.aspx");

                    }
                }
            }

            else
            {

                MessageBox.Show($"此帳號已存在，請重新輸入", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCreateAccount.Text = null;
                this.txtCreatePWD.Text = null;
                this.txtCreateRePWD.Text = null;
                this.txtCreateEID.Text = null;
                this.txtCreateDID.Text = null;
                this.txtCreateD.Text = null;
                this.txtCreateLName.Text = null;
                this.txtCreateFName.Text = null;
                this.dpCreateContact.SelectedIndex = 0;
                this.txtCreateEmail.Text = null;
                this.txtCreateext.Text = null;
                this.txtCreatePhone.Text = null;
                this.txtCreateRepS.Text = null;
                this.dpCreateJobGrade.SelectedIndex = 0;
                this.txtCreatedesc.Text = null;
            }


        }


    }
}