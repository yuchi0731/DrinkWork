using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.ProductManagement
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/ClientSide/Login.aspx");
                    return;
                }

                var current = AuthManager.GetCurrentUser();
                if (current.JobGrade < 1)
                {
                    Response.Redirect("/ServerSide/SystemAdmin/UserPage.aspx");
                    return;
                }


                var list = ProductManager.GetAllProductList();
                if (list.Count > 0) 
                {

                    var pageUserList = this.GetPageDataTable(list);
                    this.gvProduct.DataSource = pageUserList;
                    this.gvProduct.DataBind();

                    this.ucPager.TotalSize = list.Count;
                    this.ucPager.Bind();


                }
                else
                {
                    this.gvProduct.Visible = false;
                    this.plcNoData.Visible = true;
                    this.lbMsg.Text = "目前沒有任何商品資料";
                }
            }
        }

        private void BindList(List<Product> list)
        {
            if (list.Count > 0)
            {

                var pageUserList = this.GetPageDataTable(list);
                this.gvProduct.DataSource = pageUserList;
                this.gvProduct.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();


            }
            else
            {
                this.gvProduct.Visible = false;
                this.plcNoData.Visible = true;
                this.lbMsg.Text = "篩選錯誤，請確認篩選條件是否正確";
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

        protected void ddSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = this.ddSelect.SelectedValue.ToString();
            if (select == "SelectName" || select == "SelectSup" || select == "SelectCategoryName")
            {
                this.btnSelect.Visible = true;
                this.txtSelect.Visible = true;
            }

            else
            {
                this.txtSelect.Visible = false;
                this.btnSelect.Visible = true;
            }
            
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var select = this.ddSelect.SelectedValue.ToString();
            var txtSelect = this.txtSelect.Text;
            if (select == "SelectName")
            {
                var list = ProductManager.GetProductListByproductName(txtSelect);
                BindList(list);
            }

            if (select == "SelectSup")
            {
                var list = ProductManager.GetProductListBysupplierName(txtSelect);
                BindList(list);
            }

            if (select == "SelectCategoryName")
            {
                var list = ProductManager.GetProductListByCategoryName(txtSelect);
                BindList(list);
            }


            if (select == "SortingName")
            {
                var list = ProductManager.OrderbyProductListByproductName();
                BindList(list);
            }


            if (select == "SortingSup")
            {
                var list = ProductManager.OrderbyProductListBysupplierName();
                BindList(list);
            }


        }

        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //按下刪除鍵
            var productID = e.CommandArgument as string;

            int id;
            if(int.TryParse(productID, out id))

            if (string.Compare("btndelete", e.CommandName, true) == 0)
            {
                DialogResult MsgDelete;
                MsgDelete = MessageBox.Show("若刪除資料將無法復原，繼續請按確定", "刪除",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

                if (MsgDelete == DialogResult.OK)
                {
                    ProductManager.DeleteProductByProductID(id);
                    Response.Redirect("/ServerSide/ProductManagement/ProductList.aspx");
                }


                else
                    return;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServerSide/ProductManagement/ProductList.aspx");
            var list = ProductManager.GetAllProductList();
            if (list.Count > 0)
            {

                var pageUserList = this.GetPageDataTable(list);
                this.gvProduct.DataSource = pageUserList;
                this.gvProduct.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();


            }
            else
            {
                this.gvProduct.Visible = false;
                this.plcNoData.Visible = true;
                this.lbMsg.Text = "目前沒有任何商品資料";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ServerSide/ProductManagement/AddProduct.aspx");
        }
    }
}