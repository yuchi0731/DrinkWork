using DOS_ORM.DOSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class UserInfoSearch
    {





        #region 篩選
        /// <summary>
        /// 利用帳號篩選
        /// </summary>
        public static UserInfo SelectAccount(UserInfo account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userAccount =
                        context.UserInfoes.Where(obj => obj.Account == account.Account).FirstOrDefault();

                    return userAccount;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用EmployeeID篩選
        /// </summary>
        public static UserInfo SelectEmployeeID(UserInfo employeeID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userEmployeeID =
                        context.UserInfoes.Where(obj => obj.EmployeeID == employeeID.EmployeeID).FirstOrDefault();

                    return userEmployeeID;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用lastname篩選
        /// </summary>
        public static UserInfo SelectLastname(UserInfo lastname)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userLastname =
                        context.UserInfoes.Where(obj => obj.LastName == lastname.LastName).FirstOrDefault();

                    return userLastname;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用lastname篩選
        /// </summary>
        public static UserInfo SelectFirstname(UserInfo firstname)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userFirstname =
                        context.UserInfoes.Where(obj => obj.FirstName == firstname.FirstName).FirstOrDefault();

                    return userFirstname;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 利用Department篩選
        /// </summary>
        public static UserInfo SelectDepartment(UserInfo department)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var userDepartment =
                        context.UserInfoes.Where(obj => obj.Department == department.Department).FirstOrDefault();

                    return userDepartment;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        #endregion





        #region 利用篩選條件建立表單
        /// <summary>
        /// AccountList
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<UserInfo> GetAccountList(string account)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    //var query =
                    //    (from obj in context.UserInfoes
                    //     where obj.Account == account
                    //     select obj);

                    //var list = query.ToList();


                    var userAccount =
                      context.UserInfoes
                      .Where(obj => obj.Account == account);
                    var list = userAccount.ToList();


                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// EmployeeIDList
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<UserInfo> GetEmployeeIDList(int employeeID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from obj in context.UserInfoes
                         where obj.EmployeeID == employeeID
                         select obj);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// LastNameList
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<UserInfo> GetLastNameList(string lastName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from obj in context.UserInfoes
                         where obj.LastName == lastName
                         select obj);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// FirstNameList
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<UserInfo> GetFirstNameList(string firstName)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from obj in context.UserInfoes
                         where obj.FirstName == firstName
                         select obj);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// DepartmentList
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<UserInfo> GetDepartmentIDList(string departmentID)
        {
            try
            {
                using (DKContextModel context = new DKContextModel())
                {
                    var query =
                        (from obj in context.UserInfoes
                         where obj.DepartmentID == departmentID
                         select obj);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        #endregion
    }
}
