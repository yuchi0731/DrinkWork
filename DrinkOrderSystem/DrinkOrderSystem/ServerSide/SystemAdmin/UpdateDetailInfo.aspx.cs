using DOS_Auth;
using DOS_DBSoure;
using DOS_Models;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class UpdateDetailInfo : System.Web.UI.Page
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


                string orderID = this.Session["OrderDetailsIDforModify"].ToString();

                Guid orderDetailID;
                Guid.TryParse(orderID, out orderDetailID);

                var orderDetailUnfo = DrinkListManager.GetOrderDetailfromorderID(orderDetailID);
                var supplierName = orderDetailUnfo.SupplierName;

                string supName = "";
                if (supplierName == "Fiftylan")
                {
                    supName = "五十嵐";
                }
                if (supplierName == "WhiteAlley")
                {
                    supName = "白巷子";
                }
                if (supplierName == "MilkShop")
                {
                    supName = "迷客夏";
                }

                this.lbSearch.Text = $"查詢{supName}商品";

                var list = DrinkListManager.GetOrderDetailListfromorderID(orderDetailID);
                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {
                    var pageList = this.GetPageDataTable(list);
                    this.gvDetailInfo.DataSource = pageList;
                    this.gvDetailInfo.DataBind();
                }

                else
                {
                    this.gvDetailInfo.Visible = false;
                    this.lbErroMsg.Visible = true;
                    this.lbErroMsg.Text = "找不到此跟團資料";
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


        protected void gvDetailInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (string.Compare("btnSave", e.CommandName, true) == 0)
            {
                this.lbErroMsg.Visible = false;
                string orderID = this.Session["OrderDetailsIDforModify"].ToString();

                Guid orderDetailID;
                Guid.TryParse(orderID, out orderDetailID);

                var orderDetailUnfo = DrinkListManager.GetOrderDetailfromorderID(orderDetailID);

                var item = e.CommandSource as System.Web.UI.WebControls.Button;
                var container = item.NamingContainer;

                System.Web.UI.WebControls.TextBox productName = container.FindControl("txtProductName") as System.Web.UI.WebControls.TextBox;
                string txtProductName = productName.Text;

                System.Web.UI.WebControls.Label lbunitPrice = container.FindControl("lbunitPrice") as System.Web.UI.WebControls.Label;
                var unitPrice = DrinkListManager.GetUnitPrice(txtProductName);

                DropDownList dlQuantity = container.FindControl("dlQuantity") as DropDownList;
                string ddquantity = dlQuantity.SelectedItem.Text;

                DropDownList dlChooseSugar = container.FindControl("dlChooseSugar") as DropDownList;
                string Sugar = dlChooseSugar.SelectedItem.Text;

                DropDownList dlChooseIce = container.FindControl("dlChooseIce") as DropDownList;
                string Ice = dlChooseIce.SelectedItem.Text;

                DropDownList dlChooseToppings = container.FindControl("dlChooseToppings") as DropDownList;
                string Toppings = dlChooseToppings.SelectedItem.Text;

                int quantity;
                int.TryParse(ddquantity, out quantity);

                System.Web.UI.WebControls.Label lbAmount = container.FindControl("lbAmount") as System.Web.UI.WebControls.Label;


                decimal Toprice = 0;
                //加料金額
                if (dlChooseToppings.SelectedIndex == 1)
                {
                    Toprice = 0;
                }
                if (dlChooseToppings.SelectedIndex == 2)
                {
                    Toprice = 10;
                }
                if (dlChooseToppings.SelectedIndex == 3)
                {
                    Toprice = 5;
                }
                if (dlChooseToppings.SelectedIndex == 4)
                {
                    Toprice = 10;
                }

                OrderDetail orderDetail = new OrderDetail()
                {                   
                    OrderDetailsID = orderDetailID,
                    ProductName = txtProductName,
                    Quantity = quantity,
                    Suger = Sugar,
                    Ice = Ice,
                    Toppings = Toppings,
                    SubtotalAmount = unitPrice * Toprice
                };



                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("即將變更資料，繼續請按確定", "確認變更",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);


                if (MsgBoxResult == DialogResult.OK)
                {

                    DrinkListManager.UpdateDetailInfo(orderDetail);


                    MsgBoxResult = MessageBox.Show("修改成功，將導至跟團清單頁", "修改成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);






                    Response.Redirect("/ServerSide/SystemAdmin/NowOrdering.aspx");
                }
                else
                {
                    this.lbErroMsg.Visible = true;
                    this.lbErroMsg.Text = "修改取消，尚未存取變更";
                    return;
                }



            }

            if (string.Compare("btnCancel", e.CommandName, true) == 0)
            {
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("尚有未儲存資料，繼續請按確定", "取消",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);


                if (MsgBoxResult == DialogResult.OK)
                {
                    Response.Redirect("/ServerSide/SystemAdmin/NowOrdering.aspx");
                }
                else
                {
                    this.lbErroMsg.Visible = true;
                    this.lbErroMsg.Text = "修改取消，尚未存取變更";
                    return;
                }


                
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtSearch.Visible = true;

            string orderID = this.Session["OrderDetailsIDforModify"].ToString();

            Guid orderDetailID;
            Guid.TryParse(orderID, out orderDetailID);

            var orderDetailUnfo = DrinkListManager.GetOrderDetailfromorderID(orderDetailID);
            var produt = DrinkListManager.GetALLProduct(orderDetailUnfo.SupplierName);

            foreach (var item in produt)
            {
                this.txtSearch.Text += item + Environment.NewLine;
            }

        }
    }
}