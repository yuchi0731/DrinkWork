using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (currentUser.JobGrade < 1)
            {
                Response.Redirect("/ServerSide/SystemAdmin/UserPage.aspx");
                return;
            }

            //取得從UserList選到的帳號
            string idText = this.Request.QueryString["EmployeeID"];
            var userInfo = UserInfoManager.GetUserInfofromID(Convert.ToInt32(idText));
            this.ltUser.Text = userInfo.Account;

            var list = UserInfoManager.GetuserInfoLINQ(userInfo.Account);


            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var pageUserList = this.GetPageDataTable(list);
                this.gvModifyList.DataSource = pageUserList;
                this.gvModifyList.DataBind();
                this.plcNoData.Visible = false;
                this.lbMsg.Text = null;

            }
            else
            {
                this.gvModifyList.Visible = false;
                this.plcNoData.Visible = true;
            }


        }

        private List<UserInfo> GetPageDataTable(List<UserInfo> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }


        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }



        protected void gvModifyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.plcNoData.Visible = false;
            this.lbMsg.Text = null;

            if (string.Compare("btnModify", e.CommandName, true) == 0)
            {

                //取得從UserList選到的帳號
                string idText = this.Request.QueryString["EmployeeID"];
                var userdata = UserInfoManager.GetUserInfofromID(Convert.ToInt32(idText));

                var item = e.CommandSource as Button;
                var container = item.NamingContainer;


                TextBox DID = container.FindControl("txtDID") as TextBox;
                string txtDID = DID.Text;


                TextBox D = container.FindControl("txtD") as TextBox;
                string txtD = D.Text;


                TextBox LName = container.FindControl("txtLName") as TextBox;
                string txtLName = LName.Text;

                TextBox FName = container.FindControl("txtFName") as TextBox;
                string txtFName = FName.Text;

                DropDownList dpcontact = container.FindControl("dpContact") as DropDownList;
                string dpContact = dpcontact.SelectedItem.Text;

                TextBox Email = container.FindControl("txtEmail") as TextBox;
                string txtEmail = Email.Text;

                TextBox ext = container.FindControl("txtext") as TextBox;
                string txtext = ext.Text;

                TextBox Phone = container.FindControl("txtPhone") as TextBox;
                string txtPhone = Phone.Text;

                TextBox RepS = container.FindControl("txtRepS") as TextBox;
                string txtRepS = RepS.Text;

                DropDownList dpjobGrade = container.FindControl("dpJobGrade") as DropDownList;
                var dpJobGrade = dpjobGrade.SelectedIndex;

                TextBox desc = container.FindControl("txtdesc") as TextBox;
                string txtdesc = desc.Text;

                FileUpload fphoto = container.FindControl("filePhoto") as FileUpload;
                string photo = fphoto.ToString();


                var hasphoto = (container.FindControl("filePhoto") as FileUpload);
                var filePhoto = (container.FindControl("filePhoto") as FileUpload).ToString();

                var lastModified = DateTime.Now;


                if (dpContact != "Email" && dpContact != "分機" && dpContact != "電話")
                {
                    this.plcNoData.Visible = true;
                    this.lbMsg.Text = "聯絡方式選項錯誤，請重新選擇";
                    return;
                }



                UserInfo userInfo = new UserInfo()
                {
                    Account = userdata.Account,
                    EmployeeID = userdata.EmployeeID,
                    DepartmentID = txtDID,
                    Department = txtD,
                    FirstName = txtFName,
                    LastName = txtLName,
                    Contact = dpContact,
                    Email = txtEmail,
                    ext = txtext,
                    Phone = txtPhone,
                    JobGrade = dpJobGrade,
                    Description = txtdesc,
                    ResponseSuppliers = txtRepS,
                    Photo = photo,
                    CreateDate = userdata.CreateDate

                };


                //假設有上傳檔案，就寫入檔名
                if (photo != null && FileUploadManager.VaildFileUpload(fphoto, out List<string> tempList))
                {
                    string saveFileName = FileUploadManager.GetNewFileName(fphoto);
                    string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                    fphoto.SaveAs(filePath);

                    userInfo.Photo = saveFileName;

                }



                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("即將變更資料，繼續請按確定", "確認變更",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);


                if (MsgBoxResult == DialogResult.OK)
                {

                    UserInfoManager.UpdateUserInfo(userInfo);


                    MsgBoxResult = MessageBox.Show("修改成功，將導至使用者清單頁", "修改成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
                }
                else
                {
                    this.plcNoData.Visible = true;
                    this.lbMsg.Text = "修改取消，尚未存取變更";
                    return;
                }

            }

            if (string.Compare("btnClear", e.CommandName, true) == 0)
            {
                Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
            }

        }
        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/ServerSide/ImagesServer");
        }
    }
}