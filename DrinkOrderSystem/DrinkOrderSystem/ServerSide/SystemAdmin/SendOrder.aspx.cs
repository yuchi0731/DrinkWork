using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class SendOrder : System.Web.UI.Page
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
                var orderDetail = DrinkListManager.GetOrderDetailInfo(orderNumber);


                //判斷訂單結帳時間，若預計送達時間是三十分鐘內則取消訂單
                if(orderDetail.RequiredTime < DateTime.Now.AddHours(1))
                {
                    DialogResult MsgBoxResult;
                    MsgBoxResult = MessageBox.Show("此訂單已完成或超過結帳時間", "取消",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");

                }
                


                var list = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

                if (list.Count > 0) //check is empty data (大於0就做資料繫結)
                {
                    this.gvSend.DataSource = list;
                    this.gvSend.DataBind();
                }
                else
                {
                    this.gvSend.Visible = false;
                }


            }

        }

        /// <summary>
        /// 將GridView的資料輸出到Excel檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var orderDetail = DrinkListManager.GetOrderDetailInfo(orderNumber);
            if (orderDetail.RequiredTime < DateTime.Now.AddMinutes(29))
            {
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("此訂單已超過結帳時間", "取消",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");

            }


            if (gvSend.Rows.Count == 0)
            {
                return;
            }
            Response.ClearContent();
            Response.ContentEncoding = Encoding.Default;
            Response.AddHeader("content-disposition", "attatchment;filename=" + HttpUtility.UrlEncode("OrderExcel.xls", Encoding.UTF8));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvSend.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        //必須過載此方法,以便支援上面的匯出操作
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
    }
}