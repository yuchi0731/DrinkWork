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
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class OderMid : System.Web.UI.Page
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
                if (this.Session["OrderMidNumber"] == null)
                {
                    this.Session["OrderMidNumber"] = orderNumber.ToString();
                }
                var orderDetail = DrinkListManager.GetOrderDetailListfromorderNumber(this.Session["OrderMidNumber"].ToString());
                this.ltOrderNumber.Text = orderDetail.OrderNumber;
                this.lbSup.Text = orderDetail.SupplierName;

                this.txtChooseDrinkList.Text = string.Empty; ;

                var supplier = orderDetail.SupplierName;
                var list = DrinkListManager.GetProducts(supplier);
                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {
                    var pageList = this.GetPageDataTable(list);
                    this.gvChooseDrink.DataSource = pageList;
                    this.gvChooseDrink.DataBind();


                    this.ucPager.TotalSize = list.Count;
                    this.ucPager.Bind();
                }

                else
                {

                    this.gvChooseDrink.Visible = false;
                    this.lbMsg.Visible = true;
                    this.lbMsg.Text = "找不到此跟團資料";
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


        /// <summary>
        /// 建立本頁DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<Product> GetPageDataTable(List<Product> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();

        }

        protected void btnSent_Click(object sender, EventArgs e)
        {

            DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("確定送出訂單後，可在個人歷史訂購頁查看訂購資料", "送出",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (MsgBoxResult == DialogResult.OK)
                {

                var writeSession = this.Session["SelectedItems"] as List<OrderDetailModels>;

                foreach (var sub in writeSession)
                {
                    DrinkListManager.AddGroup(sub);
                }


                //更新OrderList總金額及杯數
                string orderNumber = this.Session["OrderMidNumber"].ToString();
                decimal amount = DrinkListManager.GetAllAmount(orderNumber);
                int cups = DrinkListManager.GetAllCup(orderNumber);

                DrinkListManager.UpdateGroup(orderNumber, amount, cups);

                MessageBox.Show($"訂購完成，訂單編號為【{orderNumber}】\r\n之後可由訂單明細查詢訂購項目", "完成!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Response.Redirect("/ServerSide/SystemAdmin/NowOrdering.aspx");
            }
                else
                {
                this.lbMsg.Visible = true;
                this.lbMsg.Text = "已取消動作";
                    return;
                }




        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {


            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("取消將不會儲存資料，請按確認繼續", "取消",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);


            if (MsgBoxResult == DialogResult.OK)
            {

                this.txtChooseDrinkList.Text = string.Empty;
                Session.Remove("SelectedItems");
                this.lbErrorMsg.Text = null;
                this.lbErrorMsg.Visible = false;
                this.lbMsg.Text = null;
                this.lbMsg.Visible = false;

                MsgBoxResult = MessageBox.Show("取消成功", "修改成功",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            }
            else
            {
                this.lbMsg.Text = "取消動作";
                this.lbMsg.Visible = false;
                return;
            }


        }

        protected void gvChooseDrink_RowCommand(object sender, GridViewCommandEventArgs e)
        {

                var item = e.CommandSource as System.Web.UI.WebControls.Button;
                var container = item.NamingContainer;

                this.lbErrorMsg.Visible = false;
                this.lbMsg.Visible = false;
                this.txtChooseDrinkList.Visible = true;
                this.lbTotalAmount.Visible = true;
                this.btnDelete.Visible = true;
                this.btnSent.Visible = true;


                var DDLQuantity = container.FindControl("dlQuantity") as DropDownList;
                var DDLSugar = container.FindControl("dlChooseSugar") as DropDownList;
                var DDLIce = container.FindControl("dlChooseIce") as DropDownList;
                var DDLToppings = container.FindControl("dlChooseToppings") as DropDownList;


                if (DDLQuantity.SelectedIndex == 0)
                {
                    this.lbErrorMsg.Visible = true;
                    this.lbErrorMsg.Text = "杯數選擇錯誤，請重新選擇";
                    return;
                }
                if (DDLSugar.SelectedIndex == 0)
                {
                    this.lbErrorMsg.Visible = true;
                    this.lbErrorMsg.Text = "糖量選擇錯誤，請重新選擇";
                    return;
                }
                if (DDLIce.SelectedIndex == 0)
                {
                    this.lbErrorMsg.Visible = true;
                    this.lbErrorMsg.Text = "冰塊選擇錯誤，請重新選擇";
                    return;
                }
                if (DDLToppings.SelectedIndex == 0)
                {
                    this.lbErrorMsg.Visible = true;
                    this.lbErrorMsg.Text = "加料選擇錯誤，請重新選擇";
                    return;
                }


                if (string.Compare("ChooseDrink", e.CommandName, true) == 0)
                {

                    string orderNumber = this.Session["OrderMidNumber"].ToString();
                    var orderDetail = DrinkListManager.GetOrderDetailListfromorderNumber(orderNumber);
                    var supplier = orderDetail.SupplierName;
                    string argu = (e.CommandArgument) as string;


                    decimal Toprice = 0;
                    //加料金額
                    if (DDLToppings.SelectedIndex == 1)
                    {
                        Toprice = 0;
                    }
                    if (DDLToppings.SelectedIndex == 2)
                    {
                        Toprice = 10;
                    }
                    if (DDLToppings.SelectedIndex == 3)
                    {
                        Toprice = 5;
                    }
                    if (DDLToppings.SelectedIndex == 4)
                    {
                        Toprice = 10;
                    }


                    this.txtChooseDrinkList.Text +=
                        "【飲料】" + e.CommandArgument as string
                        + "【單價】" + DrinkListManager.GetUnitPrice(e.CommandArgument as string) + "元/杯"
                        + Environment.NewLine
                        + "【杯數】" + DDLQuantity.SelectedItem + "杯"
                        + Environment.NewLine
                        + "【甜度】" + DDLSugar.SelectedItem
                        + "【冰量】" + DDLIce.SelectedItem
                        + Environment.NewLine
                        + "【加料】" + DDLToppings.SelectedItem
                        + "【加料單價】" + Toprice + "元"
                        + Environment.NewLine
                        + "-----------------------------------"
                        + "\r\n";


                    var currentUser = AuthManager.GetCurrentUser();

                    List<Product> sourcedetaillist = DrinkListManager.GetProducts(supplier);

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
                        this.lbErrorMsg.Text = "格式錯誤，杯數須為整數，請確認後重新輸入";
                        return;
                    }


                    var orderdetaillist = new OrderDetailModels()
                    {
                        OrderDetailsID = Guid.NewGuid(),
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
                        ToppingsUnitPrice = Toprice,
                        SupplierName = supplier,
                        OtherRequest = null,
                        Established = "NO"
                    };

                    var sessionLList = this.Session["SelectedItems"] as List<OrderDetailModels>; //將Session轉成List，再做總和
                    sessionLList.Add(orderdetaillist);


                    decimal totalAmount = 0;
                    foreach (var sub in sessionLList)
                    {
                        totalAmount += sub.SubtotalAmount;
                    }

                    this.lbTotalAmount.Text = $"總金額共：【{totalAmount.ToString()}】 元";

                

            }


        }
    }
}