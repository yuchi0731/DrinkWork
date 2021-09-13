using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }
        }



        protected void Imgbtn50Lan_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = null;
            this.Session["DrinkShop"] = "50Lan";

            this.txtChooseDrinkList.Text = string.Empty;
            string SupplierName = "50Lan";
            var list = DrinkListManager.GetProducts(SupplierName);

            GetShopData(list);
        }

        protected void ImgbtnWhiteAlley_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = null;
            this.Session["DrinkShop"] = "WhiteAlley";

            string SupplierName = "WhiteAlley";
            var list = DrinkListManager.GetProducts(SupplierName);
            GetShopData(list);
        }

        protected void ImgbtnMilkshop_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = null;
            this.Session["DrinkShop"] = "Milkshop";

            string SupplierName = "Milkshop";
            var list = DrinkListManager.GetProducts(SupplierName);
            GetShopData(list);
        }


        /// <summary>
        /// 商家的共用建立List
        /// </summary>
        /// <param name="dt"></param>
        private void GetShopData(List<Product> list)
        {
            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                var dtPaged = this.GetPageDataTable(list);

                this.gvChooseDrink.DataSource = list;
                this.gvChooseDrink.DataBind();
                this.ucPager.Visible = true;
            }
            else
            {
                this.gvChooseDrink.Visible = false;
                this.btnSent.Visible = false;
            }
        }




        /// <summary>
        /// 讀取GridView控制項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvChooseDrink_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var item = e.CommandSource as Button;    //第二種 老師解的

            // 找到 button 的容器，它會是 GridViewRow
            var container = item.NamingContainer;

            var DDLQuantity = container.FindControl("dlQuantity") as DropDownList;
            var DDLSugar = container.FindControl("dlChooseSugar") as DropDownList;
            var DDLIce = container.FindControl("dlChooseIce") as DropDownList;
            var DDLToppings = container.FindControl("dlChooseToppings") as DropDownList;



            if (DDLQuantity.SelectedIndex == 0)
            {
                this.txtChooseDrinkList.Visible = true;
                DDLQuantity.SelectedIndex = 0;
                this.txtChooseDrinkList.Text = "數量選擇格式錯誤，請重新選擇";
                return;
            }


            if (DDLSugar.SelectedIndex == 0)
            {
                this.txtChooseDrinkList.Visible = true;
                DDLSugar.SelectedIndex = 0;
                this.txtChooseDrinkList.Text = "糖量選擇格式錯誤，請重新選擇";
                return;
            }


            if (DDLIce.SelectedIndex == 0)
            {
                this.txtChooseDrinkList.Visible = true;
                DDLIce.SelectedIndex = 0;
                this.txtChooseDrinkList.Text = "冰塊選擇格式錯誤，請重新選擇";
                return;
            }


            if (DDLToppings.SelectedIndex == 0)
            {
                this.txtChooseDrinkList.Visible = true;
                DDLToppings.SelectedIndex = 0;
                this.txtChooseDrinkList.Text = "加料選擇格式錯誤，請重新選擇";
                return;
            }



            if (string.Compare("ChooseDrink", item.CommandName, true) == 0)
            {
                this.txtChooseDrinkList.Visible = true;


                this.txtChooseDrinkList.Text += $"{e.CommandArgument as string} {DDLQuantity.SelectedItem}杯 {DDLSugar.SelectedItem} {DDLIce.SelectedItem} {DDLToppings.SelectedItem}\r\n";

                this.btnDelete.Visible = true;
                this.btnSent.Visible = true;

            }

            if (e.CommandName == "ChooseDrink")
            {
                string argu = (e.CommandArgument) as string;

                var supplierName = this.Session["DrinkShop"].ToString();
                var orderNumber = new Random().ToString(); //產生訂單編號亂數

                var currentUser = AuthManager.GetCurrentUser();


                List<OrderDetail> sourcedetaillist = DrinkListManager.GetOrderDetailList(supplierName);

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
                    OrderDetailsID = Guid.NewGuid(),
                    OrderNumber = orderNumber,
                    //Account = DOS_Auth.AuthManager.GetCurrentUser().Account,
                    Account = currentUser.Account,
                    OrderTime = DateTime.Now,
                    OrderEndTime = DateTime.Now,
                    RequiredTime = DateTime.Now,
                    ProductName = e.CommandArgument as string,
                    Quantity = quan,
                    UnitPrice = drinkdetaillist.UnitPrice,
                    Suger = DDLSugar.SelectedItem.ToString(),
                    Ice = DDLIce.SelectedItem.ToString(),
                    Toppings = DDLToppings.SelectedItem.ToString(),
                    SupplierName = supplierName,
                    OtherRequest = null
                };


                ((List<OrderDetailModels>)this.Session["SelectedItems"]).Add(orderdetaillist);

            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtChooseDrinkList.Text = string.Empty;
            Session["SelectedItems"] = null;
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderConfirm.aspx");
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

    }

}