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
    public partial class ModifyProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string productID = this.Request.QueryString["ProductID"];
            var prodData = ProductManager.GetProductInfoByID(Convert.ToInt32(productID));

            var pdName = this.txtProduct.Text;
            var txtunitPrice = this.txtUnitPrice.Text;

            Product product = new Product()
            {
                ProductName = pdName,
            };

            decimal unitPrice;
            if (decimal.TryParse(txtunitPrice, out unitPrice))
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

            ProductManager.UpdateProduct(product);
            MessageBox.Show("～建立成功～", "成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("/ServerSide/ProductManagement/ProductList.aspx");

        }

            private string GetSaveFolderPath()
            {
                return Server.MapPath("~/ServerSide/ImagesServer");
            }
        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}