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
                    this.gvOrderList.DataSource = list;
                    this.gvOrderList.DataBind();
                }
                else
                {
                    this.gvOrderList.Visible = false;
                    this.btnExportToExcel.Visible = false;
                    this.btnCancel.Visible = false;
                    this.lbMsg.Visible = true;
                    this.lbMsg.Text = "找不到訂單資料";
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
            if (orderDetail.RequiredTime < DateTime.Now.AddMinutes(30))
            {
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("此訂單已超過結帳時間", "取消",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");

            }


            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            //轉JS
            string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(allDetail);
            if(this.Session["JStext"] == null)
            this.Session["JStext"] = jsonText;

            //更改訂單成立狀況
            DrinkListManager.UpdateEstablished(orderNumber);




            if (gvOrderList.Rows.Count == 0)
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

        protected void btnViewDetail_Click(object sender, EventArgs e)
        {
            this.plDetail.Visible = true;
            string orderNumber = this.Request.QueryString["OrderNumber"];

            var Detaillist = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            if (Detaillist.Count > 0) //check is empty data (大於0就做資料繫結)
            {
                this.btnExportToExcel.Visible = true;
                this.btnCancel.Visible = true;
                this.gvSend.DataSource = Detaillist;
                this.gvSend.DataBind();
            }
            else
            {
                this.gvSend.Visible = false;
                this.btnExportToExcel.Visible = false;
                this.btnCancel.Visible = false;
                this.lbMsg.Visible = true;
                this.lbMsg.Text = "找不到訂單資料";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("即將取消訂單，繼續請按確認", "清除",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (MsgBoxResult == DialogResult.OK)
            {
                Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");
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