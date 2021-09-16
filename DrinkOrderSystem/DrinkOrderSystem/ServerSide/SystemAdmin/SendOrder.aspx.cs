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
                    this.btnExport.Visible = false;
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
        protected void btnExport_Click(object sender, EventArgs e)
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
                bool sendmail = sendGmail();
                if (sendmail == true)
                {
                    //更改訂單成立狀況
                    DrinkListManager.UpdateEstablished(orderNumber);
                    DialogResult MsgBoxResult;
                    MsgBoxResult = MessageBox.Show("訂購成功，已有寄系統確認信至您的信箱，請確認", "訂購成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    this.Session.Remove("OrderNumber");
                    Response.Redirect("/ServerSide/SystemAdmin/OrderRecords.aspx");
                }

                else
                {
                    MessageBox.Show("失敗，請檢查信箱連線是否成功", "訂購失敗");
                    return;
                }

            }

        }



        internal static void WriteText(string orderNumber,string txt)
        {

            string text = $"訂單編號：{orderNumber}" + "\r\n" + txt;
            System.IO.File.WriteAllText($@"D:\Text\{orderNumber}List.txt", text);


        }

        public void ShowMessage(string messageText)
        {
            messageText = "alert('" + messageText + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), string.Empty, messageText, true);
        }

        protected void btnViewDetail_Click(object sender, EventArgs e)
        {
            this.txtCheck.Visible = true;
            this.btnText.Visible = true;
            this.btnCancel.Visible = true;
            this.btnExport.Visible = true;
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            string DetailInfo = "";
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
                    + Environment.NewLine
                    + "-----------------------------------"
                    + Environment.NewLine;
            }


            this.txtCheck.Text = DetailInfo;


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("即將取消訂單，繼續請按確認", "取消",
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



        public bool sendGmail()
        {
            string orderNumber = this.Request.QueryString["OrderNumber"];
            var allDetail = DrinkListManager.GetOrderDetailListbyorderNumber(orderNumber);

            var DetailInfo = "";
            foreach (var item in allDetail)
            {
                DetailInfo +=
                    "【訂購人】" + item.Account.ToString()
                    + "\n"
                    + "【飲料】" + item.ProductName.ToString()
                    + "\n"
                    + "【單價】" + item.UnitPrice.ToString()
                    + "\n"
                    + "【杯數】" + item.Quantity.ToString()
                    + "\n"
                    + "【甜度】" + item.Suger.ToString()
                    + "\n"
                    + "【冰量】" + item.Ice.ToString()
                    + "\n"
                    + "【加料】" + item.Toppings.ToString()
                    + "\n"
                    + "【加料單價】" + item.ToppingsUnitPrice.ToString()
                    + "\n"
                    + "-----------------------------------"
                    + "\n";
            }



            var reqtime = DrinkListManager.GetOrderDetailListfromorderNumber(orderNumber).RequiredTime.ToString("MM-dd HH:mm");
            var currentUser = AuthManager.GetCurrentUser();
            var userData = UserInfoManager.GetUserInfo(currentUser.Account);
            var userEmail = userData.Email.ToString();
            var mine = "fuchiharayuchi@gmail.com";
            

            var adminEmail = "DrinkOrderServer@gmail.com";
            var ademin = "管理者";

            var title = $"{currentUser.FirstName}您好，訂購編號：{orderNumber}已訂購完成！";
            var message = $"您好，您所開團的團購已訂購完成\r\n並送出訂單給予廠商，待廠商送達，請依照送達時間{reqtime}\r\n至公司門口領取，謝謝\r\n訂單明細為：</ br > {DetailInfo}";

            try
            {

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add("fuchiharayuchi@gmail.com");
                //msg.To.Add("b@b.com");可以發送給多人
                //msg.CC.Add("c@c.com");
                //msg.CC.Add("c@c.com");可以抄送副本給多人 
                //這裡可以隨便填，不是很重要
                msg.From = new MailAddress(adminEmail, ademin, System.Text.Encoding.UTF8);
                /* 上面3個參數分別是發件人地址（可以隨便寫），發件人姓名，編碼*/
                msg.Subject = title;//郵件標題
                msg.SubjectEncoding = System.Text.Encoding.UTF8;//郵件標題編碼
                msg.Body = message; //郵件內容
                msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
                //msg.Attachments.Add(new Attachment(@"D:\Text.docx"));  //附件
                msg.IsBodyHtml = true;//是否是HTML郵件 
                                      //msg.Priority = MailPriority.High;//郵件優先級 

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("fuchiharayuchi", "kogdvbltanvzdmgy"); //這裡要填正確的帳號跟密碼
                client.Host = "smtp.gmail.com"; //設定smtp Server
                client.Port = 25; //設定Port
                client.EnableSsl = true; //gmail預設開啟驗證
                client.Send(msg); //寄出信件
                client.Dispose();
                msg.Dispose();

                return true;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message);
                return false;
            }






            //MailMessage mail = new MailMessage();
            ////前面是發信email後面是顯示的名稱
            //mail.From = new MailAddress(adminEmail, ademin);

            ////收信者email
            //mail.To.Add($"{mine}");

            ////設定優先權
            //mail.Priority = MailPriority.Normal;

            ////標題
            //mail.Subject = $"您好，訂購編號：{orderNumber}已訂購完成！";

            ////內容
            //mail.Body = 
            //    "<h1>您好，您所開團的團購已訂購完成</h1><br/>" +
            //    "並送出訂單給予廠商，待廠商送達，請依照需求時間至公司門口領取，謝謝<br/>" +
            //    $"訂單明細為：\r\n {DetailInfo}";

            ////內容使用html
            //mail.IsBodyHtml = true;

            ////設定gmail的smtp (這是google的)
            //SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            ////您在gmail的帳號密碼
            //MySmtp.Credentials = new System.Net.NetworkCredential("kireha2180@gmail.com", "youriko0417");

            ////開啟ssl
            //MySmtp.EnableSsl = true;

            ////發送郵件
            //MySmtp.Send(mail);

            ////放掉宣告出來的MySmtp
            //MySmtp = null;

            ////放掉宣告出來的mail
            //mail.Dispose();
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
                    + Environment.NewLine
                    + "-----------------------------------"
                    + Environment.NewLine;
            }

            WriteText(orderNumber, DetailInfo);
        }
    }
}