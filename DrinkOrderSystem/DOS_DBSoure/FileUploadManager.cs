using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace DOS_DBSoure
{
    public class FileUploadManager
    {
            private static int fileSeq = 0; //流水號
            private static string[] allowFileExt = { ".bmp", ".jpg", ".png" }; //限制只能使用三種檔案

            private const int mbs = 10;
            private const int maxLength = mbs * 1024 * 1024;
            //訂死就可改型別為const


            /// <summary>
            /// 取得新檔名
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static string GetNewFileName(FileUpload fileUpload)
            {


                //重複名稱解一:多等幾秒
                System.Threading.Thread.Sleep(4);

                //重複名稱解二:且PadLeft加入亂數
                string seqText = new Random((int)DateTime.Now.Ticks).Next(0, 1000).ToString().PadLeft(3, '0');

                string orgFileName = fileUpload.FileName;
                string ext = System.IO.Path.GetExtension(orgFileName);
                string newFileName = DateTime.Now.ToString("yyyMMddHHmmssFFFFFF") + seqText + ext;

                return newFileName;

            }


            /// <summary>
            /// 驗證上傳之檔案
            /// </summary>
            /// <param name="fileUpload"></param>
            /// <param name="msgList">回傳錯誤訊息</param>
            /// <returns></returns>
            public static bool VaildFileUpload(FileUpload fileUpload, out List<string> msgList)
            {
                msgList = new List<string>();
                if (!VaildFileExt(fileUpload.FileName))
                {
                    msgList.Add("Only allow .bmp, .jpg, .png");
                }

                if (!VaildFileLength(fileUpload.FileBytes))
                {
                    msgList.Add("Only allow Length: " + mbs + "MB");
                }

                if (msgList.Any())
                    return false;
                else
                    return true;

            }



            /// <summary>
            /// 驗證檔案長度
            /// </summary>
            /// <param name="fileContent"></param>
            /// <returns></returns>
            private static bool VaildFileLength(byte[] fileContent)
            {
                if (fileContent.Length > maxLength)
                {

                    return false;
                }
                else
                    return true;
            }


            /// <summary>
            /// 驗證副檔名
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            private static bool VaildFileExt(string fileName)
            {
                //副檔名之限制：含有
                string ext = System.IO.Path.GetExtension(fileName);
                //限制只能用三種檔案
                if (!allowFileExt.Contains(ext.ToLower()))
                {

                    return false;
                }

                else
                    return true;

            }




        }

    }
