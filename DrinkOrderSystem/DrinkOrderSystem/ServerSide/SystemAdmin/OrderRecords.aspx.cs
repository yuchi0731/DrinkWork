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
    public partial class OrderRecords : System.Web.UI.Page
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


                var list = DrinkListManager.GetOrderListRecord();

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvdrinklist.DataSource = orderlist;
                    this.gvdrinklist.DataBind();

                }
                else
                {
                    this.ltMsg.Text = "目前無歷史資料";
                    this.gvdrinklist.Visible = false;
                    this.plcNoData.Visible = true;
                }
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


        private List<OrderList> GetPageDataTable(List<OrderList> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var select = this.ddSelect.SelectedValue.ToString();
            var selectInfo = this.txtSelect.Text;
            if (select == "account")
            {

                var list = DrinkListManager.GetOrderListRecordByAccount(selectInfo);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvdrinklist.DataSource = orderlist;
                    this.gvdrinklist.DataBind();

                }
                else
                {
                    this.ltMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvdrinklist.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
            if (select == "orderNumber")
            {
                var list = DrinkListManager.GetOrderListRecordByOrderNumber(selectInfo);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvdrinklist.DataSource = orderlist;
                    this.gvdrinklist.DataBind();

                }
                else
                {
                    this.ltMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvdrinklist.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
        }

        protected void btnSortingN_Click(object sender, EventArgs e)
        {
            var list = DrinkListManager.GetOrderByRtime();

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvdrinklist.DataSource = orderlist;
                this.gvdrinklist.DataBind();

            }
            else
            {
                this.gvdrinklist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnSortingF_Click(object sender, EventArgs e)
        {
            var list = DrinkListManager.GetOrderByOtime();

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvdrinklist.DataSource = orderlist;
                this.gvdrinklist.DataBind();

            }
            else
            {
                this.gvdrinklist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {
            var list = DrinkListManager.GetOrderListRecord();

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var orderlist = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvdrinklist.DataSource = orderlist;
                this.gvdrinklist.DataBind();

            }
            else
            {
                this.ltMsg.Text = "目前無歷史資料";
                this.gvdrinklist.Visible = false;
                this.plcNoData.Visible = true;
            }
        }
    }
    
}