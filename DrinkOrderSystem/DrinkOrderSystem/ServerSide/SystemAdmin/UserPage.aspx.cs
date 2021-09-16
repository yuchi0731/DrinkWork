using DOS_Auth;
using DOS_DBSoure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class UserPage : System.Web.UI.Page
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


                var current = AuthManager.GetCurrentUser();
                var hasCheckoutList = DrinkListManager.GetneedCheckoutOrderList(current.Account);
                var goingtoendList = DrinkListManager.GetGTEOrderListInfo(current.Account);



                if (DrinkListManager.GetCheckUserhasOrderList(current.Account) != null)
                {
                    
                    if (hasCheckoutList != null)
                    {
                        DialogResult MsgBoxResult;
                        MsgBoxResult = MessageBox.Show("~提醒您尚有未結帳訂單~", "提醒",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    
                    if (goingtoendList.Established == "Inprogress" && goingtoendList.RequiredTime < DateTime.Now.AddMinutes(90))
                    {
                        DialogResult MsgBoxResult;
                        MsgBoxResult = MessageBox.Show($"訂單【{goingtoendList.OrderNumber}】即將過期，請盡速送出訂購單", "提醒",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    this.ltOrderNumber.Text = $"{goingtoendList.OrderNumber.ToString()}";
                    

                }


                else
                {
                    this.ltOrderNumber.Text = "尚未有訂購單";
                }

                var userInfo = UserInfoManager.GetUserInfo(current.Account);
                this.ltAccount.Text = current.Account.ToString();


                if (userInfo.JobGrade == 0)
                {
                    this.lbuserlevel.Text = "一般會員";
                    this.lbuserlevel.ForeColor = Color.Blue;

                }
                if (userInfo.JobGrade == 1)
                {
                    this.lbuserlevel.Text = "管理者";
                    this.lbuserlevel.ForeColor = Color.Green;

                }

                if (userInfo.JobGrade == 2)
                {
                    this.lbuserlevel.Text = "高階管理者";
                    this.lbuserlevel.ForeColor = Color.Red;
                }

                bool sendmail = Checksendmail();
                if (sendmail == true)
                {
                    SendGmail();
                }
                else
                {
                    return;
                }


            }
        }

        protected void btnChangePWD_Click(object sender, EventArgs e)
        {

            Response.Redirect("/ServerSide/UserManagement/ModifyPassword.aspx");
        }


        private void SendGmail()
        {
            var currentUser = AuthManager.GetCurrentUser();
            var userData = UserInfoManager.GetUserInfo(currentUser.Account);


            var orderGTEList = DrinkListManager.GetGTEOrderListInfo(currentUser.Account);
            var endtime = orderGTEList.OrderEndTime;
            var reqtime = orderGTEList.RequiredTime;
            var sendmailtime = DateTime.Now.AddHours(1.5);
            var sendlastTime = DateTime.Now.AddMinutes(80);
            var lastTime = DateTime.Now.AddMinutes(61);
            var established = orderGTEList.Established.ToString();

            var userEmail = userData.Email.ToString();
            var mine = "fuchiharayuchi@gmail.com";


            var adminEmail = "DrinkOrderServer@gmail.com";
            var ademin = "管理者";

            var title = $"{currentUser.FirstName}您好，訂購編號：{orderGTEList.OrderNumber}將過期！";
            var message = $"您好，您的訂單將在{lastTime}時後流單，請盡速進入結帳頁面\r\n並在1小時內完成訂購流程～謝謝!";

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
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message);
                return;
            }

        }


        public bool Checksendmail()
        {
            
            var currentUser = AuthManager.GetCurrentUser();
            var userData = UserInfoManager.GetUserInfo(currentUser.Account);

            var orderGTEList = DrinkListManager.GetGTEOrderListInfo(currentUser.Account);
            var endtime = orderGTEList.OrderEndTime;
            var reqtime = orderGTEList.RequiredTime;
            var sendmailtime = DateTime.Now.AddHours(1.5);
            var sendlastTime = DateTime.Now.AddMinutes(80);
            var lastTime = DateTime.Now.AddMinutes(61);
            var established = orderGTEList.Established.ToString();

            if(established == "Inprogress")
            {
                if(reqtime <= sendmailtime && reqtime > sendlastTime)
                {               
                        return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }



    }
}