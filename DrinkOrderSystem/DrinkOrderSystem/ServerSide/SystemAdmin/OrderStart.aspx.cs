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
       
        }



        protected void Imgbtn50Lan_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = "50Lan";

            this.txtChooseDrinkList.Text = string.Empty;
            string SupplierName = "50Lan";
            var dt = DrinkListManager.GetChooseDrinkList(SupplierName);

            ShopBtn(dt);
        }

        protected void ImgbtnWhiteAlley_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = "WhiteAlley";
            
            string SupplierName = "WhiteAlley";
            var dt = DrinkListManager.GetChooseDrinkList(SupplierName);
            ShopBtn(dt);
        }

        protected void ImgbtnMilkshop_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["DrinkShop"] = "Milkshop";

            string SupplierName = "Milkshop";
            var dt = DrinkListManager.GetChooseDrinkList(SupplierName);
            ShopBtn(dt);
        }


        /// <summary>
        /// 商家的共用建立List
        /// </summary>
        /// <param name="dt"></param>
        private void ShopBtn(DataTable dt)
        {
            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.gvChooseDrink.DataSource = dtPaged;
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

                var supplierName = this.Session["DrinkShop"].ToString();
                var orderNumber = "M01";
                var account = "OwO";

                 List<OrderDetail> sourcedetaillist = DrinkListManager.GetOrderDetailList(supplierName);

                //利用商品名連動到商品資料表
                var drinkdetaillist = sourcedetaillist.Where(obj => obj.ProductName == argu).FirstOrDefault();
                if(drinkdetaillist != null)
                {
                    if (this.Session["SelectedItems"] == null)
                        this.Session["SelectedItems"] = new List<OrderDetailModels>();
                }

                var orderdetaillist = new OrderDetailModels()
                {
                    OrderNumber = orderNumber,
                    //Account = DOS_Auth.AuthManager.GetCurrentUser().Account,
                    Account = account,
                    OrderTime = DateTime.Now.ToString(),
                    OrderEndTime = DateTime.Now.ToString(),
                    RequiredTime = DateTime.Now.ToString(),
                    ProductName = e.CommandArgument as string,
                    Quantity = DDLQuantity.SelectedItem.Value,
                    UnitPrice = drinkdetaillist.UnitPrice.ToString(),
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


        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            //int pageSize = this.ucPager.PageSize;


            int startIndex = (this.GetCurrentPage() - 1) * 10;
            int endIndex = (this.GetCurrentPage()) * 10;

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }

    }

}