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
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }



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


    }

}