using DOS_Auth;
using DOS_DBSoure;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
                if(orderDetail.Established == "Fail" || orderDetail.Established == "Established")
                {
                    DialogResult MsgBoxResult;
                    MsgBoxResult = MessageBox.Show("此訂單已完成或超過結帳時間", "取消",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");

                }



                var list = DrinkListManager.GetOrderListbyorderNumber(orderNumber);

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

            else
            {
                sendGmail();
                //更改訂單成立狀況
                DrinkListManager.UpdateEstablished(orderNumber);
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("訂購成功，已有寄系統確認信至您的信箱", "訂購成功",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");                
            }
            

  


            //if (gvOrderList.Rows.Count == 0)
            //{
            //    return;
            //}
            //Response.ClearContent();
            //Response.ContentEncoding = Encoding.Default;
            //Response.AddHeader("content-disposition", "attatchment;filename=" + HttpUtility.UrlEncode("OrderExcel.xls", Encoding.UTF8));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //gvSend.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();


        }


        //必須過載此方法,以便支援上面的匯出操作
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }


        internal static void WriteText(string orderNumber,string txt)
        {           
            string msg =
                $@"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                   訂單編號{orderNumber}
                   {txt.ToString()}
                    ";

            string logPath = "D:\\Text\\text.txt";
            string folderPath = System.IO.Path.GetDirectoryName(logPath);

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            if (!System.IO.File.Exists(logPath))
                System.IO.File.Create(logPath);

            System.IO.File.AppendAllText(logPath, msg);

        }

        public void ShowMessage(string messageText)
        {
            messageText = "alert('" + messageText + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), string.Empty, messageText, true);
        }

        protected void btnViewDetail_Click(object sender, EventArgs e)
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            var DetailInfo = "";
            foreach (var item in allDetail)
            {
                DetailInfo +=
                    "【訂購人】" + item.Account.ToString()
                    + Environment.NewLine
                    + "【飲料】" + item.ProductName.ToString()
                    + Environment.NewLine
                    + "【單價】" + item.UnitPrice.ToString()
                    + Environment.NewLine
                    + "【杯數】" + item.Quantity.ToString()
                    + Environment.NewLine
                    + "【甜度】" + item.Suger.ToString()
                    + Environment.NewLine
                    + "【冰量】" + item.Ice.ToString()
                    + Environment.NewLine
                    + "【加料】" + item.Toppings.ToString()
                    + Environment.NewLine
                    + "【加料單價】" + item.ToppingsUnitPrice.ToString()
                    + "-----------------------------------"
                    + "\r\n";
            }


            ShowMessage(DetailInfo);


            #region 不用
            this.plDetail.Visible = false;

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
            #endregion
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



        public void sendGmail()
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            var DetailInfo = "";
            foreach (var item in allDetail)
            {
                DetailInfo +=
                    "【訂購人】" + item.Account.ToString()
                    + Environment.NewLine
                    + "【飲料】" + item.ProductName.ToString()
                    + Environment.NewLine
                    + "【單價】" + item.UnitPrice.ToString()
                    + Environment.NewLine
                    + "【杯數】" + item.Quantity.ToString()
                    + Environment.NewLine
                    + "【甜度】" + item.Suger.ToString()
                    + Environment.NewLine
                    + "【冰量】" + item.Ice.ToString()
                    + Environment.NewLine
                    + "【加料】" + item.Toppings.ToString()
                    + Environment.NewLine
                    + "【加料單價】" + item.ToppingsUnitPrice.ToString()
                    + "-----------------------------------"
                    + "\r\n";
            }




            var currentUser = AuthManager.GetCurrentUser();
            var userData = UserInfoManager.GetUserInfo(currentUser.Account);
            var userEmail = userData.Email.ToString();
            var mine = "kireha2180@gmail.com";

            var adminEmail = "admin@gmail.com";
            var ademin = "管理者";

            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress(adminEmail, ademin);

            //收信者email
            mail.To.Add($"{mine}");

            //設定優先權
            mail.Priority = MailPriority.Normal;

            //標題
            mail.Subject = $"您好，訂購編號：{orderNumber}已訂購完成！";

            //內容
            mail.Body = 
                "<h1>您好，您所開團的團購已訂購完成</h1><br/>" +
                "並送出訂單給予廠商，待廠商送達，請依照需求時間至公司門口領取，謝謝<br/>" +
                $"訂單明細為：\r\n {DetailInfo}";

            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp (這是google的)
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("kireha2180@gmail.com", "youriko0417");

            //開啟ssl
            MySmtp.EnableSsl = true;

            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();
        }


        protected void btnText_Click(object sender, EventArgs e)
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            var DetailInfo = "";
            foreach (var item in allDetail)
            {
                DetailInfo +=
                    "【訂購人】" + item.Account.ToString()
                    + Environment.NewLine
                    + "【飲料】" + item.ProductName.ToString()
                    + Environment.NewLine
                    + "【單價】" + item.UnitPrice.ToString()
                    + Environment.NewLine
                    + "【杯數】" + item.Quantity.ToString()
                    + Environment.NewLine
                    + "【甜度】" + item.Suger.ToString()
                    + Environment.NewLine
                    + "【冰量】" + item.Ice.ToString()
                    + Environment.NewLine
                    + "【加料】" + item.Toppings.ToString()
                    + Environment.NewLine
                    + "【加料單價】" + item.ToppingsUnitPrice.ToString()
                    + "-----------------------------------"
                    + "\r\n";
            }

            WriteText(orderNumber, DetailInfo);
        }
    }
}