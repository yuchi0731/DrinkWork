using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class TryFileUpload : System.Web.UI.Page
    {
        private static int fileSeq = 0; //流水號
        private static string[] allowFileExt = { ".bmp", ".jpg", ".png" }; //限制只能使用三種檔案
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/FileDownload");
            //取得專案中FileDownload資料夾路徑
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                //將名稱改名流水號並加上年月日時分秒毫秒
                fileSeq += 1;
                string orgFileName = this.FileUpload1.FileName;
                string newFileName = DateTime.Now.ToString("yyyMMddHHmmssFFFFFF");

                //含有
                string ext = System.IO.Path.GetExtension(orgFileName);

                //上傳檔案，若是檔名已存在會一直覆蓋
                //string path = 
                //    "D:\\Lession\\TryCookie\\TryCookie\\TryUpload\\FileDownload\\"
                //    + this.FileUpload1.FileName;
                //this.FileUpload1.SaveAs(path);




                //改為會改動名稱
                //string path =
                //"D:\\Lession\\TryCookie\\TryCookie\\TryUpload\\FileDownload\\"
                //+
                //newFileName
                //+ ext;


                //限制只能用三種檔案
                if (!allowFileExt.Contains(ext.ToLower()))
                {
                    this.Label1.Text = "Only allow .bmp, .jpg, .png";
                    return;
                }




                //改字串路徑為取得路徑之方法
                string path =
                System.IO.Path.Combine(
                this.GetSaveFolderPath(),newFileName + ext);





                this.FileUpload1.SaveAs(path);
                this.Label1.Text = "Success";

            }

            else
            {
                this.Label1.Text = "Only allow .bmp, .jpg, .png";
            }
        }
    }
}