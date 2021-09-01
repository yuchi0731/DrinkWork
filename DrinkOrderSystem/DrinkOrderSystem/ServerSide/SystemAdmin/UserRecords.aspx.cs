using DOS_Auth;
using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class UserRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////check logined
            ////if (this.Session["UserLoginInfo"] == null)>>錯誤性太高封裝成方法
            //if (!AuthManager.IsLogined())
            //{
            //    Response.Redirect("/Frontside/Login.aspx");
            //    return;
            //}


            var currentUser = AuthManager.GetCurrentUser();


            //if (currentUser == null) //如果帳號不存在，導向登入頁
            //{
            //    this.Session["UserLoginInfo"] = null;
            //    Response.Redirect("/Frontside/Login.aspx");
            //    return;
            //}



            var currentAccount = currentUser.Account;

            //read all drink data
            var dt = DrinkListManager.GetOrderUserDetailList(currentAccount);

            int drinkcount = dt.Rows.Count;

            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var dtpaged = this.GetPagedDataTable(dt);

                this.ucPager.Totaluser = dt.Rows.Count;
                this.ucPager.BindUserList();


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


                this.gvUserDetail.DataSource = dtpaged;
                this.gvUserDetail.DataBind();

            }
            else
            {
                this.gvUserDetail.Visible = false;
                this.plcNoData.Visible = true;
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
    }
}