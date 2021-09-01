using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOS_DBSoure;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class OrderStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
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
            int pageSize = this.ucPager.PageSize;


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


        protected void Button1_Click(object sender, EventArgs e)
        {
            

            var shopname = "WhiteAlley";

            //read all drink data
            var dt = DrinkListManager.GetAllDrinkbySupplier(shopname);

            int drinkcount = dt.Rows.Count;
            
            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var dtpaged = this.GetPagedDataTable(dt);
           
                this.gvdrinklist.DataSource = dtpaged;
                this.gvdrinklist.DataBind();

            }
            else
            {
                this.gvdrinklist.Visible = false;
                this.plcNoData.Visible = true;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string SupplierName = "WhiteAlley";
            var dt = DrinkListManager.GetChooseDrinkList(SupplierName);

            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.gvdrinklist.DataSource = dtPaged;
                this.gvdrinklist.DataBind();
            }
            else
            {
                this.gvdrinklist.Visible = false;
               
            }
        }



        protected void gvdrinklist_RowCommand(object sender, GridViewCommandEventArgs e)
        {

           
                var item = e.CommandSource as Button;



                if (string.Compare("Button3", item.CommandName, true) == 0)
                {
                    // 找到 button 的容器，它會是 GridViewRow
                    var container = item.NamingContainer;



                    var ddl = container.FindControl("DropDownList1") as DropDownList;
                    this.txtAll.Text = $"{e.CommandArgument as string }+{ddl.SelectedItem}";
                }
            




            
        }
    }



    
}