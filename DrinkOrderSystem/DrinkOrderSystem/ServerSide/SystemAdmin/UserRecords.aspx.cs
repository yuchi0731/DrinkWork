using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
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


                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }

                var currentAccount = AuthManager.GetCurrentUser();
                var account = currentAccount.Account;

                var userDetailList = DrinkListManager.GetUserDetailList(account);

                if (userDetailList.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var DetailList = this.GetPageDataTable(userDetailList);
                    this.gvUserDetail.DataSource = DetailList;
                    this.gvUserDetail.DataBind();

                    this.ucPager.Totaluser = userDetailList.Count;
                    this.ucPager.Bind();


                }
                else
                {
                this.ltMsg.Text = "您目前無任何訂購資料";
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

        private List<OrderDetail> GetPageDataTable(List<OrderDetail> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            
            var currentAccount = AuthManager.GetCurrentUser();
            var account = currentAccount.Account;
            

            var select = this.ddselect.SelectedValue.ToString();
            if (select == "RecentTime")
            {
                var userDetailList = DrinkListManager.GetUserDetailOrderByRtime(account);
                if (userDetailList.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var dtpaged = this.GetPageDataTable(userDetailList);
                    this.gvUserDetail.DataSource = dtpaged;
                    this.gvUserDetail.DataBind();

                    this.ucPager.Totaluser = userDetailList.Count;
                    this.ucPager.Bind();


                }
                else
                {
                    this.gvUserDetail.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }

            if (select == "OldestTime")
            {
                var userDetailList = DrinkListManager.GetUserDetailOrderByOtime(account);
                if (userDetailList.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var dtpaged = this.GetPageDataTable(userDetailList);
                    this.gvUserDetail.DataSource = dtpaged;
                    this.gvUserDetail.DataBind();

                    this.ucPager.Totaluser = userDetailList.Count;
                    this.ucPager.Bind();


                }
                else
                {
                    this.gvUserDetail.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }

            if (select == "ProductName")
            {
                var userDetailList = DrinkListManager.GetUserDetailOrderByProduct(account);
                if (userDetailList.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var dtpaged = this.GetPageDataTable(userDetailList);
                    this.gvUserDetail.DataSource = dtpaged;
                    this.gvUserDetail.DataBind();

                    this.ucPager.Totaluser = userDetailList.Count;
                    this.ucPager.Bind();


                }
                else
                {
                    this.gvUserDetail.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
        }
    }
}