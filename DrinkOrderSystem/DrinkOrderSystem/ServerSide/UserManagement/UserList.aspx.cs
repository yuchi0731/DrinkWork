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

namespace DrinkOrderSystem.ServerSide.UserManagement
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //read Users data
            var dt = UserInfoManager.GetAllDrinkInfo();
            
           
            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var dtpaged = this.GetPagedDataTable(dt);

                //this.ucPager.Totaluser = dt.Rows.Count;
                //this.ucPager.BindUserList();


                string result = string.Empty;
                //取得UserInfo資料跑Rows和Columns資料
                foreach (DataRow dr in dt.Rows)
                {
                    result = result + "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        result = result + "<td>" + dr[dc] + "</td>";
                    }
                    result = result + "</tr>";
                }


                this.gvUserlist.DataSource = dtpaged;
                this.gvUserlist.DataBind();


            }
            else
            {
                this.gvUserlist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("若要建立新的使用者，將登出現在使用者資料", "提示",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation);

            if (MsgBoxResult == DialogResult.OK)
            {
                Response.Redirect("/ServerSide/SystemAdmin/CreateNewUser.aspx");
                AuthManager.Logout();
            }
            else
            {
                return;
            }
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


        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            int pageSize = this.ucPager.PageSize;


            int startIndex = (this.GetCurrentPage() - 1) * 10;
            int endIndex = (this.GetCurrentPage()) * 10;

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }

            return dtPaged;
        }


        //gvUserlist事件>職等文字顯示
        protected void gvUserlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lbl = row.FindControl("lbluserlevel") as System.Web.UI.WebControls.Label;


                var dr = row.DataItem as DataRowView; //DataItem本身是object要轉型別
                int userlevel = dr.Row.Field<int>("JobGrade");


                if (userlevel == 0)
                {
                    lbl.Text = "一般會員";
                    lbl.ForeColor = Color.Blue;
           
                }
                if (userlevel == 1)
                {
                    lbl.Text = "管理者";
                    lbl.ForeColor = Color.Green;

                }

                if (userlevel == 2)
                {
                    lbl.Text = "高階管理者";
                    lbl.ForeColor = Color.Red;
                }

            }
        }

        protected void btnKeyword_Click(object sender, EventArgs e)
        {
            
        }
    }
}