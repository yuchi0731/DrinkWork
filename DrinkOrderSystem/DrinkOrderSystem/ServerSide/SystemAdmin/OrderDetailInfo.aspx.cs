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
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/ClientSide/Login.aspx");
                return;
            }




            var a = "M001";
            
            //read all drink data
            var list = DrinkListManager.GetOrderDetailListbyorderNumber(a);

            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var DetailList = this.GetPageDataTable(list);

                this.ucPager.Totaluser = list.Count;
                this.ucPager.BindUserList();


                this.gvDetail.DataSource = DetailList;
                this.gvDetail.DataBind();

            }
            else
            {
                this.gvDetail.Visible = false;
                this.plcNoData.Visible = true;
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

    }
}