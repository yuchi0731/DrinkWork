using DOS_Models;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOS_DBSoure;
using DOS_Auth;
using System.Data.SqlClient;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class OderMid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }
        }

        protected void gvChooseDrink_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var orderDetail = DrinkListManager.GetOrderDetailListfromorderNumber(orderNumber);
            var supplier = orderDetail.SupplierName;

            var item = e.CommandSource as Button;    //第二種 老師解的

            // 找到 button 的容器，它會是 GridViewRow
            var container = item.NamingContainer;

            var DDLQuantity = container.FindControl("dlQuantity") as DropDownList;
            var DDLSugar = container.FindControl("dlChooseSugar") as DropDownList;
            var DDLIce = container.FindControl("dlChooseIce") as DropDownList;
            var DDLToppings = container.FindControl("dlChooseToppings") as DropDownList;

            if (string.Compare("ChooseDrink", item.CommandName, true) == 0)
            {
                this.txtChooseDrinkList.Visible = true;


                this.txtChooseDrinkList.Text += $"{e.CommandArgument as string} {DDLQuantity.SelectedItem} {DDLSugar.SelectedItem} {DDLIce.SelectedItem} {DDLToppings.SelectedItem}\r\n";

                this.btnDelete.Visible = true;
                this.btnSent.Visible = true;

            }

            if (e.CommandName == "ChooseDrink")
            {
                string argu = (e.CommandArgument) as string;

                var currentUser = AuthManager.GetCurrentUser();


                List<OrderDetail> sourcedetaillist = DrinkListManager.GetOrderDetailList(supplier);

                //利用商品名連動到商品資料表
                var drinkdetaillist = sourcedetaillist.Where(obj => obj.ProductName == argu).FirstOrDefault();
                if (drinkdetaillist != null)
                {
                    if (this.Session["SelectedItems"] == null)
                        this.Session["SelectedItems"] = new List<OrderDetailModels>();
                }

                int quan;
                if (!int.TryParse(DDLQuantity.Text, out quan))
                {
                    this.txtChooseDrinkList.Text = "格式錯誤，杯數須為整數，請確認後重新輸入";
                    return;
                }


                
                var orderdetaillist = new OrderDetailModels()
                {
                    OrderDetailsID = orderDetail.OrderDetailsID,
                    OrderNumber = orderNumber,
                    Account = currentUser.Account,
                    OrderTime = orderDetail.OrderTime,
                    OrderEndTime = orderDetail.OrderEndTime,
                    RequiredTime = orderDetail.RequiredTime,
                    ProductName = e.CommandArgument as string,
                    Quantity = quan,
                    UnitPrice = drinkdetaillist.UnitPrice,
                    Suger = DDLSugar.SelectedItem.ToString(),
                    Ice = DDLIce.SelectedItem.ToString(),
                    Toppings = DDLToppings.SelectedItem.ToString(),
                    SupplierName = supplier,
                    OtherRequest = this.txtOther.Text
                };


                DrinkListManager.AddGroup(orderdetaillist);





            }


        }
    }
}