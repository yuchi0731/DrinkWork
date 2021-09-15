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
using DOS_ORM.DOSmodel;
using System.IO;

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class CreateNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.lblMsg.Visible = false;
            this.lblMsg2.Visible = false;

            string txtAccount = this.txtCreateAccount.Text;
            string txtPWD = this.txtCreatePWD.Text;
            string txtRePWD = this.txtCreateRePWD.Text;
            string txtDID = this.txtCreateDID.Text;
            string txtD = this.txtCreateD.Text;
            string txtLName = this.txtCreateLName.Text;
            string txtFName = this.txtCreateFName.Text;
            string txtcontact = this.dpCreateContact.SelectedValue.ToString();
            string txtEmail = this.txtCreateEmail.Text;
            string txtext = this.txtCreatext.Text;
            string txtphone = this.txtCreatePhone.Text;
            int jobgrade = this.dpCreateJobGrade.SelectedIndex;
            string photo = "";


            string txtReS = this.txtCreateRepS.Text;
            if (txtReS.Length > 0)
            {
                txtReS = this.txtCreateRepS.Text;
            }
            else
                txtReS = null;

            string desc = this.txtCreatedesc.Text;
            if (desc.Length > 0)
            {
                desc = this.txtCreateRepS.Text;
            }
            else
                desc = null;


            



            string msg;
            string msg2;
            int pwdL = this.txtCreatePWD.Text.Length;
            int rpwdL = this.txtCreateRePWD.Text.Length;

            //取得輸入帳號，檢查帳號是否已存在 
            var drexist = UserInfoManager.GetUserAccount(txtAccount);
            if (drexist == null)
            {

                if (pwdL < 8 || rpwdL > 16)//檢查密碼長度
                {
                    MessageBox.Show($"密碼需介於8～16個字", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (pwdL > 8 && rpwdL < 16)
                {
                    if (!AuthManager.TryCreateUser(txtAccount, txtPWD, txtRePWD, txtDID, txtD, txtFName, txtLName, txtcontact, txtEmail, txtext, txtphone, jobgrade, desc, txtReS, out msg, out msg2))
                    {
                        this.lblMsg.Visible = true;
                        this.lblMsg2.Visible = true;
                        this.lblMsg.Text = msg;
                        this.lblMsg2.Text = msg2;
                        this.lblMsg.ForeColor = Color.Red;
                        this.lblMsg2.ForeColor = Color.Red;
                        return;
                    }

                    else
                    {

                        UserInfo userInfo = new UserInfo()
                        {
                            Account = txtAccount,
                            DepartmentID = txtDID,
                            Department = txtD,
                            FirstName = txtFName,
                            LastName = txtLName,
                            Contact = txtcontact,
                            Email = txtEmail,
                            ext = txtext,
                            Phone = txtphone,
                            JobGrade = jobgrade,
                            Description = desc,
                            ResponseSuppliers = txtReS,
                            Photo = photo,

                        };


                        //假設有上傳檔案，就寫入檔名
                        if (filePhoto.HasFile && FileUploadManager.VaildFileUpload(this.filePhoto, out List<string> tempList))
                        {
                            string saveFileName = FileUploadManager.GetNewFileName(this.filePhoto);
                            string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                            this.filePhoto.SaveAs(filePath);

                            userInfo.Photo = saveFileName;

                        }



                        UserInfoManager.CreateUserlinq(txtAccount, txtPWD);
                        UserInfoManager.CreateNewUserInfo(userInfo);
                        MessageBox.Show("～建立成功～", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
                    }
                }
            }

            else
            {

                MessageBox.Show($"此帳號已存在，請重新輸入", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCreateAccount.Text = null;

            }


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {


            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("尚有未儲存變更，繼續請按確認", "清除",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (MsgBoxResult == DialogResult.OK)
            {

            this.txtCreateAccount.Text = null;
            this.txtCreatePWD.Text = null;
            this.txtCreateRePWD.Text = null;
            this.txtCreateDID.Text = null;
            this.txtCreateD.Text = null;
            this.txtCreateLName.Text = null;
            this.txtCreateFName.Text = null;
            this.dpCreateContact.SelectedIndex = 0;
            this.txtCreateEmail.Text = null;
            this.txtCreatext.Text = null;
            this.txtCreatePhone.Text = null;
            this.txtCreateRepS.Text = null;
            this.dpCreateJobGrade.SelectedIndex = 0;
            this.txtCreatedesc.Text = null;

            }
            else
            {
                this.lblMsg.Visible = true;
                this.lblMsg.Text = "已取消動作";
                return;
            }

        }

        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/ServerSide/ImagesServer");
        }

    }
}