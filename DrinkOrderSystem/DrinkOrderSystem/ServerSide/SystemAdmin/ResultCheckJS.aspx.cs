using DOS_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.SystemAdmin
{
    public partial class ResultCheckJS : System.Web.UI.Page
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

                this.ltResult.Text = this.Session["JStext"].ToString();





            }


            
        }

        protected void btntxt_Click(object sender, EventArgs e)
        {
            string msg =
            $@"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                   {this.Session["JStext"].ToString()}
                    ";

            string txtPath = "D:\\Logs\\Log.log";
            string folderPath = System.IO.Path.GetDirectoryName(txtPath);

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            if (!System.IO.File.Exists(txtPath))
                System.IO.File.Create(txtPath);

            System.IO.File.AppendAllText(txtPath, msg);



        }
    }
}