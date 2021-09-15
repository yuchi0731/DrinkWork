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
using System.Windows.Forms;

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

                string orderNumber = this.Request.QueryString["OrderNumber"];
                if(this.Session["forDetailNumber"] == null)
                {
                    this.Session["forDetailNumber"] = orderNumber.ToString();
                }




                this.lbNumber.Text = orderNumber;
                //更新OrderList總金額及杯數
                decimal amount = DrinkListManager.GetAllAmount(orderNumber);
                int cups = DrinkListManager.GetAllCup(orderNumber);
                DrinkListManager.UpdateGroup(orderNumber, amount, cups);



                var list = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

                this.BindList(list);
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

            string orderNumber = this.Request.QueryString["OrderNumber"];
            if (this.Session["forDetailNumber"] == null)
            {
                this.Session["forDetailNumber"] = orderNumber.ToString();
            }

            var select = this.ddSelect.SelectedValue.ToString();
            var selectInfo = this.txtSelect.Text;
            if (select == "account")
            {
                var list = DrinkListManager.GetOrderDetailInfoByAccount(selectInfo, orderNumber);
                this.BindListforSelect(list);
            }

            if (select == "productName")
            {

                var list = DrinkListManager.GetOrderDetailInfoByProductName(selectInfo, orderNumber);

                this.BindListforSelect(list);
            }
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {

            this.ddSelect.Visible = false;
            this.txtSelect.Visible = false;
            this.btnSelect.Visible = false;
            this.btnClearSelect.Visible = false;

            string orderNumber = this.Request.QueryString["OrderNumber"];
            if (this.Session["forDetailNumber"] == null)
            {
                this.Session["forDetailNumber"] = orderNumber.ToString();
            }



            this.lbNumber.Text = orderNumber;
            //更新OrderList總金額及杯數
            decimal amount = DrinkListManager.GetAllAmount(orderNumber);
            int cups = DrinkListManager.GetAllCup(orderNumber);
            DrinkListManager.UpdateGroup(orderNumber, amount, cups);



            var list = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            this.BindList(list);
        }

        private void BindList(List<OrderDetail> list)
        {

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                this.ddSelect.Visible = true;
                this.txtSelect.Visible = true;
                this.btnSelect.Visible = true;
                this.btnClearSelect.Visible = true;
                this.ucPager.Visible = true;

                var DetailList = this.GetPageDataTable(list);
                this.gvDetail.DataSource = DetailList;
                this.gvDetail.DataBind();

                
                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();

            }
            else
            {
                this.ltMsg.Text = "此訂單尚未有資料";
                this.ucPager.Visible = false;
                this.gvDetail.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        private void BindListforSelect(List<OrderDetail> list)
        {

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                this.ddSelect.Visible = true;
                this.txtSelect.Visible = true;
                this.btnSelect.Visible = true;
                this.btnClearSelect.Visible = true;
                this.ucPager.Visible = true;


                var DetailList = this.GetPageDataTable(list);
                this.gvDetail.DataSource = DetailList;
                this.gvDetail.DataBind();


                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();

            }
            else
            {
                
                this.ltMsg.Text = "篩選錯誤，請確認篩選條件是否正確";
                this.gvDetail.Visible = false;
                this.plcNoData.Visible = true;
                this.ucPager.Visible = false;
            }
        }

        protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string orderNumber = this.Request.QueryString["OrderNumber"];
            var DetailInfo = DrinkListManager.GetOrderDetailInfo(orderNumber);
            if (DetailInfo.Established == "Inprogress")
            {
                var item = e.CommandSource as System.Web.UI.WebControls.Button;

                if (string.Compare("btnModify", e.CommandName, true) == 0)
                {
                    if(this.Session["OrderDetailsIDforModify"] == null)
                        this.Session["OrderDetailsIDforModify"] = DetailInfo.OrderDetailsID;
                    Response.Redirect("/ServerSide/SystemAdmin/UpdateDetailInfo.aspx");
                }
            }

            else
            {
                MessageBox.Show($"此訂單編號已完成結帳或流單", "無法更改",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }
    }
}