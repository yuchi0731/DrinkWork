using DOS_DBSoure;
using DOS_Models;
using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DOS_Auth
{
    public class AuthManager
    {
        /// <summary> 檢查目前是否登入 </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 取得目前使用者資料
        /// </summary>
        /// <returns></returns>
        public static UserInfoModels GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            UserInfo userlist = UserInfoManager.GetUserInfo(account);

            if(userlist == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }


            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            UserInfoModels model = new UserInfoModels();
            model.Account = userlist.Account;
            model.EmployeeID = userlist.EmployeeID;
            model.DepartmentID = userlist.DepartmentID;
            model.Department = userlist.Department;
            model.FirstName = userlist.FirstName;
            model.LastName = userlist.LastName;
            model.Contact = userlist.Contact;
            model.Email = userlist.Email;
            model.ext = userlist.ext;
            model.Phone = userlist.Phone;
            model.JobGrade = userlist.JobGrade;
            model.Description = userlist.Description;
            model.ResponseSuppliers = userlist.ResponseSuppliers;
            model.Photo = userlist.Photo;
            model.CreateDate = userlist.CreateDate;
            model.LastModified = userlist.LastModified;



            return model;

        }





        /// <summary> 嘗試登入 </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // check empty
            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "帳號、密碼為必要輸入項目";
                return false;
            }


            UserAccount userlist = UserInfoManager.GetUserAccount(account);

            // check null
            if (userlist == null)
            {
                errorMsg = $"帳號為＂{account}＂使用者不存在，請確認是否輸入錯誤";
                return false;
            }


            // check account / pwd
            if (string.Compare(userlist.Account, account, true) == 0 &&
                string.Compare(userlist.Password, pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = userlist.Account;

                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "登入失敗，請確認帳號密碼是否正確";
                return false;
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null; //清除登入資料，導向登入頁
        }




        /// <summary>
        /// 嘗試建立新使用者
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="Repwd"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="errorMsg"></param>
        /// <param name="errorMsg2"></param>
        /// <returns></returns>
        public static bool TryCreateUser(string account, string pwd, string Repwd, string DID,string D, string FN, string LN,string contact, string email, string ext, string phone, int jobgrade, string desc,string Res, out string errorMsg, out string errorMsg2)
        {



            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(Repwd)|| string.IsNullOrWhiteSpace(DID) || string.IsNullOrWhiteSpace(D) || string.IsNullOrWhiteSpace(FN) || string.IsNullOrWhiteSpace(LN) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(ext) || string.IsNullOrWhiteSpace(phone))
            {
                //check empty
                if (string.IsNullOrWhiteSpace(account))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "帳號為必填";
                    return false;
                }

                else if (string.IsNullOrWhiteSpace(pwd))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "密碼為必填";
                    return false;
                }


                else
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = string.Empty;
                    return false;
                }
            }


            if(contact != "分機" && contact != "電話" && contact != "Email")
            {
                errorMsg = "聯絡方式格式錯誤!請重新選取";
                errorMsg2 = string.Empty;
                return false;
            }


            if (jobgrade < 0 || jobgrade > 2)
            {
                errorMsg = "使用者等級格式錯誤!請重新選取";
                errorMsg2 = string.Empty;
                return false;
            }



            if (string.Compare(pwd, Repwd, false) != 0)
            {
                errorMsg = "密碼不一致，請確認密碼";
                errorMsg2 = string.Empty;           
                return false;
            }






            //密碼相符且姓名信箱皆有填寫
            if (string.Compare(pwd, Repwd, false) == 0)
            {
                errorMsg = string.Empty;
                errorMsg2 = string.Empty;
                return true;

            }

            else
            {
                errorMsg = "資料不正確，請確認資料";
                errorMsg2 = string.Empty;
                return false;
            }


        }



        public static bool AuthTextLength (string txt)
        {
            if (txt.Length > 0)
            {
                return true;
            }
            else
                return false;
        }

    }
}
