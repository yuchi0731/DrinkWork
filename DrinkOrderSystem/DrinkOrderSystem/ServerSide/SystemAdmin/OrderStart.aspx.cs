using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DOS_Auth;
using DOS_DBSoure;
using DOS_Models;
using DOS_ORM.DOSmodel;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class OrderStart : System.Web.UI.Page
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
               
            }

        }


        protected void ImgbtnFiftylan_Click(object sender, ImageClickEventArgs e)
        {
            this.txtChooseDrinkList.Text = string.Empty;
            Session.Remove("DrinkShop");

            this.ImgbtnFiftylan.Visible = true;
            this.ImgbtnWhiteAlley.Visible = false;
            this.ImgbtnMilkshop.Visible = false;


            this.Session["DrinkShop"] = "Fiftylan";
            string SupplierName = "Fiftylan";
            var supName = "五十嵐";
            var dt = DrinkListManager.GetProducts(SupplierName);
            ShopBtn(dt);

            this.ltChoosedShop.Text = $"目前已選擇{supName}";

        }



        protected void ImgbtnWhiteAlley_Click(object sender, ImageClickEventArgs e)
        {
            this.txtChooseDrinkList.Text = string.Empty;
            Session.Remove("DrinkShop");

            this.ImgbtnFiftylan.Visible = false;
            this.ImgbtnWhiteAlley.Visible = true;
            this.ImgbtnMilkshop.Visible = false;

            this.Session["DrinkShop"] = "WhiteAlley";
            string SupplierName = "WhiteAlley";
            var supName = "白巷子";
            var dt = DrinkListManager.GetProducts(SupplierName);
            ShopBtn(dt);

            this.ltChoosedShop.Text = $"目前已選擇{supName}";

        }

        protected void ImgbtnMilkshop_Click(object sender, ImageClickEventArgs e)
        {
            this.txtChooseDrinkList.Text = string.Empty;
            Session.Remove("DrinkShop");

            this.ImgbtnFiftylan.Visible = false;
            this.ImgbtnWhiteAlley.Visible = false;
            this.ImgbtnMilkshop.Visible = true;


            this.Session["DrinkShop"] = "MilkShop";
            string SupplierName = "MilkShop";
            var supName = "迷客夏";
            var dt = DrinkListManager.GetProducts(SupplierName);
            ShopBtn(dt);

            this.ltChoosedShop.Text = $"目前已選擇{supName}";

        }

        /// <summary>
        /// 商家的共用方法
        /// </summary>
        /// <param name="dt"></param>
        private void ShopBtn(List<Product> list)
        {

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                var dtPaged = this.GetPageDataTable(list);


                this.btnDelete.Visible = true;
                this.btnSent.Visible = true;
                this.txtEndTime.Visible = true;
                this.txtReqTime.Visible = true;
                this.ltDrinkTitle.Visible = true;
                this.gvChooseDrink.DataSource = dtPaged;
                this.gvChooseDrink.DataBind();
                this.ucPager.Visible = true;

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


            }
            else
            {
                this.gvChooseDrink.Visible = false;
                this.btnSent.Visible = false;
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
        private List<Product> GetPageDataTable(List<Product> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }



        /// <summary>
        /// GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gvChooseDrink_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            var item = e.CommandSource as System.Web.UI.WebControls.Button;
            var container = item.NamingContainer;

            this.lbErrorMsg.Visible = false;
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

            if (string.Compare("ChooseDrink", item.CommandName, true) == 0)
            {
                var currentUser = AuthManager.GetCurrentUser();
                string argu = (e.CommandArgument) as string;
                var supplierName = this.Session["DrinkShop"].ToString();
                var orderNumber = $"Odr{currentUser.DepartmentID}" + DateTime.Now.ToString("MMddHHmmyyyy");


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
                    + "【單價】"+ DrinkListManager.GetUnitPrice(e.CommandArgument as string) + "元/杯"
                    + Environment.NewLine
                    + "【杯數】" + DDLQuantity.SelectedItem + "杯"
                    + Environment.NewLine
                    + "【甜度】" + DDLSugar.SelectedItem
                    + "【冰量】" + DDLIce.SelectedItem
                    +Environment.NewLine
                    + "【加料】" + DDLToppings.SelectedItem
                    + "【加料單價】" + Toprice +"元"
                    + Environment.NewLine
                    + "-----------------------------------"
                    + "\r\n";

                //this.txtChooseDrinkList.Text += 
                //    $"【飲料】{e.CommandArgument as string}【單價】{DrinkListManager.GetUnitPrice(e.CommandArgument as string)}元/杯 【杯數】 {DDLQuantity.SelectedItem}杯 【甜度】{DDLSugar.SelectedItem}【冰量】{DDLIce.SelectedItem}【加料】{DDLToppings.SelectedItem}【加料單價】{Toprice} 元 \r\n";


                List<Product> sourcedetaillist = DrinkListManager.GetProducts(supplierName);

                var DrinkList = sourcedetaillist.Where(obj => obj.ProductName == argu).FirstOrDefault();

                if (DrinkList != null)
                {
                    if (this.Session["SelectedItems"] == null)
                        this.Session["SelectedItems"] = new List<OrderDetailModels>();
                }

                if (DrinkList != null)
                {
                    if (this.Session["SelectedList"] == null)
                        this.Session["SelectedList"] = new List<OrderListModels>();
                }

                string endTime = this.txtEndTime.Text;
                string reqTime = this.txtReqTime.Text;

                if(endTime == null || reqTime == null)
                {
                    this.lbMsg.Text = "尚未選取截止/送達時間";
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
                    OrderTime = DateTime.Now,
                    OrderEndTime = DateTime.Now,
                    RequiredTime = DateTime.Now,
                    Account = currentUser.Account,
                    ProductName = e.CommandArgument as string,
                    Quantity = Convert.ToInt32(DDLQuantity.SelectedItem.Value),
                    UnitPrice = DrinkListManager.GetUnitPrice(e.CommandArgument as string),
                    Suger = DDLSugar.SelectedItem.ToString(),
                    Ice = DDLSugar.SelectedItem.ToString(),
                    Toppings = DDLToppings.SelectedItem.ToString(),
                    ToppingsUnitPrice = Toprice,
                    SupplierName = supplierName,
                    OtherRequest = null,
                    Established = "Inprogress"
                };

                var sessionList = this.Session["SelectedItems"] as List<OrderDetailModels>;    //將Session轉成List，再做總和
                sessionList.Add(orderdetaillist);

                decimal totalAmount = 0;
                foreach (var sub in sessionList)
                {
                    totalAmount += sub.SubtotalAmount;
                }

                this.lbTotalAmount.Text = $"總金額共：【{totalAmount.ToString()}】 元";



                var orderlist = new OrderListModels()
                {
                    OrderNumber = orderNumber,
                    Account = currentUser.Account,
                    SupplierName = supplierName,
                    TotalPrice = totalAmount,
                    TotalCups = Convert.ToInt32(DDLQuantity.SelectedItem.Value),
                    Established = "Inprogress"
                };

                this.Session["SelectedList"] = orderlist;


            }
        }



        /// <summary>
        /// 清除選單內容、Session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("取消將不會儲存資料，請按確認繼續", "取消",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);


            if (MsgBoxResult == DialogResult.OK)
            {
                this.ImgbtnFiftylan.Visible = true;
                this.ImgbtnWhiteAlley.Visible = true;
                this.ImgbtnMilkshop.Visible = true;
                this.lbErrorMsg.Visible = false;
                this.btnDelete.Visible = true;
                this.btnSent.Visible = true;
                this.txtEndTime.Visible = true;
                this.txtReqTime.Visible = true;

                this.ltDrinkTitle.Visible = false;
                this.gvChooseDrink.Visible = false;
                this.txtChooseDrinkList.Text = string.Empty;
                this.txtChooseDrinkList.Visible = false;

                Session.Remove("SelectedItems");
                Session.Remove("DrinkShop");
                this.lbTotalAmount.Text = null;
                this.lbTotalAmount.Visible = false;
                this.txtEndTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                this.txtReqTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

                MsgBoxResult = MessageBox.Show("取消成功", "修改成功",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                Response.Redirect("/ServerSide/SystemAdmin/OrderStart.aspx");
            }
            else
            {
                return;
            }



        }

        
        protected void btnSent_Click(object sender, EventArgs e)
        {
            string endTime = this.txtEndTime.Text;
            string reqTime = this.txtReqTime.Text;

            if (endTime == null || reqTime == null)
            {
                this.lbMsg.Visible = true;
                this.lbMsg.Text = "尚未選取截止/送達時間";
            }

            DateTime Etime = Convert.ToDateTime(endTime);
            DateTime Rtime = Convert.ToDateTime(reqTime);
            DateTime tenmin = DateTime.Now.AddMinutes(10);
            DateTime onehour = tenmin.AddHours(3);



            if (Etime.AddHours(3) > Rtime)
            {
                this.lbMsg.Visible = true;
                this.lbMsg.Text = "截止時間必須在送達時間三小時之前";
                return;
            }

            if (Etime < tenmin || Rtime < onehour)
            {
                this.lbMsg.Visible = true;
                this.lbMsg.Text = "截止/送達時間，必須是現在時間十分鐘後，送達時間需為截止時間三小時後";
                return;
            }

            var sessionList = this.Session["SelectedItems"] as List<OrderDetailModels>; 
            foreach (var item in sessionList)
            {
                item.OrderTime = DateTime.Now;
                item.OrderEndTime = Etime;
                item.RequiredTime = Rtime;
            }
            


            var orderList = this.Session["SelectedList"] as OrderListModels;
            orderList.OrderTime = DateTime.Now;
            orderList.OrderEndTime = Etime;
            orderList.RequiredTime = Rtime;



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

                var orderListsession = this.Session["SelectedList"] as OrderListModels;
                DrinkListManager.StartGroup(orderListsession);

                MessageBox.Show($"訂購完成，訂單編號為【{orderList.OrderNumber}】\r\n之後可由訂單明細查詢訂購項目", "完成!",
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




    }

}