using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.ProductManagement
{
    public partial class AddProduct : System.Web.UI.Page
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
                var jobGrade = current.JobGrade;
                if (jobGrade < 1)
                {
                    Response.Redirect("/ServerSide/SystemAdmin/UserPage.aspx");
                    return;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var pdName = this.txtNewProduct.Text;
            var supName = this.ddSupplier.SelectedValue.ToString();
            var txtunitPrice = this.txtUnitPrice.Text;
            var category = this.ddCategory.SelectedValue.ToString();

            if(category == "non")
            {
                this.lbMsg.Text = "種類尚未選取";
                return;
            }

            Product product = new Product()
            {
                ProductName = pdName,
                SupplierName = supName,    
                CategoryName = category
            };

            decimal unitPrice;
            if(decimal.TryParse(txtunitPrice, out unitPrice))
            {
                 product.UnitPrice = unitPrice;
            }


            //假設有上傳檔案，就寫入檔名
            if (this.fdPictrue.HasFile && FileUploadManager.VaildFileUpload(this.fdPictrue, out List<string> tempList))
            {
                string saveFileName = FileUploadManager.GetNewFileName(this.fdPictrue);
                string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                this.fdPictrue.SaveAs(filePath);

                product.Picture = saveFileName;

            }


            ProductManager.CreateNewProduct(product);
            MessageBox.Show("～建立成功～", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("/ServerSide/ProductManagement/ProductList.aspx");

        }

        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/ServerSide/ImagesServer");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("尚有未儲存變更，繼續請按確認", "清除",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (MsgBoxResult == DialogResult.OK)
            {

                this.txtNewProduct.Text = null;
                this.ddSupplier.SelectedIndex = 0;
                this.txtUnitPrice.Text = null;
                this.ddCategory.SelectedIndex = 0;

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