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
    public partial class OrderDetailInfo : System.Web.UI.Page
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

                string orderNumber = string.Empty;
                if (this.Request.QueryString["OrderNumber"] != null)
                {
                    if(this.Session["forDetailNumber"] == null)
                    {
                        this.Session["forDetailNumber"] = this.Request.QueryString["OrderNumber"];
                        orderNumber = this.Session["forDetailNumber"].ToString();
                    }
     
                }



                this.lbNumber.Text = orderNumber;
                //更新OrderList總金額及杯數
                decimal amount = DrinkListManager.GetAllAmount(orderNumber);
                int cups = DrinkListManager.GetAllCup(orderNumber);
                DrinkListManager.UpdateGroup(orderNumber, amount, cups);



                var list = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var DetailList = this.GetPageDataTable(list);
                    this.gvDetail.DataSource = DetailList;
                    this.gvDetail.DataBind();

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();

                }
                else
                {
                    this.ltMsg.Text = "此訂單尚未有資料";
                    this.gvDetail.Visible = false;
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

        private List<OrderDetail> GetPageDataTable(List<OrderDetail> list)
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

                var list = DrinkListManager.GetOrderDetailInfoByAccount(selectInfo);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvDetail.DataSource = orderlist;
                    this.gvDetail.DataBind();

                }
                else
                {
                    this.ltMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvDetail.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }

            if (select == "productName")
            {

                var list = DrinkListManager.GetOrderDetailInfoByProductName(selectInfo);
                
                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {

                    var orderlist = this.GetPageDataTable(list);

                    this.ucPager.Totaluser = list.Count;
                    this.ucPager.BindUserList();


                    this.gvDetail.DataSource = orderlist;
                    this.gvDetail.DataBind();

                }
                else
                {
                    this.ltMsg.Text = "找不到此篩選資料，請確認輸入是否正確";
                    this.gvDetail.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {

            string orderNumber = string.Empty;
            if (this.Request.QueryString["OrderNumber"] != null)
            {
                if (this.Session["forDetailNumber"] == null)
                {
                    this.Session["forDetailNumber"] = this.Request.QueryString["OrderNumber"];
                    orderNumber = this.Session["forDetailNumber"].ToString();
                }

            }


            if (this.Session["StartOrderNumber"].ToString() != null)
            {
                orderNumber = this.Session["StartOrderNumber"].ToString();
            }

            this.lbNumber.Text = orderNumber;
            //更新OrderList總金額及杯數
            decimal amount = DrinkListManager.GetAllAmount(orderNumber);
            int cups = DrinkListManager.GetAllCup(orderNumber);
            DrinkListManager.UpdateGroup(orderNumber, amount, cups);



            var list = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var DetailList = this.GetPageDataTable(list);
                this.gvDetail.DataSource = DetailList;
                this.gvDetail.DataBind();

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();

            }
            else
            {
                this.ltMsg.Text = "此訂單尚未有資料";
                this.gvDetail.Visible = false;
                this.plcNoData.Visible = true;
            }
        }
    }
}