using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class NowOrdering : System.Web.UI.Page
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



                var list = DrinkListManager.GetOrderByRtimeNowOrdering();

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvNoworderinglist.DataSource = orderlist;
                    this.gvNoworderinglist.DataBind();


                }
                else
                {
                    this.gvNoworderinglist.Visible = false;
                    this.ucPager.Visible = false;
                    this.plcNoData.Visible = true;
                    this.lbMsg.Text = "目前沒有可跟團的清單";
                }

            }

        }


        private List<OrderList> GetPageDataTable(List<OrderList> list)
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

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            var select = this.ddSelect.SelectedValue.ToString();
            var selectInfo = this.txtSelect.Text;
            if (select == "account")
            {

                var list = DrinkListManager.GetNowOrderingByAccount(selectInfo);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvNoworderinglist.DataSource = orderlist;
                    this.gvNoworderinglist.DataBind();

                }
                else
                {
                    this.lbMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvNoworderinglist.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
            if (select == "orderNumber")
            {
                var list = DrinkListManager.GetNowOrderingByOrderNumber(selectInfo);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvNoworderinglist.DataSource = orderlist;
                    this.gvNoworderinglist.DataBind();

                }
                else
                {
                    this.lbMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvNoworderinglist.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }


        }

        protected void btnSortingN_Click(object sender, EventArgs e)
        {
            var list = DrinkListManager.GetOrderByRtimeNowOrdering();

            if (list.Count > 0)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvNoworderinglist.DataSource = orderlist;
                this.gvNoworderinglist.DataBind();

            }
            else
            {
                this.gvNoworderinglist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnSortingF_Click(object sender, EventArgs e)
        {
            var list = DrinkListManager.GetOrderByOtimeNowOrdering();

            if (list.Count > 0)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvNoworderinglist.DataSource = orderlist;
                this.gvNoworderinglist.DataBind();

            }
            else
            {
                this.gvNoworderinglist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {
            this.txtSelect.Visible = false;
            this.btnSelect.Visible = false;
            Response.Redirect("/ServerSide/SystemAdmin/NowOrdering.aspx");

            var list = DrinkListManager.GetOrderListNoOrdering();

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvNoworderinglist.DataSource = orderlist;
                this.gvNoworderinglist.DataBind();


            }
            else
            {
                this.gvNoworderinglist.Visible = false;
                this.ucPager.Visible = false;
                this.plcNoData.Visible = true;
                this.lbMsg.Text = "目前沒有可跟團的清單";
            }
        }

        protected void ddSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtSelect.Visible = true;
            this.btnSelect.Visible = true;
        }
    }
}

