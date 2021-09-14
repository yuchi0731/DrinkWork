using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DOS_Auth;
using DOS_ORM.DOSmodel;
using Label = System.Web.UI.WebControls.Label;
using Image = System.Web.UI.WebControls.Image;
using Button = System.Web.UI.WebControls.Button;

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }

                var list = UserInfoManager.GetAllUserListLINQ();


                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var pageUserList = this.GetPageDataTable(list);
                    this.gvUserlist.DataSource = pageUserList;
                    this.gvUserlist.DataBind();

                    this.ucPager.TotalSize = list.Count;
                    this.ucPager.Bind();


                }
                else
                {
                    this.gvUserlist.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
                Response.Redirect("/ServerSide/UserManagement/CreateNewUser.aspx");
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

        private List<UserInfo> GetPageDataTable(List<UserInfo> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }

        //gvUserlist事件>職等文字顯示
        protected void gvUserlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {

                Label lbl = row.FindControl("lbluserlevel") as Label;
                Image img = row.FindControl("imgCover") as Image;

                var rowData = row.DataItem as UserInfo;
                int jobGrade = rowData.JobGrade;


                if (jobGrade == 0)
                {
                    lbl.Text = "一般會員";
                    lbl.ForeColor = Color.Blue;
           
                }
                if (jobGrade == 1)
                {
                    lbl.Text = "管理者";
                    lbl.ForeColor = Color.Green;

                }

                if (jobGrade == 2)
                {
                    lbl.Text = "高階管理者";
                    lbl.ForeColor = Color.Red;
                }

            }
        }

        /// <summary>
        /// 搜尋選單變更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectSearch = this.ddsearch.SelectedItem.ToString();


                this.lblselect.Visible = true;
                this.txtSearch.Visible = true;
                this.btnSearch.Visible = true;
                this.btnSearchClear.Visible = true;


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.plcNoData.Visible = false;
            string selectSearch = this.ddsearch.SelectedValue.ToString();
            string txtSearch = this.txtSearch.Text;
            List<string> msgList = new List<string>();

            if (selectSearch == "account")
            {
                var check = CheckVisible(txtSearch);
                if(check == true)
                {
                    if (!this.CheckInput(out msgList))
                    {
                        this.lbMsg.Text = string.Join("<br/>", msgList);
                        return;
                    }
                    else
                    {
                        var list = UserInfoSearch.GetAccountList(txtSearch);
                        if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                        {
                            var pageUserList = this.GetPageDataTable(list);
                            this.gvUserlist.DataSource = pageUserList;
                            this.gvUserlist.DataBind();

                            this.ucPager.TotalSize = list.Count;
                            this.ucPager.Bind();
                        }
                        else
                        {
                            this.lbMsg.Text = $"找不到由{txtSearch}條件篩選的資料";
                        }
                    }
                }
                else
                {
                    this.lbMsg.Text = "尚未輸入篩選的參考資料，請確認資料";
                    this.txtSearch.Text = null;
                }
            }

            if (selectSearch == "eid")
            {
                var check = CheckVisible(txtSearch);
                if (check == true)
                {
                    if (!this.CheckInput(out msgList))
                    {
                        this.plcNoData.Visible = true;
                        this.lbMsg.Text = string.Join("<br/>", msgList);
                        return;
                    }
                    else
                    {
                        int intSearch = Convert.ToInt32(txtSearch);
                        var list = UserInfoSearch.GetEmployeeIDList(intSearch);
                        if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                        {
                            var pageUserList = this.GetPageDataTable(list);
                            this.gvUserlist.DataSource = pageUserList;
                            this.gvUserlist.DataBind();

                            this.ucPager.TotalSize = list.Count;
                            this.ucPager.Bind();
                        }
                        else
                        {
                            this.lbMsg.Text = $"找不到由{txtSearch}條件篩選的資料";
                        }
                    }
                }
                else
                {
                    this.lbMsg.Text = "尚未輸入篩選的參考資料，請確認資料";
                    this.txtSearch.Text = null;
                }
            }

            if (selectSearch == "lastname")
            {
                var check = CheckVisible(txtSearch);
                if (check == true)
                {
                    if (!this.CheckInput(out msgList))
                    {
                        this.lbMsg.Text = string.Join("<br/>", msgList);
                        return;
                    }
                    else
                    {
                        var list = UserInfoSearch.GetLastNameList(txtSearch);
                        if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                        {
                            var pageUserList = this.GetPageDataTable(list);
                            this.gvUserlist.DataSource = pageUserList;
                            this.gvUserlist.DataBind();

                            this.ucPager.TotalSize = list.Count;
                            this.ucPager.Bind();
                        }
                        else
                        {
                            this.lbMsg.Text = $"找不到由{txtSearch}條件篩選的資料";
                        }
                    }
                }
                else
                {
                    this.lbMsg.Text = "尚未輸入篩選的參考資料，請確認資料";
                    this.txtSearch.Text = null;
                }
            }

            if (selectSearch == "firstname")
            {
                var check = CheckVisible(txtSearch);
                if (check == true)
                {
                    if (!this.CheckInput(out msgList))
                    {
                        this.lbMsg.Text = string.Join("<br/>", msgList);
                        return;
                    }
                    else
                    {
                        var list = UserInfoSearch.GetFirstNameList(txtSearch);
                        if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                        {
                            var pageUserList = this.GetPageDataTable(list);
                            this.gvUserlist.DataSource = pageUserList;
                            this.gvUserlist.DataBind();

                            this.ucPager.TotalSize = list.Count;
                            this.ucPager.Bind();
                        }
                        else
                        {
                            this.lbMsg.Text = $"找不到由{txtSearch}條件篩選的資料";
                        }
                    }
                }
                else
                {
                    this.lbMsg.Text = "尚未輸入篩選的參考資料，請確認資料";
                    this.txtSearch.Text = null;
                }
            }

            if (selectSearch == "departmentID")
            {
                var check = CheckVisible(txtSearch);
                if (check == true)
                {
                    if (!this.CheckInput(out msgList))
                    {
                        this.lbMsg.Text = string.Join("<br/>", msgList);
                        return;
                    }
                    else
                    {
                        var list = UserInfoSearch.GetDepartmentIDList(txtSearch);
                        if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                        {
                            var pageUserList = this.GetPageDataTable(list);
                            this.gvUserlist.DataSource = pageUserList;
                            this.gvUserlist.DataBind();

                            this.ucPager.TotalSize = list.Count;
                            this.ucPager.Bind();
                        }
                        else
                        {
                            this.lbMsg.Text = $"找不到由{txtSearch}條件篩選的資料";
                        }
                    }
                }
                else
                {
                    this.lbMsg.Text = "尚未輸入篩選的參考資料，請確認資料";
                    this.txtSearch.Text = null;
                }
            }

        }

        protected void btnSearchClear_Click(object sender, EventArgs e)
        {
            this.txtSearch.Visible = false;
            this.btnSearch.Visible = false;
            this.btnSearchClear.Visible = false;
            this.plcNoData.Visible = false;
            Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {


            List<string> msgList = new List<string>();
            var select = this.ddsearch.SelectedValue.ToString();
            

            //如果輸入不等於預設值
            if (select != "account" && select != "eid" && select != "lastname" && select != "firstname" && select != "departmentID")
            {
                msgList.Add("目前只提供帳號、員工編號、姓氏、名字以及部門代號作為查詢條件");
            }

            #region 以員工編號查詢檢查
            if (select == "eid")
            {
                string txteid = this.txtSearch.Text;


                if (!string.IsNullOrWhiteSpace(txteid))
                {
                    int inteid;
                    if (int.TryParse(txteid, out inteid))
                    {
                        var list = UserInfoManager.GetUserInfoEmployeeID(inteid);

                        if (list.Count < 0 || list == null)
                        {
                            this.gvUserlist.Visible = false;
                            this.plcNoData.Visible = true;
                            msgList.Add($"找不到員工編號為＂{this.txtSearch.Text}＂的使用者，請確認後重新輸入");
                        }
                    }
                    else
                    {
                        msgList.Add($"錯誤格式，請確認員工編號＂{this.txtSearch.Text}＂，皆需為數字");
                        this.txtSearch.Text = null;
                    }

                }
                else
                {
                    msgList.Add($"找不到員工編號為＂{this.txtSearch.Text}＂的使用者，請確認後重新輸入");
                    this.txtSearch.Text = null;
                }

            #endregion

            }


            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;


        }

        private bool CheckVisible(string input)
        {
            if (input.Length > 0)
            {               
                this.txtSearch.Visible = true;
                this.btnSearch.Visible = true;
                this.btnSearchClear.Visible = true;

                return true;
            }

            else
                return false;
        }


        protected void gvUserlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //按下刪除鍵
            var account = e.CommandArgument as string;

            if (string.Compare("btndeleteUser", e.CommandName, true) == 0)
            {
                DialogResult MsgDelete;
                MsgDelete = MessageBox.Show("若刪除使用者將無法復原，繼續請按確定", "刪除使用者資料？",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

                if (MsgDelete == DialogResult.OK)
                {
                    UserInfoManager.DeleteUserlinq(account);
                    Response.Redirect("/ServerSide/UserManagement/UserList.aspx");
                }
                    

                else
                    return;
            }

        }

        protected void btnSortingN_Click(object sender, EventArgs e)
        {
            //近至遠


            var list = UserInfoManager.GetAllUserListSortingN();


            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var pageUserList = this.GetPageDataTable(list);
                this.gvUserlist.DataSource = pageUserList;
                this.gvUserlist.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();


            }
            else
            {
                this.gvUserlist.Visible = false;
                this.plcNoData.Visible = true;
            }


        }

        protected void btnSortingF_Click(object sender, EventArgs e)
        {
            //遠至近

            var list = UserInfoManager.GetAllUserListSortingF();

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var pageUserList = this.GetPageDataTable(list);
                this.gvUserlist.DataSource = pageUserList;
                this.gvUserlist.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();

            }
            else
            {
                this.gvUserlist.Visible = false;
                this.plcNoData.Visible = true;
            }

        }
    }
}